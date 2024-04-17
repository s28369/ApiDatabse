using System;
using System.Net.Http;
using System.Data.SqlClient;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=apbd;User Id=SA;Password=248652Alexey;";
        SqlConnection connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        using SqlCommand command = new SqlCommand("SELECT * FROM Animal", connection);
        using SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Console.WriteLine($"{reader["Name"]}, {reader["Description"]}");
        }

        // using HttpClient client = new HttpClient();
        // HttpResponseMessage response = await client.GetAsync("YourApiEndpoint");
        // if (response.IsSuccessStatusCode)
        // {
        //     string apiResponse = await response.Content.ReadAsStringAsync();
        //     Console.WriteLine(apiResponse);
        // }
        // else
        // {
        //     Console.WriteLine($"API request failed with status code {response.StatusCode}");
        // }
    }
}