using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt___Avancerad_.NET.Services
{
    public interface IProject
    {
        Task<Project> Add(Project NewEntity);
        Task<Project> Update(Project entity);
        Task<Project> Delete(int id);
        Task<Project> GetSingle(int id);
        IEnumerable<Project> GetAll();
    }
}
