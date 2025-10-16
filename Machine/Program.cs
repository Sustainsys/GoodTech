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
