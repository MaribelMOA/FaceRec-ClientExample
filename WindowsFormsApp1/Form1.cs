using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly FaceRecognitionService faceService = new FaceRecognitionService();
        public Form1()
        {
            InitializeComponent();
            btnIniciar.Visible = true;
            btnTerminar.Visible = false;
            btnCancelar.Visible = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            btnIniciar.Visible = false;

            var result = await faceService.CheckAndRegister();
            if (result != null)
            {
                if(result.allowed)
                {
                    string mensaje1 = "✅ Acceso permitido\nPrimera vez qeu vistia en las pasadas 24h";
                    MessageBox.Show(mensaje1);

                    btnIniciar.Visible = false;
                    btnTerminar.Visible = true;
                    btnCancelar.Visible = true;
                    return;
                }
                else
                {
                    string mensaje = $"⛔ Acceso denegado\nYa visitó en las últimas 24 \nVisits count: {result.visits_count} ";
                    MessageBox.Show(mensaje);
                    btnIniciar.Visible = true;
                    return;
                }
                   
            }
            else
            {
                MessageBox.Show("❌ Error al conectar con la API");
            }

            

        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {

            btnIniciar.Visible = true;
            btnTerminar.Visible = false;
            btnCancelar.Visible = false;
            MessageBox.Show("Gracias por participar!.");

        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {

            var result = await faceService.DeleteLastVisitAsync();

            if (result != null && result.success)
            {
                MessageBox.Show("✅ Última visita eliminada.");
            }
            else
            {
                MessageBox.Show("❌ No se pudo eliminar la visita.");
            }

            btnIniciar.Visible = true;
            btnTerminar.Visible = false;
            btnCancelar.Visible = false;
        }
    }
}
