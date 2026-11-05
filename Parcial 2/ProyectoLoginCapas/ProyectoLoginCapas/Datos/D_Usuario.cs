using System;
using System.Data;
using Entidades;
using MySql.Data.MySqlClient;

namespace Datos
{

    /// Acceso a datos de la entidad usuario mediante procedimientos almacenados.
   
    public class D_Usuario : D_Conexion
    {
   
        /// Devuelve el usuario ACTIVO con ese nombre, incluyendo su hash en dsPassword,
        /// o null si no existe / esta inactivo. La verificacion la hace la capa de negocio.
       
        public static E_Usuario ObtenerParaLogin(string dsUsuario)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            using (MySqlCommand cmd = new MySqlCommand("sp_ObtenerUsuarioLogin", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_dsUsuario", dsUsuario);
                conexion.Open();

                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    if (!r.Read())
                        return null;

                    int ordDepto = r.GetOrdinal("idDepartamento");
                    int ordNomDepto = r.GetOrdinal("dsDepartamento");

                    return new E_Usuario
                    {
                        id = r.GetInt32("id"),
                        dsId = r.GetString("dsId"),
                        dsUsuario = r.GetString("dsUsuario"),
                        dsPassword = r.GetString("dsPassword"),
                        dsEstado = r.GetString("dsEstado")[0],
                        idDepartamento = r.IsDBNull(ordDepto) ? (int?)null : r.GetInt32(ordDepto),
                        dsDepartamento = r.IsDBNull(ordNomDepto) ? null : r.GetString(ordNomDepto),
                        dsUsuarioCreacion = r.GetString("dsUsuarioCreacion"),
                        dtFechaCreacion = r.GetDateTime("dtFechaCreacion")
                    };
                }
            }
        }

        /// Inserta el usuario con el hash ya calculado.
        /// codigo: 0 ok, 1 usuario/cuenta repetido, 3 departamento inexistente, 4 datos vacios, 99 error.
     
        public static void Registrar(string dsId, string dsUsuario, string dsPasswordHash,
                                     int? idDepartamento, out int codigo, out int idNuevo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarUsuario", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("_dsId", dsId);
                cmd.Parameters.AddWithValue("_dsUsuario", dsUsuario);
                cmd.Parameters.AddWithValue("_dsPasswordHash", dsPasswordHash);
                cmd.Parameters.AddWithValue("_idDepartamento",
                    idDepartamento.HasValue ? (object)idDepartamento.Value : DBNull.Value);

                MySqlParameter pCodigo = new MySqlParameter("_codigo", MySqlDbType.Int32);
                pCodigo.Direction = ParameterDirection.Output;
                MySqlParameter pIdNuevo = new MySqlParameter("_idNuevo", MySqlDbType.Int32);
                pIdNuevo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pCodigo);
                cmd.Parameters.Add(pIdNuevo);

                conexion.Open();
                cmd.ExecuteNonQuery();

                codigo = Convert.ToInt32(pCodigo.Value);
                idNuevo = (pIdNuevo.Value == null || pIdNuevo.Value == DBNull.Value)
                    ? 0 : Convert.ToInt32(pIdNuevo.Value);
            }
        }

        /// Lista de departamentos (id, dsDepartamento) para el combo del registro.
        public static DataTable ListarDepartamentos()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            using (MySqlCommand cmd = new MySqlCommand("sp_ListarDepartamentos", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable tabla = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(tabla);
                }
                return tabla;
            }
        }

        /// Usuarios para el DataGridView (nunca incluye el hash). filtro vacio = todos.
        public static DataTable ListarUsuarios(string filtro)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            using (MySqlCommand cmd = new MySqlCommand("sp_ListarUsuarios", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_filtro", string.IsNullOrWhiteSpace(filtro) ? "" : filtro.Trim());
                DataTable tabla = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(tabla);
                }
                return tabla;
            }
        }

        /// Activa ('1') o desactiva ('0') un usuario. codigo: 0 ok, 1 no existe, 2 estado invalido.
        public static int CambiarEstado(int idUsuario, char estado, string modificadoPor)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            using (MySqlCommand cmd = new MySqlCommand("sp_CambiarEstadoUsuario", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_id", idUsuario);
                cmd.Parameters.AddWithValue("_dsEstado", estado.ToString());
                cmd.Parameters.AddWithValue("_modificadoPor", modificadoPor);

                MySqlParameter pCodigo = new MySqlParameter("_codigo", MySqlDbType.Int32);
                pCodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pCodigo);

                conexion.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(pCodigo.Value);
            }
        }
    }
}
