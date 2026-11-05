-- =====================================================================
--  migracion_usuarios.sql
--  Base de datos: productosdb (MySQL 8.0)
--
--  Ajusta una base productosdb EXISTENTE para que el registro e inicio de
--  sesion funcionen con el hash de contrasenas hecho en C# (capa Negocios).
--  Si importas productosdb_dump.sql completo NO necesitas ejecutar este script
--  (el dump ya incluye todos estos cambios).
--
--  Solo se toca la entidad usuario:
--    * usuarios.dsPassword  -> VARCHAR(255): guarda el hash completo
--                              "PBKDF2-SHA256$iteraciones$salt$hash"
--    * usuarios.dsSalt      -> eliminada (el salt va dentro del hash)
--    * sp_RegistrarUsuario  -> recibe el hash ya calculado
--    * sp_ObtenerUsuarioLogin  (nuevo)  devuelve el usuario + su hash
--    * sp_ListarUsuarios       (nuevo)  datos para el DataGridView
--    * sp_CambiarEstadoUsuario (nuevo)  activar / desactivar usuario
--    * sp_ValidarLoginHash e insert_user -> eliminados (hasheaban dentro de MySQL)
-- =====================================================================

USE productosdb;

-- ---------------------------------------------------------------------
-- 1) Tabla usuarios: de varbinary(64) a VARCHAR(255) para el hash en texto
--    (pasos: ampliar -> convertir cuentas existentes -> pasar a texto)
-- ---------------------------------------------------------------------
ALTER TABLE usuarios MODIFY COLUMN dsPassword VARBINARY(255) NOT NULL;

-- 2) Cuentas existentes: las que tenian la contrasena en texto plano se
--    guardan ahora hasheadas (misma contrasena); las que tenian un SHA-512
--    antiguo sin salt (no recuperable) quedan con la contrasena temporal
--    Temporal123  -> cambiala despues de entrar.
UPDATE usuarios SET dsPassword = 'PBKDF2-SHA256$100000$SL2y+PapRL+Wyh8IEHi8Aw==$On+KW1glfe6Tdeqgo4paSD0Cl0Qr5gBzV1AIbSRpfuQ=' WHERE id = 1;
UPDATE usuarios SET dsPassword = 'PBKDF2-SHA256$100000$DPcuR8IXcrh2BbqDcZ/wOA==$DLbIQr0HxUTgn6bM+4fPB7UNDVvGVQXwFORW+HT/7/k=' WHERE id = 2;
UPDATE usuarios SET dsPassword = 'PBKDF2-SHA256$100000$JxtMzZ9aV8bYfGLySISFaw==$CFYclw/0ZloEYWOCm5SQsdhfsBQwMmg8+NJDsM3FIyM=' WHERE id = 3;
UPDATE usuarios SET dsPassword = 'PBKDF2-SHA256$100000$nq0Z15KGb9odkX1iXETSgQ==$/JdU4hiEMb92VYO8IWFRhHYGwq97vSiihCZJCY8V/CQ=' WHERE id = 7;
UPDATE usuarios SET dsPassword = 'PBKDF2-SHA256$100000$pDF+8/hRXp65mPb1bzXogw==$isYuhhFb+D1xI1vtjjf8LNguhp1WMNHIjdhyBYlzMVs=' WHERE id = 8;
UPDATE usuarios SET dsPassword = 'PBKDF2-SHA256$100000$d4a612rd0fHWNNGW/Ypdgg==$5yRfn8a0fq5rxg0+kCOa8JbHYhi/z8dph0/ncDb3UxE=' WHERE id = 9;

ALTER TABLE usuarios
  MODIFY COLUMN dsPassword VARCHAR(255) CHARACTER SET ascii COLLATE ascii_bin NOT NULL
      COMMENT 'Hash PBKDF2-SHA256$iteraciones$salt(b64)$hash(b64) generado en C# (Negocios.HashService)',
  DROP COLUMN dsSalt;

-- ---------------------------------------------------------------------
-- 3) Procedimientos obsoletos (hasheaban con SHA2 dentro de MySQL)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_ValidarLoginHash;
DROP PROCEDURE IF EXISTS insert_user;

