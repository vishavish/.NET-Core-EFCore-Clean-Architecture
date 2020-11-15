using DeviceAssigment.Application.Common.Models;
using DeviceAssigment.Application.Device.Dtos;
using DeviceAssigment.Application.Device.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceAssignment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepo;

        public DeviceController(IDeviceRepository deviceRepo)
        {
            _deviceRepo = deviceRepo;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<DeviceDto>>>> GetAll()
        {
            return await _deviceRepo.GetDevices();
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<ServiceResponse<DeviceDto>>> GetDevice(int id)
        {
            return await _deviceRepo.GetDevice(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceDto createDeviceDto, CancellationToken cancellationToken)
        {
            _deviceRepo.Add(createDeviceDto);
            if (!await _deviceRepo.Save(cancellationToken))
            {
                return BadRequest();
            }

            return Ok(createDeviceDto);
        }
    }
}
 