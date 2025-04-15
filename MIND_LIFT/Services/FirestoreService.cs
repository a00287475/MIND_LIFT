using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

namespace MIND_LIFT.Services
{
    class FirestoreService
    {
        private readonly HttpClient _httpClient = new();
        private const string ProjectId = "YOUR_FIREBASE_PROJECT_ID"; // Replace this!

        public async Task AddMoodEntryAsync(string idToken, string userId, string mood, string note)
        {
            var document = new
            {
                fields = new
                {
                    mood = new { stringValue = mood },
                    note = new { stringValue = note },
                    timestamp = new { timestampValue = DateTime.UtcNow.ToString("o") }
                }
            };

            var json = JsonSerializer.Serialize(document);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", idToken);

            var response = await _httpClient.PostAsync(
                $"https://firestore.googleapis.com/v1/projects/{ProjectId}/databases/(default)/documents/users/{userId}/mood_logs",
                content);

            if (!response.IsSuccessStatusCode)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add mood entry: {responseText}");
            }
        }
    }

}
