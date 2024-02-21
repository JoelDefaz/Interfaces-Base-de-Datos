﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces_Base_de_Datos
{
    public partial class frmConsultarConParámetro : Form
    {
        private string parametro;
        string strConn = "Data Source=(Local); database=Facturación; Integrated Security=SSPI";
        string strComm = null;
        SqlConnection conn = null;
        SqlCommand comm = null;

        public frmConsultarConParámetro(string parametro, int v)
        {
            InitializeComponent();
            this.parametro = parametro;
            activarCajasDeTexto(v);
        }

        private void activarCajasDeTexto(int v)
        {
            if (v == 0)
            {
                txtParámetroParaConsultar.Enabled = true;
            }
            else
            {
                txtParametroNumero.Enabled = true;
                comboBoxNumeros.Enabled = true;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmConsultar consultar = new frmConsultar();
            consultar.ShowDialog();
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string condicion = "";
            using (conn = new SqlConnection(strConn))
            {
                condicion = obtenerCondicion(comboBoxNumeros);
                conn.Open();
                switch (parametro)
                {
                    case "Código":
                        strComm = "SELECT FROM Productos WHERE id_producto" + condicion + txtParametroNumero.Text;
                        using (comm = new SqlCommand(strComm, conn))
                        {
                            mensajeDeVerificación(comm.ExecuteNonQuery());
                        }
                        break;
                    case "Nombre":
                        strComm = "SELECT FROM Productos WHERE nombre_prod LIKE '%" + txtParámetroParaConsultar.Text + "%'";
                        using (comm = new SqlCommand(strComm, conn))
                        {
                            mensajeDeVerificación(comm.ExecuteNonQuery());
                        }
                        break;
                    case "Precio":
                        strComm = "SELECT FROM Productos WHERE precio_unit" + condicion + txtParametroNumero.Text;
                        using (comm = new SqlCommand(strComm, conn))
                        {
                            mensajeDeVerificación(comm.ExecuteNonQuery());
                        }
                        break;
                    case "Unidad":
                        strComm = "SELECT FROM Productos WHERE unidad" + condicion + txtParametroNumero.Text;
                        using (comm = new SqlCommand(strComm, conn))
                        {
                            mensajeDeVerificación(comm.ExecuteNonQuery());
                        }
                        break;
                    case "Código Proveedor":
                        strComm = "SELECT FROM Productos WHERE id_proveedor" + condicion + txtParametroNumero.Text;
                        using (comm = new SqlCommand(strComm, conn))
                        {
                            mensajeDeVerificación(comm.ExecuteNonQuery());
                        }
                        break;
                    case "Código Tipo":
                        strComm = "SELECT FROM Productos WHERE id_tipo" + condicion + txtParametroNumero.Text;
                        using (comm = new SqlCommand(strComm, conn))
                        {
                            mensajeDeVerificación(comm.ExecuteNonQuery());
                        }
                        break;
                }
                txtParámetroParaConsultar.Text = "";
            }
        }

        private string obtenerCondicion(ComboBox comboBoxNumeros)
        {
            string condicion = "";
            switch (comboBoxNumeros.SelectedIndex)
            {
                case 0:
                    condicion = " = ";
                    break;
                case 1:
                    condicion = " > ";
                    break;
                case 2:
                    condicion = " < ";
                    break;
                case 3:
                    condicion = " >= ";
                    break;
                case 4:
                    condicion = " <= ";
                    break;
                default:
                    if (comboBoxNumeros.Enabled == true)
                    {
                        MessageBox.Show("Tiene que escoger una condición", "Mensaje", MessageBoxButtons.OK);
                    }
                    break;

            }
            return condicion;
        }

        private void mensajeDeVerificación(int v)
        {
            if (v >= 1)
            {
                MessageBox.Show("Producto presentado con éxito", "Mensaje", MessageBoxButtons.OK);
            }
        }

        private void txtParámetroParaConsultar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtParámetroParaConsultar.Text = "";
            txtParametroNumero.Text = "";
        }

        private void frmConsultarConParámetro_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}