using HttpClientStarter;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

HttpClient client = new HttpClient();

string url = "https://localhost:7010/WeatherForecast";

while (true)
{
    Console.WriteLine("\nA. GET");
    Console.WriteLine("B. POST");
    Console.WriteLine("C. PUT");
    Console.WriteLine("D. DELETE");
    Console.WriteLine("E. GET ID");
    Console.WriteLine("F.EXIT");

    Console.Write("Choice: ");

    string choice = Console.ReadLine()!.ToUpper();

    HttpResponseMessage response;

    switch (choice.ToUpper())
    {
        case "A":
            response = await client.GetAsync(url);
            break;

        case "B":
            var postRequest = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 30,
                TemperatureF = 86,
                Summary = "Sunny"
            };

            string postJson = JsonSerializer.Serialize(postRequest);

            Console.WriteLine("\nRequest Body:");
            Console.WriteLine(postJson);

            var postBody = new StringContent(
                postJson,
                Encoding.UTF8,
                "application/json");

            response = await client.PostAsync(url, postBody);
            break;

        case "C":
            Console.Write("Enter ID: ");
            int putId = int.Parse(Console.ReadLine()!);

            var putRequest = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 20,
                TemperatureF = 68,
                Summary = "Rainy"
            };

            string putJson = JsonSerializer.Serialize(putRequest);

            Console.WriteLine("\nRequest Body:");
            Console.WriteLine(putJson);

            var putBody = new StringContent(
                putJson,
                Encoding.UTF8,
                "application/json");

            response = await client.PutAsync($"{url}/put/{putId}", putBody);
            break;

        case "D":
            Console.Write("Enter ID: ");
            int deleteId = int.Parse(Console.ReadLine()!);

            response = await client.DeleteAsync($"{url}/delete/{deleteId}");
            break;

        case "E":
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine()!);

            response = await client.GetAsync($"{url}/{id}");
            break;

        case "F":
            return;

        default:
            Console.WriteLine("Invalid choice.");
            continue;
    }

    Console.WriteLine($"\nStatus Code: {(int)response.StatusCode}");
    Console.WriteLine($"Status: {response.StatusCode}");
    Console.WriteLine($"Is Success: {response.IsSuccessStatusCode}");
    Console.WriteLine($"Raw Response: {response}");

    string body = await response.Content.ReadAsStringAsync();

    Console.WriteLine("\nResponse Body:");
    Console.WriteLine(body);
}