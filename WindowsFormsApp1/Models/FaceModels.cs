
using System;

namespace WindowsFormsApp1.Models
{
    public class FaceCheckResult
    {
       // public bool allowed { get; set; }
        // Estos pueden faltar si ocurre un error 
        public string face_id { get; set; }
        public string external_image_id { get; set; }
       // public int visits_count { get; set; }
        public string image_file_path { get; set; }
        // Este solo viene si hubo un error
        public string message { get; set; }
    }

    public class FaceVisit
    {
        public string faceId { get; set; }
        public string externalImageId { get; set; }
    }
    public class DeleteVisitResult
    {
        public bool success { get; set; }
        public string message { get; set; }
    }

    /////////////////////////////////////////


    public class SimpleResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string imageUrl { get; set; } // Solo se usa en RegisterImage
    }

    public class GetImageResponse
    {
        public bool success { get; set; }
        public string url { get; set; }
        public string message { get; set; }
    }
    /////////////////////////////////////
    ///
    public class Visitante
    {
        public int id { get; set; }
        public string faceId { get; set; }
        public string externalImageId { get; set; }
    }

    public class Visita
    {
        public int id { get; set; }
        public int visitante_id { get; set; }
        public string image_path { get; set; }
        public string tipo { get; set; } // "compra" o "venta"
        public float monto { get; set; }
        public DateTime created_at { get; set; }
    }




}
