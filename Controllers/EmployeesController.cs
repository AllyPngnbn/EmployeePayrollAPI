using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeePayrollAPI.Data;
using EmployeePayrollAPI.Models;

namespace EmployeePayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            employee.EmployeeNumber = Employee.GenerateEmployeeId(employee.FullName, employee.DateOfBirth);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployees), new { id = employee.EmployeeNumber }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("compute/{id}")]
        public async Task<IActionResult> ComputePay(string id, DateTime startDate, DateTime endDate)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound("Employee not found");

            decimal totalPay = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                bool isBirthday = date.Month == emp.DateOfBirth.Month && date.Day == emp.DateOfBirth.Day;
                bool isWorkingDay = false;

                var day = date.DayOfWeek;
                if (emp.WorkingDays == "MWF")
                    isWorkingDay = (day == DayOfWeek.Monday || day == DayOfWeek.Wednesday || day == DayOfWeek.Friday);
                else if (emp.WorkingDays == "TTHS")
                    isWorkingDay = (day == DayOfWeek.Tuesday || day == DayOfWeek.Thursday || day == DayOfWeek.Saturday);

                if (isBirthday) totalPay += emp.DailyRate;

                if (isWorkingDay) totalPay += (emp.DailyRate * 2);
            }

            return Ok(new
            {
                Employee = emp.FullName,
                TakeHomePay = totalPay.ToString("N2"),
                Currency = "PhP"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.EmployeeNumber) return BadRequest("ID Mismatch");

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.EmployeeNumber == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

    }
}