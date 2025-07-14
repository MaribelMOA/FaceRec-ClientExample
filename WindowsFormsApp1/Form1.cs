using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Services;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private FaceCheckResult currentResult;
        private string visitantesPath = "visitantes.json";
        private string visitasPath = "visitas.json";

        private readonly FaceRecognitionService faceService = new FaceRecognitionService();


        // Constructor y todo
        public Form1()
        {
            InitializeComponent();
            btnIniciar.Visible = true;

            btnTerminar.Visible = false;
            btnCancelar.Visible = false;

            txtMonto.Visible = false;

            rbCompra.Visible = false;
            rbVenta.Visible = false;

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            currentResult = await faceService.CaptureAndCheckAsync();
            if (currentResult == null || currentResult.message!= null)
            {
                MessageBox.Show("No se pudo capturar o verificar el rostro:");
                return;
            }

            btnIniciar.Visible = false;
            btnTerminar.Visible = true;
            btnCancelar.Visible = true;
            txtMonto.Visible = true;
            rbCompra.Visible = true;
            rbVenta.Visible = true;

        }

        private async void btnTerminar_Click(object sender, EventArgs e)
        {

            // Validar tipo y monto
            string tipo = rbCompra.Checked ? "compra" : rbVenta.Checked ? "venta" : null;
            if (tipo == null || string.IsNullOrWhiteSpace(txtMonto.Text) || !float.TryParse(txtMonto.Text, out float monto))
            {
                MessageBox.Show("Selecciona un tipo y un monto válido.");
                return;
            }

            // 1. Obtener o crear visitante
            int visitanteId = VisitLogicService.ObtenerIdVisitante(currentResult.face_id, currentResult.external_image_id);

            // 2. Calcular monto acumulado hoy
            float totalUsd = VisitLogicService.CalcularMontoAcumuladoDelDia(visitanteId);
            float nuevoMonto = tipo == "compra" ? monto : monto / 18.5f;
            totalUsd += nuevoMonto;

            if (totalUsd > 999)
            {
                MessageBox.Show("🚨 Monto acumulado excede los $999 USD. Por favor regístrate.");
                return;
            }

            // 3. Registrar imagen y guardar visita
            string ordenId = $"orden_{Guid.NewGuid().ToString().Substring(0, 8)}";
            var result = await faceService.RegisterImageAsync(currentResult.image_file_path, ordenId);

            if (string.IsNullOrWhiteSpace(result?.imageUrl))
            {
                MessageBox.Show("❌ No se pudo registrar la imagen: ");
                return;
            }

            VisitLogicService.RegistrarNuevaVisita(visitanteId, tipo, monto, result.imageUrl);

            MessageBox.Show("✅ Visita registrada correctamente.");
            ResetFormulario();

        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {

            if (currentResult != null)
            {
                await faceService.DeleteTempImageAsync(currentResult.image_file_path);
                MessageBox.Show("Imagen temporal eliminada. No se guardo nada de lo que acaba de hacer");
            }
            ResetFormulario();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }


        ////AUXILIARES
        private T LeerJson<T>(string path)
        {
            if (!File.Exists(path)) return default;
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void GuardarJson<T>(string path, T data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        private void ResetFormulario()
         {
            btnIniciar.Visible = true;
            btnTerminar.Visible = false;
            btnCancelar.Visible = false;
            txtMonto.Visible = false;
            rbCompra.Visible = false;
            rbVenta.Visible = false;
            txtMonto.Text = "";
            rbCompra.Checked = false;
            rbVenta.Checked = false;
            currentResult = null;
         }
    }
}
