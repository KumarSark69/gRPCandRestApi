using System.Net;
using EmployeeRest.Models;
using Grpc.Net.Client;
using Newtonsoft.Json;
namespace CommonClient.Rest;
public class GetEmployee
{
    public static async Task GetAllEventData_ByEventID() //Get All Events Records  
    {
        DateTime start;
        DateTime end;
        using (var httpClient = new HttpClient())
        {
            int employeeIdToRetrieve = 1;
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            try
            {
                start = DateTime.Now;
                for (int id = 26002; id < 36002; id++)
                {
                    string apiUrl = $"http://localhost:5270/api/Employee/{id}";
                    var response = await httpClient.GetAsync(apiUrl);
                }
                end = DateTime.Now;
                var actual = (int)(end - start).TotalMilliseconds;
                Console.WriteLine("   ");
                Console.WriteLine($"The total time taken by Get  data by id  is {actual}ms");
                Console.WriteLine("   ");
                // if (response.IsSuccessStatusCode)
                // {
                //     var responseData = await response.Content.ReadAsStringAsync();
                //     var employee = JsonConvert.DeserializeObject<Employee>(responseData);

                //     Console.WriteLine("Employee Data:");
                //     Console.WriteLine($"ID: {employee.Id}");
                //     Console.WriteLine($"Name: {employee.Name}");
                //     Console.WriteLine($"Email: {employee.Email}");
                //     Console.WriteLine($"Address: {employee.Address}");
                // }
                // else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                // {
                //     Console.WriteLine($"Employee with ID {employeeIdToRetrieve} not found.");
                // }
                // else
                // {
                //     Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                // }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
    public static async Task GetAllEventData() //Get All Events Records By ID  
    {
        DateTime start;
        DateTime end;
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5270/api/Employee";
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            try
            {
                start = DateTime.Now;
                var response = await httpClient.GetAsync(apiUrl);
                end = DateTime.Now;
                var actual = (int)(end - start).TotalMilliseconds;
                Console.WriteLine("   ");
                Console.WriteLine($"The total time taken by get data by id is {actual}ms");
                Console.WriteLine("   ");
                // if (response.IsSuccessStatusCode)
                // {
                //     var responseData = await response.Content.ReadAsStringAsync();
                //     var employees = JsonConvert.DeserializeObject<Employee[]>(responseData);

                //     Console.WriteLine("Employee Data:");
                //     foreach (var employee in employees)
                //     {
                //         Console.WriteLine($"ID: {employee.Id}");
                //         Console.WriteLine($"Name: {employee.Name}");
                //         Console.WriteLine($"Email: {employee.Email}");
                //         Console.WriteLine($"Address: {employee.Address}");
                //         Console.WriteLine();
                //     }
                // }
                // else
                // {
                //     Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                // }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}