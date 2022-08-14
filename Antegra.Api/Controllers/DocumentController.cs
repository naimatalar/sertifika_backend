using Labote.Api.BindingModel.RequestModel;
using Labote.Api.Controllers.LaboteController;
using Labote.Core;
using Labote.Core.Constants;
using Labote.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : LaboteControllerBase
    {
        private readonly LaboteContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public DocumentController(LaboteContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("Create")]
        public async Task<dynamic> Create(CreateEditDocumentRequestModel model)
        {
            var md = new Core.Entities.Document
            {
                CompanyId = model.DocumnetKind == (int)Enums.DocumnetKind.Company ? model.ObjectId : null,
                PersonId = model.DocumnetKind == (int)Enums.DocumnetKind.Person ? model.ObjectId : null,
                ProductId = model.DocumnetKind == (int)Enums.DocumnetKind.Product ? model.ObjectId : null,
                Description = model.Description,
                DocumentDate = model.DocumentDate,
                DocumentNo = model.DocumentNo,
                DocumentType = (Enums.DocumentType)model.DocumentType,
                DocumnetKind = (Enums.DocumnetKind)model.DocumnetKind,
                ExpireDate = model.ExpireDate,
                Name = model.Name,
                Statu = true,
            };
            _context.Documents.Add(md);
            _context.SaveChanges();
            PageResponse.Data = md;
            return PageResponse;
        }
        [HttpPost("Edit")]
        public async Task<dynamic> Edit(CreateEditDocumentRequestModel model)
        {
            var md = _context.Documents.FirstOrDefault(x => x.Id == model.Id);

            md.CompanyId = model.DocumnetKind == (int)Enums.DocumnetKind.Company ? model.ObjectId : null;
            md.PersonId = model.DocumnetKind == (int)Enums.DocumnetKind.Person ? model.ObjectId : null;
            md.ProductId = model.DocumnetKind == (int)Enums.DocumnetKind.Product ? model.ObjectId : null;
            md.Description = model.Description;
            md.DocumentDate = model.DocumentDate;
            md.DocumentNo = model.DocumentNo;
            md.DocumentType = (Enums.DocumentType)model.DocumentType;
            md.DocumnetKind = (Enums.DocumnetKind)model.DocumnetKind;
            md.ExpireDate = model.ExpireDate;
            md.Name = model.Name;
            md.Statu = true;

            _context.Update(md);
            _context.SaveChanges();
            PageResponse.Data = md;
            return PageResponse;
        }

        [HttpPost("Delete")]
        public async Task<dynamic> delete(Guid Id)
        {
            var data = _context.Documents.Where(x => x.Id == Id).FirstOrDefault();
            foreach (var item in data.DocumentFiles)
            {
                FileUploadService.Delete(item.Url, _hostingEnvironment);
            }
            _context.Documents.Remove(data);
            _context.SaveChanges();
            return PageResponse;
        }

        [HttpPost("GetByObjectId")]
        public async Task<dynamic> GetByObjectId(DocumentGetByObjectId model)
        {
            if (model.DocumnetKind == (int)Enums.DocumnetKind.Company)
            {
                var data = _context.Documents.Where(x => x.CompanyId == model.ObjectId).Select(x => new
                {
                    x.CompanyId,
                    x.PersonId,
                    x.ProductId,
                    x.Description,
                    x.DocumentDate,
                    x.DocumentNo,
                    x.DocumentType,
                    x.DocumnetKind,
                    x.ExpireDate,
                    x.Name,
                    Statu = true,
                }).FirstOrDefault();
                PageResponse.Data = data;
            }
            else if (model.DocumnetKind == (int)Enums.DocumnetKind.Person)
            {
                var data = _context.Documents.Where(x => x.PersonId == model.ObjectId).Select(x => new
                {
                    x.CompanyId,
                    x.PersonId,
                    x.ProductId,
                    x.Description,
                    x.DocumentDate,
                    x.DocumentNo,
                    x.DocumentType,
                    x.DocumnetKind,
                    x.ExpireDate,
                    x.Name,
                    Statu = true,
                }).FirstOrDefault();
                PageResponse.Data = data;
            }
            else
            {
                var data = _context.Documents.Where(x => x.ProductId == model.ObjectId).Select(x => new
                {
                    x.CompanyId,
                    x.PersonId,
                    x.ProductId,
                    x.Description,
                    x.DocumentDate,
                    x.DocumentNo,
                    x.DocumentType,
                    x.DocumnetKind,
                    x.ExpireDate,
                    x.Name,
                    Statu = true,
                }).FirstOrDefault();
                PageResponse.Data = data;
            }
            return PageResponse;
        }


    }
}
