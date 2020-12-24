using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SOC_IR.Dtos.Announcement;
using SOC_IR.Model;
using SOC_IR.Services.AnnouncementService;

namespace SOC_IR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementById(string id)
        {
            return Ok(await _announcementService.GetAnnouncementById(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAnnouncements()
        {
            return Ok(await _announcementService.GetAllAnnouncements());
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(AddAnnouncementDto newAnnouncement)
        {
            return Ok(await _announcementService.AddAnnouncement(newAnnouncement));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncement(UpdateAnnouncementDto updatedAnnouncement)
        {
            ServiceResponse<GetAnnouncementDto> response = await _announcementService.UpdateAnnouncement(updatedAnnouncement);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            ServiceResponse<List<GetAnnouncementDto>> response = await _announcementService.DeleteAnnouncement(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
