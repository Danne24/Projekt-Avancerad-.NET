using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Projekt___Avancerad_.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt___Avancerad_.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                return Ok(_employee.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to retrieve information from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var EmployeeToDelete = await _employee.GetSingle(id);
                if (EmployeeToDelete == null)
                {
                    return NotFound($"A Employee with the ID {id} could not be found!");
                }
                return await _employee.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to update the information.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeID)
                {
                    return BadRequest("The Employee could not be found!");
                }
                var EmployeeToUpdate = await _employee.GetSingle(id);
                if (EmployeeToUpdate == null)
                {
                    return NotFound($"A Employee with the id {id} could not be found!");
                }
                return await _employee.Update(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to update the information.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee NewEntity)
        {
            try
            {
                return await _employee.Add(NewEntity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to add information to the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            try
            {
                var result = await _employee.GetEmployeeTimReport(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to retrieve information from the database.");
            }
        }
    }
}
