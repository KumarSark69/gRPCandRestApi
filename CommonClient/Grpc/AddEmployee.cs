using EmployeeGrpc;
using Grpc.Net.Client;

namespace CommonClient.Grpc;
public class AddEmployee
{

    public static async Task AddEmployeesGrpc()
    {
        DateTime start;
        DateTime end;

        var channel = GrpcChannel.ForAddress("http://localhost:5064");
        var client = new EmployeeGrpcApi.EmployeeGrpcApiClient(channel);
        start = DateTime.Now;
        for (int i = 0; i < 10000; i++)
        {
            var response = await client.addEmplyeeAsync(new addRequest { Address = "Abcbad", Email = "Abc@example.com", Name = "Abc" });
        }


        end = DateTime.Now;
        // Console.WriteLine(response.StatusCode.ToString() + " " + response.Message);
        await channel.ShutdownAsync();
        Console.WriteLine("   ");
        var actual = (int)(end - start).TotalMilliseconds;
        Console.WriteLine($"The total time taken by add is {actual}ms");
        Console.WriteLine("   ");

    }
}