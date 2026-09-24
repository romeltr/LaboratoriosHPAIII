using Lab4Actividad1;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace Lab4Actividad1
{
    public class Conexion
    {
        private static string cadenaConexion = "Server=localhost;Database=productosdb;Uid=root;Pwd=psswd";
        public static MySqlConnection ObtenerConexion()
        {
            try
            {
                //Crear un tipo de dato de MySQLConnection
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                return (conexion);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
                return null;
            }//fin del catch
        } // fin dle método estático MySqlConnection





        public static List<Producto> GetProductos(string filtro)
        {
            List<Producto> listaProductos = new List<Producto>();
            string query = "SELECT id, nombre, precio, cantidad, imagen FROM productos";
            // Si viene un filtro, modificamos el query de forma segura
            // (Nota: idealmente con parámetros, pero adaptado al ejemplo visual que tienes)
            if (!string.IsNullOrEmpty(filtro))
            {
                query += " WHERE id LIKE @filtro OR nombre LIKE @filtro " +
                " OR precio LIKE @filtro OR cantidad LIKE @filtro";
            }
            using (MySqlConnection conn = ObtenerConexion())
            {
                if (conn == null) return listaProductos;
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Si hay filtro, agregamos el parámetro para evitar inyección SQL
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }
                    // Ejecutamos el lector de datos
                    using (MySqlDataReader mReader = cmd.ExecuteReader())
                    {
                        // Recorremos el lector fila por fila mientras haya registros
                        while (mReader.Read())
                        {
                            Producto prod = new Producto();
                            // Mapeamos los campos de la base de datos a las propiedades de tu clase Producto
                            // (Ajusta los nombres de las columnas o índices según tu base de datos)

                            prod.Id = Convert.ToInt32(mReader["id"]);
                            prod.Nombre = mReader["nombre"].ToString();
                            prod.Precio = Convert.ToDecimal(mReader["precio"]);
                            prod.Cantidad = Convert.ToInt32(mReader["cantidad"]);
                            //prod.Imagen = (byte[])mReader.GetValue(4);
                            prod.Imagen = mReader["imagen"] != DBNull.Value ? (byte[])mReader["imagen"] : null;
                            // Agregamos el objeto listo a la lista genérica
                            listaProductos.Add(prod);
                        }
                        mReader.Close();
                    }//MySqlDataReader
                }// MySqlComman


               

            }

            return listaProductos;
        }

        public static bool InsertSeguro(string tbName, Dictionary<string, object> data)
        {
            var columns = string.Join(", ", data.Keys);
            var placeholders = "@" + string.Join(", @", data.Keys);
            string sql = $"INSERT INTO {tbName} ({columns}) VALUES ({placeholders})";
            try
            {
                // Pedimos la conexión usando nuestra clase externa
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;
                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        foreach (var kvp in data)
                        {
                            stmt.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }
                        stmt.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en INSERT: " + ex.Message);
                return false;
            }
        }//fin del método Insertar Seguro

        public static bool UpdateSeguro(string tbName, Dictionary<string, object> data, string idColumn, int idValue)
        {
            // Construimos la cláusula SET: columna1 = @columna1, columna2 = @columna2...
            var setParts = new List<string>();
            foreach (var key in data.Keys)
            {
                setParts.Add($"{key} = @{key}");
            }
            string setClause = string.Join(", ", setParts);

            // Armamos la consulta SQL completa incluyendo el WHERE
            string sql = $"UPDATE {tbName} SET {setClause} WHERE {idColumn} = @idCondicion";

            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        // Agregamos los parámetros de los campos a actualizar
                        foreach (var kvp in data)
                        {
                            stmt.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }

                        // Agregamos el parámetro para la condición WHERE de forma segura
                        stmt.Parameters.AddWithValue("@idCondicion", idValue);

                        stmt.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en UPDATE: " + ex.Message);
                return false;
            }
        }

        internal static bool UpdateSeguro(string v1, Dictionary<string, object> myProducto, string v2, DataGridViewTextBoxColumn id)
        {
            throw new NotImplementedException();
        }


    }

}