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

        public async Task<GetImageResponse> GetImageUrlAsync(string fileName)
        {
            var response = await httpClient.GetAsync($"{baseUrl}/get-image?fileName={fileName}");
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetImageResponse>(json);
        }

    }
}
