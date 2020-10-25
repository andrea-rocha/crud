using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConsultaUsuario
    {
        private conexion conexion = new conexion();
        SqlDataReader leer; //leer filas de tabla Usuario
        DataTable tabla = new DataTable();//almacenar filas 
        SqlCommand comando = new SqlCommand();//ejecuta las instrucciones SQL

        public DataTable Mostrar()
        { //SQL TRANSACT PROCEDURE
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(int Id,string Nombre,DateTime fecha_Nacimiento,string sexo)
        {
            
            //abrir conexion 
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id",Id);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento",fecha_Nacimiento);
            comando.Parameters.AddWithValue("@sexo", sexo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void EditarUsuario(int Id, string Nombre, DateTime fecha_Nacimiento, string sexo)
        {
           
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", fecha_Nacimiento);
            comando.Parameters.AddWithValue("@sexo", sexo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

         public void EliminarUsuario (int Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarUsuario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }

    
}
