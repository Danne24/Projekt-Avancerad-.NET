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
    public class ProjectsController : ControllerBase
    {
        private IProject _project;

        public ProjectsController(IProject project)
        {
            _project = project;

        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                return Ok(_project.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to retrieve information from the database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project NewEntity)
        {
            try
            {
                return await _project.Add(NewEntity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to add information to the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var ProjectToDelete = await _project.GetSingle(id);
                if (ProjectToDelete == null)
                {
                    return NotFound($"A project with the id {id} could not be found!");
                }
                return await _project.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to delete information from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project project)
        {
            try
            {
                if (id != project.ProjectID)
                {
                    return BadRequest("The project could not be found!");
                }
                var ProjectToUpdate = await _project.GetSingle(id);
                if (ProjectToUpdate == null)
                {
                    return NotFound($"A project with the id {id} could not be found!");
                }
                return await _project.Update(project);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to update the information.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            try
            {
                var result = await _project.GetSingle(id);
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
