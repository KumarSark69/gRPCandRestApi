using EmployeeGrpc;
using Grpc.Net.Client;

namespace CommonClient.Grpc;
public class EditEmployee
{
    public static async Task UpdateEmployeesByIDGrpc()
    {
        DateTime start;
        DateTime end;

        var channel = GrpcChannel.ForAddress("http://localhost:5064");
        var client = new EmployeeGrpcApi.EmployeeGrpcApiClient(channel);
        start = DateTime.Now;
        for (int id = 31050; id < 41050; id++)
        {
            var response = await client.updateEmplyeeAsync(new updateEmployeeRequest { Id = id, Name = "Changed", Address = "ChangePura", Email = "change@example.com" });
        }
        end = DateTime.Now;
        // Console.WriteLine(response.Id);
        await channel.ShutdownAsync();
        Console.WriteLine("   ");
        var actual = (int)(end - start).TotalMilliseconds;
        Console.WriteLine($"The total time taken by edit is {actual}ms");
        Console.WriteLine("   ");
    }
}