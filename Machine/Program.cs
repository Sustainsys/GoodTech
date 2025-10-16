using Duende.IdentityModel.Client;
using System.Text.Json;
using static System.Console;

WriteLine("Requesting Access token...");
WriteLine();

HttpClient tokenClient = new();

ClientCredentialsTokenRequest tokenRequest = new()
{
    RequestUri = new("https://localhost:5000/connect/token"),
    ClientId = "m2m",
    ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
    Scope = "api1 api2"
};

var tokenResponse = await tokenClient.RequestClientCredentialsTokenAsync(tokenRequest);

WriteLine($"Token Endpoint Status Code: {(int)tokenResponse.HttpStatusCode}");
WriteLine("Token Response");

var jDoc = JsonDocument.Parse(tokenResponse.Raw!);

var pretty = JsonSerializer.Serialize(
    jDoc, new JsonSerializerOptions() { WriteIndented = true });

WriteLine(pretty);

WriteLine();
WriteLine("Press any key to call api1");
ReadKey(true);

HttpClient apiClient = new();
apiClient.DefaultRequestHeaders.Authorization = new
    ("Bearer", tokenResponse.AccessToken);

WriteLine("Caling Api1...");
WriteLine();

var api1Response = await apiClient.GetAsync("https://localhost:5010/api1");
WriteLine($"Api1 Status Code: {(int)api1Response.StatusCode}");
WriteLine($"Api1 Response: {await api1Response.Content.ReadAsStringAsync()}");


WriteLine();
WriteLine("Press any key to call api3");
ReadKey(true);

var api3Response = await apiClient.GetAsync("https://localhost:5010/api3");
WriteLine($"Api3 Status Code: {(int)api3Response.StatusCode}");
