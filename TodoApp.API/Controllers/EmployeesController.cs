using AutoMapper;
using Data;
using Data.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DataAccess.DBContext;
using TodoApp.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public EmployeesController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Employee.GetEmployees());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Employee.GetEmployeeById(id));
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Employee is null");
                }
                _repository.Employee.CreateEmployee(employee);
                _repository.Commit();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
            
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            try
            {
                if (employeeUpdateDto == null)
                {
                    return BadRequest("employee is null");
                }
                var employee = await _repository.Employee.GetEmployeeById(id);
                if (employee == null)
                {
                    return BadRequest();
                }
                _mapper.Map(employeeUpdateDto, employee);
                _repository.Employee.UpdateEmployee(employee);
                _repository.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = await _repository.Employee.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            _repository.Employee.DeleteEmployee(employee);
            _repository.Commit();
            return employee;
        }
    }
}
