using Microsoft.EntityFrameworkCore;
using Models;
using Projekt___Avancerad_.NET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt___Avancerad_.NET.Services
{
    public class TimReportRepository : ITimReport
    {
        private ProjectDbContext _projectDbContext;

        public TimReportRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public async Task<TimReport> Add(TimReport newEntity)
        {
            var result = await _projectDbContext.TimReports.AddAsync(newEntity);
            await _projectDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimReport> Delete(int id)
        {
            var result = await _projectDbContext.TimReports.FirstOrDefaultAsync(t => t.TimReportID == id);
            if (result != null)
            {
                _projectDbContext.Remove(result);
                await _projectDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TimReport> GetSingle(int id)
        {
            return await _projectDbContext.TimReports.FirstOrDefaultAsync(p => p.TimReportID == id);
        }

        public async Task<TimReport> Update(TimReport entity)
        {
            var result = await _projectDbContext.TimReports.FirstOrDefaultAsync(t => t.TimReportID == entity.TimReportID);
            if (result != null)
            {
                result.TimReportWeek = entity.TimReportWeek;
                result.TimReportWorkingHours = entity.TimReportWorkingHours;
                result.EmployeeID = entity.EmployeeID;

                await _projectDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public IEnumerable<TimReport> GetAll()
        {
            return _projectDbContext.TimReports;
        }

        public async Task<TimReport> SearchTimReport(int id, int choosenWeek)
        {
            var result = await _projectDbContext.TimReports.Include(e => e.Employee).Where(t => t.TimReportWeek == choosenWeek).FirstOrDefaultAsync(e => e.EmployeeID == id);

            if (result != null)
            {
                var query = (from e in _projectDbContext.Employees
                             join t in _projectDbContext.TimReports
                             on e.EmployeeID equals t.EmployeeID
                             where t.TimReportWeek == choosenWeek
                             select new
                             {
                                 employeeFirstName = e.EmployeeFirstName,
                                 employeeLastName = e.EmployeeLastName,

                                 week = t.TimReportWeek,
                                 hours = t.TimReportWorkingHours

                             }).ToList();
                return result;
            }
            return null;
        }
    }
}
