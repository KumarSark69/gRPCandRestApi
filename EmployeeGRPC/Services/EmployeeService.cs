using EmployeeGrpc;
using EmployeeGRPC.Data;
using EmployeeGRPC.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace EmployeeGRPC.Services;
class EmployeeService : EmployeeGrpcApi.EmployeeGrpcApiBase
{
    private readonly EmployeeDbContext _db;
    public EmployeeService(EmployeeDbContext db)
    {
        _db = db;
    }
    public override async Task<addResponse> addEmplyee(addRequest request, ServerCallContext context)
    {
        Employee employee = new Employee()
        {

            Address = request.Address,
            Name = request.Name,
            Email = request.Email
        };
        await _db.EmployeeList.AddAsync(employee);
        await _db.SaveChangesAsync();
        return await Task.FromResult(new addResponse
        {
            StatusCode = 200,
            Message = "Success"
        }
        );
    }
    public override async Task<employeeListResponse> getEmplyeeGrpc(Empty request, ServerCallContext context)
    {
        var employeeList = new employeeListResponse();
        var employees = await _db.EmployeeList.ToListAsync();
        foreach (var employee in employees)
        {
            employeeList.Request.Add(new employeeIdResponse
            {
                Id = (int)employee.Id,
                Address = employee.Address,
                Name = employee.Name,
                Email = employee.Email
            });
        }

        return await Task.FromResult(employeeList);
    }
    public override async Task<employeeIdResponse> getEmplyeeByIDGrpc(employeeIDRequest request, ServerCallContext context)
    {
        if (request.Id <= 0)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "resouce index must be greater than 0"));
        var employees = await _db.EmployeeList.FirstOrDefaultAsync(t => t.Id == request.Id);
        if (employees != null)
        {
            return await Task.FromResult(new employeeIdResponse
            {
                Id = (int)employees.Id,
                Name = employees.Name,
                Address = employees.Address,
                Email = employees.Email

            });
        }

        throw new RpcException(new Status(StatusCode.NotFound, $"No Task with id {request.Id}"));
    }
    public override async Task<updateEmployeeResponse> updateEmplyee(updateEmployeeRequest request, ServerCallContext context)
    {
        if (request.Id <= 0)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "You must suppply a valid object"));
        var employee = await _db.EmployeeList.FirstOrDefaultAsync(t => t.Id == request.Id);
        if (employee == null)
            throw new RpcException(new Status(StatusCode.NotFound, $"No Employee with Id {request.Id}"));
        employee.Name = request.Name;
        employee.Address = request.Address;
        employee.Email = request.Email;
        // await _db.EmployeeList.UpdateAsync(employee);
        await _db.SaveChangesAsync();
        return new updateEmployeeResponse { Id = request.Id };
    }
    public override async Task<updateEmployeeResponse> deleteEmplyee(employeeIDRequest request, ServerCallContext context)
    {
        if (request.Id <= 0)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "You must suppply a valid object"));
        var employee = await _db.EmployeeList.FirstOrDefaultAsync(t => t.Id == request.Id);
        if (employee == null)
            throw new RpcException(new Status(StatusCode.NotFound, $"No Employee with Id {request.Id}"));
        _db.Remove(employee);
        await _db.SaveChangesAsync();
        return new updateEmployeeResponse { Id = (int)employee.Id };

    }
}