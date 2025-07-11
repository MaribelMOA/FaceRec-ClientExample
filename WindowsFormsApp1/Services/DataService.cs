using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services
{
    internal class DataService
    {
        private static readonly string visitantesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "visitantes.json");
        private static readonly string visitasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "visitas.json");

        public static List<Visitante> LeerVisitantes()
        {
            if (!File.Exists(visitantesPath)) return new List<Visitante>();
            var json = File.ReadAllText(visitantesPath);
            return JsonConvert.DeserializeObject<List<Visitante>>(json);
        }

        public static void GuardarVisitantes(List<Visitante> visitantes)
        {
            var json = JsonConvert.SerializeObject(visitantes, Formatting.Indented);
            File.WriteAllText(visitantesPath, json);
        }
        public static List<Visita> LeerVisitas()
        {
            if (!File.Exists(visitasPath)) return new List<Visita>();
            var json = File.ReadAllText(visitasPath);
            return JsonConvert.DeserializeObject<List<Visita>>(json);
        }

        public static void GuardarVisitas(List<Visita> visitas)
        {
            var json = JsonConvert.SerializeObject(visitas, Formatting.Indented);
            File.WriteAllText(visitasPath, json);
        }
    }
}
