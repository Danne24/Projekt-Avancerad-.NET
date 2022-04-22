using Microsoft.EntityFrameworkCore;
using Models;
using Projekt___Avancerad_.NET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt___Avancerad_.NET.Services
{
    public class ProjectRepoitory : IProject
    {
        private ProjectDbContext _projectDbContext;

        public ProjectRepoitory(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public async Task<Project> Add(Project NewEntity)
        {
            var result = await _projectDbContext.Projects.AddAsync(NewEntity);
            await _projectDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var result = await _projectDbContext.Projects.FirstOrDefaultAsync(p => p.ProjectID == id);
            if (result != null)
            {
                _projectDbContext.Remove(result);
                await _projectDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Project> GetSingle(int id)
        {
            return await _projectDbContext.Projects.Include(p => p.Employee).FirstOrDefaultAsync(p => p.ProjectID == id);
        }

        public async Task<Project> Update(Project entity)
        {
            var result = await _projectDbContext.Projects.FirstOrDefaultAsync(p => p.ProjectID == entity.ProjectID);
            if (result != null)
            {
                result.ProjectName = entity.ProjectName;

                await _projectDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public IEnumerable<Project> GetAll()
        {
            return _projectDbContext.Projects;
        }
    }
}
