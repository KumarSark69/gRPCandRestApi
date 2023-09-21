using System.Net;
using EmployeeRest.Models;
using Newtonsoft.Json;

namespace CommonClient.Rest;
public class EditEmployee
{
    public static async Task PutEvent_data() //Update Event  
    {
        DateTime start;
        DateTime end;

        using (var httpClient = new HttpClient())
        {
            int employeeIdToUpdate = 10123;

            try
            {

                start = DateTime.Now;
                for (int id = 26002; id < 36002; id++)
                {
                    string apiUrl = $"http://localhost:5270/api/Employee/{id}";


                    var updatedEmployee = new Employee
                    {
                        Id = id,
                        Name = "Updated Name",
                        Email = "updated@example.com",
                        Address = "Updated Address"
                    };
                    var jsonPayload = JsonConvert.SerializeObject(updatedEmployee);
                    var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync(apiUrl, content);
                }
                end = DateTime.Now;
                var actual = (int)(end - start).TotalMilliseconds;
                Console.WriteLine("   ");
                Console.WriteLine($"The total time taken by edit is {actual}ms");
                Console.WriteLine("   ");
                // if (response.IsSuccessStatusCode)
                // {
                //     Console.WriteLine($"Employee with ID {employeeIdToUpdate} updated successfully.");
                // }
                // else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                // {
                //     Console.WriteLine($"Employee with ID {employeeIdToUpdate} not found.");
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