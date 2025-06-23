using MedicationManagementApp.Models;
using MedicationManagementApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicationManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationRequestsController : ControllerBase
    {
        private readonly IMedicationRequestService _service;

        public MedicationRequestsController(IMedicationRequestService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessMedicationRequest(int id)
        {
            return Ok(await _service.ProcessMedicationRequest(id));
        }
    }
}
