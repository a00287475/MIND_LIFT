using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using MIND_LIFT.Model;

namespace MIND_LIFT.Services


{
    class FirestoreService
    {
        private readonly HttpClient _httpClient = new();
        private const string ProjectId = "mindlift-1f06a"; // Replace this!
        private const string FirebaseApiKey = "AIzaSyCiR3Tm4xJ1FJTzksFWAasjlYRpaRCbLR8";

        public async Task<string> GetUserIdFromTokenAsync(string idToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"https://identitytoolkit.googleapis.com/v1/accounts:lookup?key={FirebaseApiKey}");

            var body = new { idToken = idToken };
            var json = JsonSerializer.Serialize(body);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get user info: {responseText}");
            }

            using var doc = JsonDocument.Parse(responseText);
            var userId = doc.RootElement.GetProperty("users")[0].GetProperty("localId").GetString();
            return userId;
        }

        public async Task AddMoodEntryAsync(string idToken, MoodEntry entry)
        {
            var document = new
            {
                fields = new
                {
                    entryId = new { stringValue = entry.EntryId },
                    userId = new { stringValue = entry.UserId },
                    date = new { timestampValue = entry.Date.ToString("o") },
                    moodScore = new { integerValue = entry.MoodScore.ToString() },
                    emotions = new
                    {
                        arrayValue = new
                        {
                            values = entry.Emotions.Select(e => new { stringValue = e }).ToArray()
                        }
                    },
                    notes = new { stringValue = entry.Notes ?? string.Empty }
                }
            };




            var json = JsonSerializer.Serialize(document);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", idToken);

            var response = await _httpClient.PostAsync(
                $"https://firestore.googleapis.com/v1/projects/{ProjectId}/databases/(default)/documents/users/{entry.UserId}/mood_entries",
                content);

            if (!response.IsSuccessStatusCode)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add mood entry: {responseText}");
            }
        }

    }

}