-- ---------------------------------------------------------------------
-- 4) Registro: guarda el hash que ya viene calculado desde C#
--    _codigo: 0 = ok | 1 = usuario o cuenta ya existe | 3 = departamento
--             inexistente | 4 = datos vacios | 99 = error inesperado
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_RegistrarUsuario;
DELIMITER $$
CREATE PROCEDURE sp_RegistrarUsuario(
    IN  _dsId           VARCHAR(50)  CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
    IN  _dsUsuario      VARCHAR(50)  CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
    IN  _dsPasswordHash VARCHAR(255) CHARACTER SET ascii,
    IN  _idDepartamento INT,
    OUT _codigo         INT,
    OUT _idNuevo        INT
)
BEGIN
    DECLARE EXIT HANDLER FOR 1062 BEGIN SET _codigo = 1;  SET _idNuevo = NULL; END;
    DECLARE EXIT HANDLER FOR 1452 BEGIN SET _codigo = 3;  SET _idNuevo = NULL; END;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN SET _codigo = 99; SET _idNuevo = NULL; END;

    SET _codigo = 0;
    SET _idNuevo = NULL;

    IF _dsId IS NULL OR TRIM(_dsId) = ''
       OR _dsUsuario IS NULL OR TRIM(_dsUsuario) = ''
       OR _dsPasswordHash IS NULL OR _dsPasswordHash = '' THEN
        SET _codigo = 4;
    ELSEIF _idDepartamento IS NOT NULL
       AND NOT EXISTS (SELECT 1 FROM departamento WHERE id = _idDepartamento) THEN
        SET _codigo = 3;
    ELSE
        INSERT INTO usuarios (dsId, dsUsuario, dsPassword, idDepartamento, dsUsuarioCreacion)
        VALUES (TRIM(_dsId), TRIM(_dsUsuario), _dsPasswordHash, _idDepartamento, TRIM(_dsUsuario));
        SET _idNuevo = LAST_INSERT_ID();
    END IF;
END$$

-- ---------------------------------------------------------------------
-- 5) Login: devuelve el usuario ACTIVO con su hash; la comparacion de la
--    contrasena la hace C# (IHashService.VerifyPassword), no MySQL.
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_ObtenerUsuarioLogin$$
CREATE PROCEDURE sp_ObtenerUsuarioLogin(
    IN _dsUsuario VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci
)
BEGIN
    SELECT u.id, u.dsId, u.dsUsuario, u.dsPassword, u.dsEstado,
           u.idDepartamento, d.dsDepartamento,
           u.dsUsuarioCreacion, u.dtFechaCreacion
    FROM usuarios u
    LEFT JOIN departamento d ON d.id = u.idDepartamento
    WHERE u.dsUsuario = TRIM(_dsUsuario)
      AND u.dsEstado = '1'
    LIMIT 1;
END$$

-- ---------------------------------------------------------------------
-- 6) Listado para el DataGridView del form principal (nunca devuelve el hash)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_ListarUsuarios$$
CREATE PROCEDURE sp_ListarUsuarios(
    IN _filtro VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci
)
BEGIN
    SELECT u.id                                             AS Id,
           u.dsId                                           AS Cuenta,
           u.dsUsuario                                      AS Usuario,
           IFNULL(d.dsDepartamento, '(Sin departamento)')  AS Departamento,
           IF(u.dsEstado = '1', 'Activo', 'Inactivo')       AS Estado,
           u.dtFechaCreacion                                AS Creado
    FROM usuarios u
    LEFT JOIN departamento d ON d.id = u.idDepartamento
    WHERE _filtro IS NULL OR _filtro = ''
       OR u.dsUsuario LIKE CONCAT('%', _filtro, '%')
       OR u.dsId      LIKE CONCAT('%', _filtro, '%')
    ORDER BY u.id;
END$$

-- ---------------------------------------------------------------------
-- 7) Activar / desactivar usuario
--    _codigo: 0 = ok | 1 = usuario no existe | 2 = estado invalido
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_CambiarEstadoUsuario$$
CREATE PROCEDURE sp_CambiarEstadoUsuario(
    IN  _id            INT,
    IN  _dsEstado      CHAR(1),
    IN  _modificadoPor VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
    OUT _codigo        INT
)
BEGIN
    IF _dsEstado IS NULL OR _dsEstado NOT IN ('0', '1') THEN
        SET _codigo = 2;
    ELSEIF NOT EXISTS (SELECT 1 FROM usuarios WHERE id = _id) THEN
        SET _codigo = 1;
    ELSE
        UPDATE usuarios
           SET dsEstado = _dsEstado,
               dsUsuarioModificacion = IFNULL(_modificadoPor, 'Sistema')
         WHERE id = _id;
        SET _codigo = 0;
    END IF;
END$$
DELIMITER ;
