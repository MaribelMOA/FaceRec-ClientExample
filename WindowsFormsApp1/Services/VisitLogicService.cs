using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services
{
    internal class VisitLogicService
    {
        private const float TipoCambio = 18.5f;

        public static int ObtenerIdVisitante(string faceId, string externalId)
        {
            var visitantes = DataService.LeerVisitantes();
            var visitante = visitantes.FirstOrDefault(v => v.faceId == faceId && v.externalImageId == externalId);
            if (visitante != null) return visitante.id;

            int nuevoId = visitantes.Any() ? visitantes.Max(v => v.id) + 1 : 1;
            visitantes.Add(new Visitante { id = nuevoId, faceId = faceId, externalImageId = externalId });
            DataService.GuardarVisitantes(visitantes);
            return nuevoId;
        }

        public static float CalcularMontoAcumuladoDelDia(int visitanteId)
        {
            var visitas = DataService.LeerVisitas();
            var hoy = DateTime.Today;

            var visitasDeHoy = visitas
                .Where(v => v.visitante_id == visitanteId && v.created_at.Date == hoy)
                .ToList();

            float total = 0f;

            foreach (var v in visitasDeHoy)
            {
                if (v.tipo == "compra")
                {
                    total += v.monto; // USD
                }
                else if (v.tipo == "venta")
                {
                    total += v.monto / TipoCambio; // Convertido a USD
                }
            }

            return total;
        }

        public static void RegistrarNuevaVisita(int visitanteId, string tipo, float monto, string imagePath)
        {
            var visitas = DataService.LeerVisitas();
            visitas.Add(new Visita
            {
                id = visitas.Any() ? visitas.Max(v => v.id) + 1 : 1,
                visitante_id = visitanteId,
                tipo = tipo,
                monto = monto,
                image_path = imagePath,
                created_at = DateTime.Now
            });
            DataService.GuardarVisitas(visitas);
        }
    }
}
