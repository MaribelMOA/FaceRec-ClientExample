
namespace WindowsFormsApp1.Models
{
    public class FaceCheckResult
    {
        public bool allowed { get; set; }
        // Estos pueden faltar si ocurre un error 
        public string face_id { get; set; }
        public string external_image_id { get; set; }
        public int visits_count { get; set; }
        public bool registered { get; set; }  // solo se usa si usas check-and-register
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
}
