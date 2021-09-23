using Business.Abstract;
using Entities.Model.Performer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerformersController : ControllerBase
    {
        private readonly IPerformerService _performerService;

        public PerformersController(IPerformerService performerService)
        {
            _performerService = performerService;
        }

        [HttpGet]
        public IActionResult GetPerformers()
        {
            var result = _performerService.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("{id}")]
        public IActionResult GetPerformerById(int id)
        {
            var result = _performerService.GetById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpPost]
        public IActionResult AddPerformer([FromBody] AddPerformerModel model)
        {
            var result = _performerService.Add(model);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePerformer(int id, [FromBody] UpdatePerformerModel model)
        {
            var result = _performerService.Update(id, model);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePerformer(int id)
        {
            var result = _performerService.Delete(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
