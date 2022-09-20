using Labote.Api.Controllers.LaboteController;
using Labote.Core;
using Labote.Core.BindingModels;
using Labote.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentApplicationController : LaboteControllerBase
    {
        private readonly LaboteContext _context;

        public DocumentApplicationController(LaboteContext context)
        {
            _context = context;
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll(BasePaginationRequestModel model)
        {
            var data = _context.DocumentAppilications.Select(x=>new { 
            x.FullName,
            x.Mail,
            x.Phone,
            }).CreatePagination(model);
            PageResponse.Data = data;
            return PageResponse;
        }

        [HttpPost("Create")]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public async Task<ActionResult<dynamic>> Create(DocumentApplicationRequestModel model)
        {
            _context.DocumentAppilications.Add(new Core.Entities.DocumentAppilication
            {
                DocumentId=model.DocumentId,
                FullName = model.FullName,
                Mail=model.Mail,
                Phone=model.Phone,
            });
            _context.SaveChanges();
            return PageResponse;
        }

        [HttpPost("Update")]
        public async Task<ActionResult<dynamic>> Update(DocumentApplicationUpdateRequestModel model)
        {
            var data = _context.DocumentAppilications.Where(x => x.Id == model.Id).FirstOrDefault();

            data.Interviewer = model.Interviewer;
            data.Notes = model.Notes;
            data.DocumentApplicationMeetStatus = (Core.Constants.Enums.DocumentApplicationMeetStatus)data.DocumentApplicationMeetStatus;

            _context.Update(data);
            _context.SaveChanges();
            return PageResponse;
        }


    }
}
