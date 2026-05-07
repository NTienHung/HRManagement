using HRPrinterApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPrinterApp.Repositories
{
    public class EmployeeRepository
    {
        private AppDbContext _context;

        public EmployeeRepository()
        {
            _context = new AppDbContext();
        }

        public List<Employee> GetAll()
        {
            return _context.Employees
                .Include(e => e.Department)
                .ToList();
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);

            _context.SaveChanges();
        }

        public List<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public void Delete(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
        }
    }
}
