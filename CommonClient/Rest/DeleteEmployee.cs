using System.Net;
using EmployeeGrpc;


namespace CommonClient.Rest;
public class DeleteEmployee
{
    public static async Task DeleteEvent_data() //Update Event  
    {
        DateTime start;
        DateTime end;
        using (var httpClient = new HttpClient())
        {
            int employeeIdToDelete = 10018;


            try
            {
                start = DateTime.Now;
                for (int i = 46003; i < 56003; i++)
                {
                    string apiUrl = $"http://localhost:5270/api/Employee/{i}";
                    var response = await httpClient.DeleteAsync(apiUrl);
                }
                end = DateTime.Now;
                var actual = (int)(end - start).TotalMilliseconds;
                Console.WriteLine("   ");
                Console.WriteLine($"The total time taken by delete is {actual}ms");
                Console.WriteLine("   ");
                // if (response.IsSuccessStatusCode)
                // {
                //     Console.WriteLine($"Employee with ID {employeeIdToDelete} deleted successfully.");
                // }
                // else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                // {
                //     Console.WriteLine($"Employee with ID {employeeIdToDelete} not found.");
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