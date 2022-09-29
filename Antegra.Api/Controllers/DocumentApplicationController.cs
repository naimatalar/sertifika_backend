using Labote.Api.Controllers.LaboteController;
using Labote.Core;
using Labote.Core.BindingModels;
using Labote.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
            var data = _context.DocumentAppilications.Select(x => new
            {
                x.Id,
                x.FullName,
                x.Mail,
                x.Phone,
                Status = (int)x.DocumentApplicationMeetStatus
            });
            
              
            PageResponse.Data = data.CreatePagination(model); ;
            return PageResponse;
        }
        [HttpPost("GetAllMobil")]
        public async Task<ActionResult<dynamic>> GetAllMobil(DocumentApplicationSearchModel model)
        {
            var data = _context.DocumentAppilications.Select(x => new
            {
                x.Id,
                x.FullName,
                x.Mail,
                x.Phone,
                Status = (int)x.DocumentApplicationMeetStatus,
                x.CreateDate
            });
            
            if (!string.IsNullOrEmpty(model.Name))
            {
                data = data.Where(x => x.FullName.Contains(model.Name));
            }
            try
            {
                PageResponse.Data= data.OrderByDescending(x=>x.CreateDate).CreatePagination(model);

            }
            catch (Exception e)
            {

            }


            
            return PageResponse;
        }

        [HttpPost("Create")]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public async Task<ActionResult<dynamic>> Create(DocumentApplicationRequestModel model)
        {
            _context.DocumentAppilications.Add(new Core.Entities.DocumentAppilication
            {
                DocumentId = model.DocumentId,
                FullName = model.FullName,
                Mail = model.Mail,
                Phone = model.Phone,
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
            data.DocumentApplicationMeetStatus = (Core.Constants.Enums.DocumentApplicationMeetStatus)model.Status;
            data.NagativeMeetStatus = model.NegaticeStatus==null?null:(Core.Constants.Enums.NagativeMeetStatus)model.NegaticeStatus;
            _context.Update(data);
            _context.SaveChanges();
            return PageResponse;
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid Id)
        {
            var data = _context.DocumentAppilications.Select(x => new
            {
                x.Id,
                x.FullName,
                x.Mail,
                x.Phone,
                Status = (int)x.DocumentApplicationMeetStatus,
                DocumentId= x.Document.Id,
                x.Interviewer,
                DocumentName=x.Document.Name,
                x.Document.DocumentNo,
                NegaticeStatus = x.NagativeMeetStatus,
                DocumentDescription=x.Document.Description,
                DocumentFiles=x.Document.DocumentFiles.Select(y=>new {
                    y.Name,
                    y.Url,
                    Extension = Path.GetExtension(y.Url),
                }),
                x.Notes
                
            }).FirstOrDefault(x => x.Id==Id);
            PageResponse.Data = data;
            return PageResponse;
        }

    }
}
