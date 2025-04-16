using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using Firebase.Auth;


namespace MIND_LIFT.Services
{
    public class FirebaseAuthService
    {
        // 🔑 Replace this with your real Firebase Web API Key (from Firebase Console → Project Settings)
        private const string ApiKey = "AIzaSyCiR3Tm4xJ1FJTzksFWAasjlYRpaRCbLR8";

        // Reuse a single HttpClient instance (good practice!)
        private readonly HttpClient _httpClient = new();

        // 🚀 Register a new user with Firebase
        public async Task<string> RegisterAsync(string email, string password)
        {
            var request = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var response = await _httpClient.PostAsJsonAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}",
                request);

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var json = JsonDocument.Parse(responseString);
                return json.RootElement.GetProperty("idToken").GetString(); // Auth Token
            }

            throw new Exception($"Registration failed: {responseString}");
        }

        // 🔑 Login an existing user
        public async Task<string> LoginAsync(string email, string password)
        {
            var request = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var response = await _httpClient.PostAsJsonAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={ApiKey}",
                request);

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var json = JsonDocument.Parse(responseString);
                return json.RootElement.GetProperty("idToken").GetString(); // Auth Token
            }

            throw new Exception($"Login failed: {responseString}");
        }

        // New Firebase Auth SDK method
        public async Task<FirebaseAuthLink> SignInWithEmailAndPasswordAsync(string email, string password)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            return await authProvider.SignInWithEmailAndPasswordAsync(email, password);
        }
    }
}
