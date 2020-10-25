using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class Negocio_Usuario
    {
        private ConsultaUsuario objetoCU = new ConsultaUsuario();

        public DataTable MostrarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCU.Mostrar();
            return tabla;
        }

        public void InsertarUsuario(string Id, string Nombre, string fecha_Nacimiento, string sexo)
        {
            objetoCU.Insertar(Convert.ToInt32(Id),Nombre, Convert.ToDateTime(fecha_Nacimiento),sexo);
        }

        public void EditarUsuario(string Id, string Nombre, string fecha_Nacimiento, string sexo)
        {
            objetoCU.EditarUsuario(Convert.ToInt32(Id), Nombre, Convert.ToDateTime(fecha_Nacimiento), sexo);

        }
        public void EliminarUsuario(string Id)
        {
            objetoCU.EliminarUsuario(Convert.ToInt32(Id));
        }
    }
}
