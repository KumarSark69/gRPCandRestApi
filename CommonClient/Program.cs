
using CommonClient.Grpc;
using CommonClient.Rest;

namespace CommonClient;
class Program
{
    public static async Task Main(string[] args)
    {

        // await Rest.AddEmployee.PostEvent_data();
        // await Rest.GetEmployee.GetAllEventData_ByEventID();
        // await Rest.GetEmployee.GetAllEventData();
        // await Rest.EditEmployee.PutEvent_data();
        // await Rest.DeleteEmployee.DeleteEvent_data();


        await Grpc.AddEmployee.AddEmployeesGrpc();
        await Grpc.GetEmployee.GetAllEmployeesByIDGrpc();
        await Grpc.GetEmployee.GetAllEmployeesGrpc();
        await Grpc.EditEmployee.UpdateEmployeesByIDGrpc();
        await Grpc.DeleteEmployee.deleteEmployeeGrpc();
    }
    // public static void GetEmployees()
    // {
    //     var client = new RestClient("http://localhost:5270/api/");
    //     var requesr = new RestRequest("Employee");
    //     var response = client.Execute(requesr);
    // }




}
