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

        // 1. POST /capture-and-check
        public async Task<FaceCheckResult> CaptureAndCheckAsync()
        {
            var response = await httpClient.PostAsync($"{baseUrl}/capture-and-check", new StringContent(""));
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FaceCheckResult>(json);
        }

        // 2. POST /register-image?tempFileName=...&realFileName=...
        public async Task<SimpleResult> RegisterImageAsync(string tempFileName, string realFileName)
        {
            var url = $"{baseUrl}/register-image?tempFileName={Uri.EscapeDataString(tempFileName)}&realFileName={Uri.EscapeDataString(realFileName)}";
            var response = await httpClient.PostAsync(url, new StringContent("")); // cuerpo vacío

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SimpleResult>(json);
        }

        // 3. DELETE /delete-tempImage/{tempFileName}
        public async Task<SimpleResult> DeleteTempImageAsync(string tempFileName)
        {
            var url = $"{baseUrl}/delete-tempImage/{Uri.EscapeDataString(tempFileName)}";
            var response = await httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SimpleResult>(json);
        }

        //4

        public async Task<GetImageResponse> GetImageUrlAsync(string fileName)
        {
            var response = await httpClient.GetAsync($"{baseUrl}/get-image?fileName={fileName}");
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetImageResponse>(json);
        }

        // 5. GET /check-camera
        public async Task<SimpleResult> CheckCameraAsync()
        {
            var response = await httpClient.GetAsync($"{baseUrl}/check-camera");
            if (!response.IsSuccessStatusCode)
                return new SimpleResult { success = false, message = "Error checking camera." };

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SimpleResult>(json);
        }

        // 6. GET /check-aws
        public async Task<SimpleResult> CheckAWSAsync()
        {
            var response = await httpClient.GetAsync($"{baseUrl}/check-aws");
            if (!response.IsSuccessStatusCode)
                return new SimpleResult { success = false, message = "Error checking AWS Rekognition." };

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SimpleResult>(json);
        }

        // 7. GET /health
        public async Task<HealthStatusResult> CheckHealthAsync()
        {
            var response = await httpClient.GetAsync($"{baseUrl}/health");
            if (!response.IsSuccessStatusCode)
                return new HealthStatusResult
                {
                    camera_ok = false,
                    aws_ok = false,
                    aws_message = "Health check failed.",
                    timestamp = DateTime.UtcNow
                };

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<HealthStatusResult>(json);
        }

        


    }
}
