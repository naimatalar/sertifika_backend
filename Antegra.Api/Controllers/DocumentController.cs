using Labote.Api.BindingModel.RequestModel;
using Labote.Api.Controllers.LaboteController;
using Labote.Core;
using Labote.Core.BindingModels;
using Labote.Core.Constants;
using Labote.Core.Entities;
using Labote.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpPost("GetAll")]
        [AllowAnonymous]
        public async Task<dynamic> GetAll(GetAllDocumentRequestModel model)
        {


            var data = _context.Documents.Where(x => x.DocumentDate > model.StartDate && x.DocumentDate < model.EndDate)
                .Select(x => new
                {
                    x.DocumentType,
                    DocumentTypeString = x.DocumentType.GetDisiplayDescription(),
                    x.DocumnetKind,
                    DocumentKindText = x.DocumnetKind.GetDisiplayDescription(),
                    x.Id,
                    x.Name,
                    CompanyName = x.Company.Name,
                    PersonName = x.Person.FirstName + " " + x.Person.LastName,
                    ProductName = x.Product.Name,
                    DocumentDate = x.DocumentDate.ToString("dd/MM/yyyy"),
                    EndDate = x.ExpireDate.ToString("dd/MM/yyyy")
                }).CreatePagination(model);
            PageResponse.Data = data;
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
        [HttpGet("GetByObjectIdMobil/{id}")]
        [AllowAnonymous]
        public async Task<dynamic> GetByObjectIdMobil(Guid id)
        {
            
                var data = _context.Documents.Where(x => x.Id == id).Select(x => new
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
                    DocumentFiles=x.DocumentFiles.Select(x=>new { 
                    x.Url,
                    Extension= Path.GetExtension(x.Url)
                    }),
                    Company = new
                    {
                        x.Company.Address,
                        x.Company.Description,
                        x.Company.Email,
                        x.Company.LogoUrl,
                        x.Company.Name,
                        x.Company.Phone,
                    },
                    Product = new
                    {
                        x.Product.Name,
                        x.Product.Description,
                        x.Product.CompanyName,
                        x.Product.LogoUrl,

                    },
                    Person = new
                    {
                        x.Person.FirstName,
                        x.Person.Description,
                        x.Person.LastName,
                        x.Person.LogoUrl,
                        x.Person.Title,

                    },
                    Statu = true,
                }).FirstOrDefault();
                PageResponse.Data = data;
            
         
            return PageResponse;
        }


        [HttpPost("UploadFile")]
        public async Task<dynamic> UploadFile(FileUploadControllerModel model)
        {
            var df = new DocumentFile
            {
                Name = model.FileName,
                Url = model.FileName,
                Type = Path.GetExtension(model.FileName),
                DocumentId = model.Id
            };

            _context.DocumentFiles.Add(df);
            _context.SaveChanges();
            return PageResponse;
        }

        [HttpPost("FileDelete")]

        public async Task<dynamic> FileDelete(FileUploadControllerModel model)
        {

            var dd = _context.DocumentFiles.Where(x => x.Id == model.Id).FirstOrDefault();
            FileUploadService.Delete(dd.Url, _hostingEnvironment);
            _context.Remove(dd);
            _context.SaveChanges();
            return PageResponse;
        }

    }
}
