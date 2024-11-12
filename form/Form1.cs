using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace form
{
    public partial class Form1 : Form
    {
        private operaciones operaciones;
        public Form1()
        {
            InitializeComponent();
            operaciones = new operaciones();
            CargarPersonas();

    }
        private void CargarPersonas()
        {
            SqlDataReader reader = operaciones.MostrarPersonas();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nombre=textBox2.Text;
            string departamento = textBox3.Text;
            string profesion = textBox4.Text;
            int edad = Convert.ToInt32(textBox5.Text);
            operaciones.InsertarPersona(nombre, departamento, profesion, edad);
            MessageBox.Show("Personas insertadas");
            LimpiarCampos();
            CargarPersonas();

        }
        public void LimpiarCampos()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string nombre = textBox2.Text;
            string departamento = textBox3.Text;
            string profesion = textBox4.Text;
            int edad = Convert.ToInt32(textBox5.Text);
            operaciones.ActualizandrPersonas(id, nombre, departamento, profesion, edad);
            MessageBox.Show("Personas actualizada correctament");
            LimpiarCampos();
            CargarPersonas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            operaciones.EliminarPersona(id);    
            MessageBox.Show("Personas eliminada");
            LimpiarCampos();
            CargarPersonas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarPersonas();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
