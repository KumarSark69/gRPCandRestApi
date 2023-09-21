using EmployeeGrpc;
using Grpc.Net.Client;

namespace CommonClient.Grpc;
public class DeleteEmployee
{
    public static async Task deleteEmployeeGrpc()
    {
        DateTime start;
        DateTime end;

        var channel = GrpcChannel.ForAddress("http://localhost:5064");
        var client = new EmployeeGrpcApi.EmployeeGrpcApiClient(channel);
        start = DateTime.Now;
        for (int id = 71089; id < 81089; id++)
        {
            var response = await client.deleteEmplyeeAsync(new employeeIDRequest { Id = id });
            // Console.WriteLine(response.Id);
        }

        end = DateTime.Now;

        await channel.ShutdownAsync();

        var actual = (int)(end - start).TotalMilliseconds;
        Console.WriteLine("   ");
        Console.WriteLine($"The total time taken by delete is {actual}ms");
        Console.WriteLine("   ");

    }
}