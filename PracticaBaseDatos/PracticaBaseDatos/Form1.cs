using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Controlador;
namespace PracticaBaseDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int matricula = int.Parse(txtMatricula.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string sexo = txtSexo.Text;
            int clave = int.Parse(txtClave.Text);

            string sql = "INSERT INTO estudiante (id, nombre, apellido, sexo, idempresa) VALUES ('"+ matricula+"', '" + nombre+"','" + apellido+"','" + sexo+"','" + clave+"')";

            MySqlConnection conexionBD = Controlador.ControladorConexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Alumno guardado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar Alumno: "+ ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int matricula = int.Parse(txtMatricula.Text);
            MySqlDataReader reader = null;
            
            string sql = "SELECT estudiante.nombre, estudiante.apellido, " +
                "empresa.nombre from estudiante,empresa WHERE estudiante.idempresa = empresa.id " +
                "and estudiante.id= '"+matricula+"'";

            MySqlConnection conexionBD = Controlador.ControladorConexion.conexion();
            conexionBD.Open();

            try{
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Alumno encontrado");
                        txtNombre.Text = reader.GetString(0);
                        txtApellido.Text = reader.GetString(1);
                        txtEmpresa.Text = reader.GetString(2);

                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                } 

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar Alumno: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int matricula = int.Parse(txtMatricula.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string sexo = txtSexo.Text;
            int clave = int.Parse(txtClave.Text);

            string sql = "UPDATE estudiante SET nombre='"+nombre+"', apellido='"+apellido+"', sexo='"+sexo+"', idempresa='"+clave+"' WHERE id='"+matricula+"'";

            MySqlConnection conexionBD = Controlador.ControladorConexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Alumno modificado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar Alumno: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int matricula = int.Parse(txtMatricula.Text);
            string sql = "DELETE FROM estudiante WHERE id='" + matricula + "'";
            MySqlConnection conexionBD = Controlador.ControladorConexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Alumno eliminado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar Alumno: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtMatricula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtSexo.Text = "";
            txtClave.Text = "";
            txtEmpresa.Text = "";
        }

        private void btnNewVentana_Click(object sender, EventArgs e)
        {
            Vista.Form2 formulario = new Vista.Form2();
            formulario.Show();
        }
    }
}
