using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using CapaNegocio;
using SendGrid;

namespace CapaPresentacion
{
    public partial class insertar : Form
    {
        private bool edicion = false;
        Negocio_Usuario objetoIU = new Negocio_Usuario();
        public insertar()
        {
            InitializeComponent();
        }

        public void EditarUser(string id, string nombre, string fecha_nacimiento, string sexo, bool aux_edicion)
        {
            textBoxId.Text = id;
            textBoxNombre.Text = nombre;
            dateTimePicker1.Value = Convert.ToDateTime(fecha_nacimiento);
            comboBox1.Text = sexo;
            edicion = aux_edicion;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (edicion == false)
            {
                try
                {
                    objetoIU.InsertarUsuario(textBoxId.Text, textBoxNombre.Text, dateTimePicker1.Text, comboBox1.Text);
                    MessageBox.Show("Registro Exitoso");
                    edicion = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede insertar los datos por: " + ex);
                }
            }
            if (edicion == true)
            {
                try
                {
                    objetoIU.EditarUsuario(textBoxId.Text, textBoxNombre.Text, dateTimePicker1.Text, comboBox1.Text);
                    MessageBox.Show("Registro Actualizado");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede editar los datos por: " + ex);
                }
            }
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            Grilla frm = new Grilla();
            frm.Show();
           
        }
    }
}
