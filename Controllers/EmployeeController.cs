using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoredProcedure.Data;
using StoredProcedure.DB;

using StoredProcedure.Models;

namespace StoredProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        db dbop = new db();

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public List<Employee> GetEmployes()
        {

            string msg = string.Empty;
            Employee emp = new Employee();
            emp.Type = "GetAll";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Email = dr["Email"].ToString(),
                    Designation = dr["Designation"].ToString(),
                    Name = dr["Name"].ToString()
                });
            }
            return list;
        }
        [HttpGet("{id}")]
        public List<Employee> GetEmployesById(int id)
        {

            string msg = string.Empty;
            Employee emp = new Employee();
            emp.Type = "GetById";
            emp.Id = id;
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (id == Convert.ToInt32(dr["ID"]))
                { 
                    list.Add(new Employee
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Email = dr["Email"].ToString(),
                        Designation = dr["Designation"].ToString(),
                        Name = dr["Name"].ToString()
                    });
                }
            }
            return list;
        }
        [HttpPost]
        public string AddEmployee([FromBody] Employee emp)
        {

            string msg = string.Empty;
            emp.Type = "insert";
            msg = dbop.EmployeeOpt(emp);
            return msg;
        }
        [HttpPut("{id}")]
        public string UpdateEmployee([FromBody] Employee emp)
        {
            string msg = string.Empty;
            emp.Type = "Update";
            msg = dbop.EmployeeOpt(emp);
            return msg;
        }
        [HttpDelete("{id}")]
        //Delete
        public string DeleteEmployee(int id)
        {
            Employee emp=new Employee();
            emp.Id = id;
            emp.Type = "Delete";
            string msg = string.Empty;
            msg = dbop.EmployeeOpt(emp);
            return msg;
        }



        // GET: api/Employee/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Employee>> GetEmployee(int id)
        // {
        //   if (_context.Employes == null)
        //   {
        //       return NotFound();
        //   }
        //     var employee = await _context.Employes.FindAsync(id);

        //     if (employee == null)
        //     {
        //         return NotFound();
        //     }

        //     return employee;
        // }

        // // PUT: api/Employee/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutEmployee(int id, Employee employee)
        // {
        //     if (id != employee.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(employee).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!EmployeeExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/Employee
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        // {
        //   if (_context.Employes == null)
        //   {
        //       return Problem("Entity set 'ApplicationDbContext.Employes'  is null.");
        //   }
        //     _context.Employes.Add(employee);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        // }

        // // DELETE: api/Employee/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteEmployee(int id)
        // {
        //     if (_context.Employes == null)
        //     {
        //         return NotFound();
        //     }
        //     var employee = await _context.Employes.FindAsync(id);
        //     if (employee == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Employes.Remove(employee);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool EmployeeExists(int id)
        // {
        //     return (_context.Employes?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
