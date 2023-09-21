using System.Net;
using EmployeeRest.Models;
using Newtonsoft.Json;


namespace CommonClient.Rest;
public class AddEmployee
{
    public static async Task PostEvent_data() //Adding Event  
    {
        DateTime start;
        DateTime end;
        using (var httpClient = new HttpClient())
        {
            Employee employee = new Employee
            {
                Name = "JohnDoe",
                Email = "johndoe@example.com",
                Address = "123 Main St"
            };

            string apiUrl = "http://localhost:5270/api/Employee";

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            try
            {
                start = DateTime.Now;
                for (int i = 0; i < 10000; i++)
                {
                    var jsonPayload = JsonConvert.SerializeObject(employee);

                    var response = await httpClient.PostAsync(apiUrl, new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json"));

                }
                end = DateTime.Now;

                var actual = (int)(end - start).TotalMilliseconds;
                Console.WriteLine("   ");
                Console.WriteLine($"The total time taken by add is {actual}ms");
                Console.WriteLine("   ");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


    }
}
