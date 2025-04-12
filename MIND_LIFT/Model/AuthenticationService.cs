using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MIND_LIFT.Model
{
    public class FirebaseAuthService
    {
        private const string ApiKey = "AIzaSyCiR3Tm4xJ1FJTzksFWAasjlYRpaRCbLR8"; // Replace with your API key
        private static readonly HttpClient client = new HttpClient();

        public async Task SignInWithEmailPassword(string email, string password)
        {
            var payload = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={ApiKey}",
                content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("✅ Login successful!");
                Console.WriteLine(responseBody); // You can deserialize this if needed
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine("❌ Login failed:");
                Console.WriteLine(error);
            }
        }
    }
}
