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

        [HttpGet("admin")]
        public async Task<IActionResult> GetAllAnnouncements()
        {
            return Ok(await _announcementService.GetAllAnnouncements());
        }

        [HttpGet("student")]
        public async Task<IActionResult> GetAllUnarchivedAnnouncements()
        {
            return Ok(await _announcementService.GetAllUnarchivedAnnouncements());
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAnnouncement(AddAnnouncementDto newAnnouncement)
        {
            return Ok(await _announcementService.AddAnnouncement(newAnnouncement));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAnnouncement(UpdateAnnouncementDto updatedAnnouncement)
        {
            ServiceResponse<GetAnnouncementDto> response = await _announcementService.UpdateAnnouncement(updatedAnnouncement);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            ServiceResponse<List<GetAnnouncementDto>> response = await _announcementService.DeleteAnnouncement(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("archive/{id}")]
        public async Task<IActionResult> ArchiveAnnouncement(string id)
        {
            ServiceResponse<GetAnnouncementDto> response = await _announcementService.ArchiveAnnouncement(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("unarchive/{id}")]
        public async Task<IActionResult> UnarchiveAnnouncement(string id)
        {
            ServiceResponse<GetAnnouncementDto> response = await _announcementService.UnarchiveAnnouncement(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}
