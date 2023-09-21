using EmployeeRest.Data;
using EmployeeRest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRest.Controllers;
[Route("api/Employee")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeDbContext _db;
    public EmployeeController(EmployeeDbContext db)
    {
        _db = db;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {

        return Ok(_db.EmployeeList.ToList());
    }
    [HttpGet("{id:int}", Name = "GetEmployees")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Employee> GetEmployeeById(int id)
    {

        if (id <= 0)
        {

            return BadRequest();
        }
        var result = _db.EmployeeList.FirstOrDefault(u => u.Id == id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    [HttpPost]//to create or insert
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public ActionResult<Employee> CreateEmployee([FromBody] Employee emp)
    {
        //It helps the annotation of the proprties of the class when there is no ApiController
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        // if (_db.EmployeeList.FirstOrDefault(u => u.Name.ToLower() == emp.Name.ToLower()) != null)//Checking the validiation for unique name
        // {
        //     ModelState.AddModelError("CustomError", "Employee Already Exist");         //Creating the custom error message for same name
        //     return BadRequest(ModelState);
        // }

        if (emp == null)
        {
            return BadRequest();
        }

        Employee model = new()
        {

            Address = emp.Address,
            Email = emp.Email,
            Name = emp.Name
        };
        _db.EmployeeList.Add(model);
        _db.SaveChanges();
        // villaDto.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
        // VillaStore.villaList.Add(villaDto);
        //return Ok(villaDto);//It will not return the loaction where it has been created
        return Ok(model);
    }
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult deleteEmployee(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        var villa = _db.EmployeeList.FirstOrDefault(u => u.Id == id);
        if (villa == null)
        {
            return NotFound();
        }

        _db.EmployeeList.Remove(villa);
        _db.SaveChanges();
        return NoContent();
    }
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public IActionResult updateEmployee(int id, [FromBody] Employee emp)
    {
        if (emp == null || id != emp.Id)
        {
            return BadRequest();
        }
        Employee model = new()
        {

            Id = emp.Id,
            Address = emp.Address,
            Name = emp.Name,
            Email = emp.Email
        };
        _db.EmployeeList.Update(model);
        _db.SaveChanges();
        // var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
        // if (villa == null)
        // {
        //     return NotFound();
        // }
        // villa.Name = villaDto.Name;
        // villa.Occupancy = villaDto.Occupancy;
        // villa.Sqft = villaDto.Sqft;
        _db.SaveChanges();
        return NoContent();
    }
}