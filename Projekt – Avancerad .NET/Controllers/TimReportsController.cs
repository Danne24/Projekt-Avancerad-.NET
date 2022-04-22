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
    public class TimReportsController : ControllerBase
    {
        private ITimReport _timReport;

        public TimReportsController(ITimReport timReport)
        {
            _timReport = timReport;
        }

        [HttpGet]
        public IActionResult GetAllTimReports()
        {
            try
            {
                return Ok(_timReport.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to retrieve information from the database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TimReport>> AddTimReport(TimReport newEntity)
        {
            try
            {
                return await _timReport.Add(newEntity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to add information to the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimReport>> DeleteTimReport(int id)
        {
            try
            {
                var TimRepToDelete = await _timReport.GetSingle(id);
                if (TimRepToDelete == null)
                {
                    return NotFound("The Timreport could not be found!");
                }
                return await _timReport.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to delete information from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimReport>> UpdateTimReport(int id, TimReport timReport)
        {
            try
            {
                if (id != timReport.TimReportID)
                {
                    return BadRequest("The TimReport could not be found!");
                }
                var TimReportToUpdate = await _timReport.GetSingle(id);
                if (TimReportToUpdate == null)
                {
                    return NotFound($"A Timreport with id {id} could not be found!");
                }
                return await _timReport.Update(timReport);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: unable to update the information.");
            }
        }

        [HttpGet("{id:int}/{choosenWeek}")]
        public async Task<ActionResult<TimReport>> GetSpecificEmployee(int id, int choosenWeek)
        {
            try
            {
                var result = await _timReport.SearchTimReport(id, choosenWeek);
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
