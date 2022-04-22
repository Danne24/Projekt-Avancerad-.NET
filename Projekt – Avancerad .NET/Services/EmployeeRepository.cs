using Microsoft.EntityFrameworkCore;
using Models;
using Projekt___Avancerad_.NET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt___Avancerad_.NET.Services
{
    public class EmployeeRepository : IEmployee
    {
        private ProjectDbContext _projectDbContext;

        public EmployeeRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public async Task<Employee> Add(Employee newEmployee)
        {
            var result = await _projectDbContext.Employees.AddAsync(newEmployee);
            await _projectDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var result = await _projectDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (result != null)
            {
                _projectDbContext.Remove(result);
                await _projectDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _projectDbContext.Employees;
        }

        public async Task<Employee> GetEmployeeTimReport(int id)
        {
            return await _projectDbContext.Employees.Include(e => e.TimReport).FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _projectDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task<Employee> Update(Employee entity)
        {
            var result = await _projectDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == entity.EmployeeID);
            if (result != null)
            {
                result.EmployeeFirstName = entity.EmployeeFirstName;
                result.EmployeeLastName = entity.EmployeeLastName;
                result.EmployeeGender = entity.EmployeeGender;
                result.EmployeeAge = entity.EmployeeAge;
                result.ProjectID = entity.ProjectID;

                await _projectDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
