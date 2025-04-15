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
