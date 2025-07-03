using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;
using Newtonsoft.Json;

namespace WindowsFormsApp1.Services
{
    public class FaceRecognitionService
    {

        private readonly HttpClient httpClient = new HttpClient();
        private readonly string baseUrl = "http://localhost:5116/api/FaceRecognition"; 

        public async Task <FaceCheckResult> CheckAndRegister()
        {
            var response = await httpClient.PostAsync($"{baseUrl}/check-and-register", null);
            if (!response.IsSuccessStatusCode)
                    return null;
            var json =await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FaceCheckResult>(json);

        }

        public async Task<DeleteVisitResult> DeleteLastVisitAsync()
        {
            var response = await httpClient.DeleteAsync($"{baseUrl}/delete-last-visit");
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DeleteVisitResult>(json);
        }

    }
}
