using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using SendGrid;

namespace CapaPresentacion
{
    public partial class Grilla : Form
    {
        
        Negocio_Usuario objetoCU = new Negocio_Usuario();

        public Grilla()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarUsuario();
        }
        private void MostrarUsuario()
        {
            Negocio_Usuario objeto= new Negocio_Usuario();
            dataGridView1.DataSource = objeto.MostrarUsuario();

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                insertar frm2 = new insertar();
                frm2.EditarUser(
                    dataGridView1.CurrentRow.Cells["Id"].Value.ToString(),
                    dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString(),
                    dataGridView1.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString(),
                    dataGridView1.CurrentRow.Cells["sexo"].Value.ToString(),
                    true
                    );
                frm2.Show();
                this.Close();
            }
            else
                MessageBox.Show("Seleccione la fila a editar");
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                objetoCU.EliminarUsuario(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
                MessageBox.Show("Usuario Eliminado");
                this.Close();
                MostrarUsuario();
            }
            else
                MessageBox.Show("Seleccione la fila a eliminar");
        }
    }
}
