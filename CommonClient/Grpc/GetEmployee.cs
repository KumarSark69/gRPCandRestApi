using EmployeeGrpc;
using Grpc.Net.Client;
namespace CommonClient.Grpc;
public class GetEmployee
{
    public static async Task GetAllEmployeesGrpc()
    {
        DateTime start;
        DateTime end;

        var channel = GrpcChannel.ForAddress("http://localhost:5064");
        var client = new EmployeeGrpcApi.EmployeeGrpcApiClient(channel);
        start = DateTime.Now;
        var response3 = await client.getEmplyeeGrpcAsync(new Google.Protobuf.WellKnownTypes.Empty());
        end = DateTime.Now;
        // foreach (var res in response3.Request)
        // {
        //     Console.WriteLine($"{res.Id}  {res.Name}  {res.Address}  {res.Email}");
        // }

        await channel.ShutdownAsync();
        Console.WriteLine("   ");
        var actual = (int)(end - start).TotalMilliseconds;
        Console.WriteLine($"The total time taken by get all is {actual}ms");
        Console.WriteLine("   ");
    }
    public static async Task GetAllEmployeesByIDGrpc()
    {
        DateTime start;
        DateTime end;

        var channel = GrpcChannel.ForAddress("http://localhost:5064");
        var client = new EmployeeGrpcApi.EmployeeGrpcApiClient(channel);
        start = DateTime.Now;
        for (int id = 31050; id < 41050; id++)
        {
            var response = await client.getEmplyeeByIDGrpcAsync(new employeeIDRequest { Id = id });
        }
        end = DateTime.Now;
        // Console.WriteLine(response.Id + "  " + response.Name + "  " + response.Address + " " + response.Email);
        await channel.ShutdownAsync();
        Console.WriteLine("   ");
        var actual = (int)(end - start).TotalMilliseconds;
        Console.WriteLine($"The total time taken by get by id is {actual}ms");
        Console.WriteLine("   ");
    }
}