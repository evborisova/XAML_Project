using Consultant.Contracts;
using Consultant.Contracts.Requests;
using Consultant.Contracts.Responses;
using Consultant.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultant.Services;

namespace Consultant.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentService _assigmentService;
        public AssignmentsController(IAssignmentService assigmentService)
        {
            _assigmentService = assigmentService;
        }
        [HttpGet(ApiRoutes.Assigments.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _assigmentService.GetAssignmentsAsync());
        }

        [HttpGet(ApiRoutes.Assigments.Get)]
        public async Task<IActionResult> Get([FromRoute]int assignmentId)
        {
            var assigment = await _assigmentService.GetAssignmentByIdAsync(assignmentId);

            if (assigment == null)
                return NotFound();

            return Ok(assigment);
        }

        [HttpPut(ApiRoutes.Assigments.Update)]
        public async Task<IActionResult> Update([FromRoute]int assignmentId, [FromBody] UpdateAssignmentRequest request)
        {
            var assigment = new Assignment
            {
                Id = assignmentId,
                Name = request.Name,
                Description = request.Description,
                Cost = request.Cost,
                WorkingHoursPercentage = request.WorkingHoursPercentage,
                CreationDate = request.CreationDate,
                StartDate = request.StartDate,
                EndDate = request.EndDate
    };

            var updated = await _assigmentService.UpdateAssignmentAsync(assigment);

            if(updated)
                return Ok(assigment);

                return NotFound();
        }

        [HttpPost(ApiRoutes.Assigments.Create)]
        public async Task<IActionResult> Create([FromBody] CreateAssignmentRequest assigmentRequest)
        {
            var assigment = new Assignment 
            {
                Name = assigmentRequest.Name,
                Description = assigmentRequest.Description,
                Cost = assigmentRequest.Cost,
                WorkingHoursPercentage = assigmentRequest.WorkingHoursPercentage,
                CreationDate = assigmentRequest.CreationDate,
                StartDate = assigmentRequest.StartDate,
                EndDate = assigmentRequest.EndDate
            };

            await _assigmentService.CreateAssignmentAsync(assigment);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var locationUri = baseUrl + "/" + ApiRoutes.Assigments.Get.Replace("{assigmentId}", assigment.Id.ToString());

            var response = new AssignmentResponse { Id = assigment.Id };

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.Assigments.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int assigmentId)
        {
            var deleted = await _assigmentService.DeleteAssignmentAsync(assigmentId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
