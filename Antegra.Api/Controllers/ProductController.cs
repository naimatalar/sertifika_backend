using Labote.Api.BindingModel.RequestModel;
using Labote.Api.Controllers.LaboteController;
using Labote.Core;
using Labote.Core.BindingModels;
using Labote.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : LaboteControllerBase
    {
        private const string pageName = "urun-tanimlari";
        private readonly LaboteContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;


        public ProductController(LaboteContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpPost("Create")]
        [PermissionCheck(Action = pageName)]
        public async Task<dynamic> Create(CreateEditProductRequestModel model)
        {
            var md = new Core.Entities.Product
            {
                
                Description = model.Description,
                CompanyName = model.CompanyName,
                LogoUrl = model.LogoUrl,
                Name = model.Name,
                Barcode=model.Barcode,
            };
            _context.Products.Add(md);
            _context.SaveChanges();
            PageResponse.Data = md;
            return PageResponse;
        }


        [HttpPost("UploadFile")]
        [PermissionCheck(Action = pageName)]
        public async Task<dynamic> UploadFile(FileUploadControllerModel model)
        {

            var dd = _context.Products.Where(x => x.Id == model.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(dd.LogoUrl))
            {
                FileUploadService.Delete(dd.LogoUrl, _hostingEnvironment);
            }

            dd.LogoUrl = model.FileName;
            _context.Update(dd);
            _context.SaveChanges();
            return PageResponse;
        }
        [HttpPost("FileDelete")]
        [PermissionCheck(Action = pageName)]
        public async Task<dynamic> FileDelete(FileUploadControllerModel model)
        {

            var dd = _context.Products.Where(x => x.Id == model.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(dd.LogoUrl))
            {
                FileUploadService.Delete(dd.LogoUrl, _hostingEnvironment);
            }

            dd.LogoUrl = null;
            _context.Update(dd);
            _context.SaveChanges();
            return PageResponse;
        }

        [HttpPost("Edit")]
        [PermissionCheck(Action = pageName)]
        public async Task<dynamic> Edit(CreateEditProductRequestModel model)
        {
            var dd = _context.Products.Where(x => x.Id == model.Id).FirstOrDefault();
            dd.Description = model.Description;
            dd.CompanyName = model.CompanyName;
            dd.LogoUrl = model.LogoUrl;
            dd.Name = model.Name;
            dd.Barcode = model.Barcode;
            _context.Update(dd);
            _context.SaveChanges();
            PageResponse.Data = dd;
            return PageResponse;
        }

        [HttpPost("GetAll")]
        public async Task<dynamic> GetAll(BasePaginationRequestModel model)
        {
            var data = _context.Products.Select(x => new
            {
                x.Name,
                x.CompanyName,
                x.Description,
              
                Report = x.Documents.Where(x => x.DocumentType == Core.Constants.Enums.DocumentType.report).Count(),
                Certifica = x.Documents.Where(x => x.DocumentType == Core.Constants.Enums.DocumentType.Certifica).Count(),
               
                x.Id,
                x.LogoUrl,
            });

            PageResponse.Data = data.CreatePagination(model);
            return PageResponse;
        }
        [HttpGet("getById/{id}")]
        public async Task<dynamic> getById(Guid id)
        {
            var data = _context.Products.Where(x => x.Id == id).Select(x => new
            {
                x.Name,
                x.CompanyName,
                x.Description,
                x.Id,
                x.LogoUrl,
                x.Barcode
            }).FirstOrDefault();
            PageResponse.Data = data;
            return PageResponse;
        }
        [HttpPost("GetByParam")]
        public async Task<dynamic> GetByParam(GetProductByParams model)
        {
            var data = _context.Products.Where(x => x.Name.Contains(model.Name) || x.CompanyName.Contains(model.CompanyName));
            PageResponse.Data = data;

            return PageResponse;
        }

        [HttpPost("Search")]
        [AllowAnonymous]
        public async Task<dynamic> Search(GetByName model)
        {
            var data = _context.Products.Where(x => x.Name.Contains(model.Name)).Select(x => new

            {
                x.Id,
                x.Description,
                x.CompanyName,
                x.LogoUrl,
               x.Barcode,
                Name = x.Name,
            }).CreatePagination(model);
            PageResponse.Data = data;
            return PageResponse;
        } 
        [HttpPost("GetAllMobil")]
        [AllowAnonymous]
        public async Task<dynamic> GetAllMobil(BasePaginationRequestModel model)
        {
            var data = _context.Products.Select(x => new
            {
                x.Id,
                x.Description,
                x.CompanyName,
                x.LogoUrl,
                Name = x.Name,

            }).CreatePagination(model);
            PageResponse.Data = data;
            return PageResponse;
        }

        [HttpGet("getDetailById/{id}")]
        public async Task<dynamic> getDetailById(Guid id)
        {
            var data = _context.Products.Where(x => x.Id == id).Select(x => new
            {
                x.Name,
                x.Description,
                x.CompanyName,
                x.Id,
                x.Barcode,
                Report = x.Documents.Where(y => y.DocumentType == Core.Constants.Enums.DocumentType.report).Select(y => new
                {
                    y.Name,
                    y.Description,
                    ExpireDate = y.ExpireDate.ToString("dd/MM/yyyy"),
                    EDate = y.ExpireDate.ToString("yyyy-MM-dd"),
                    DocumentDate = y.DocumentDate.ToString("dd/MM/yyy"),
                    DDate = y.DocumentDate.ToString("yyyy-MM-dd"),
                    DocumentFiles = y.DocumentFiles.Select(z => new { z.Url, z.Name, z.Id }),
                    y.DocumentNo,
                    y.Id
                }),
                Certifica = x.Documents.Where(y => y.DocumentType == Core.Constants.Enums.DocumentType.Certifica).Select(y => new
                {
                    y.Name,
                    y.Description,
                    ExpireDate = y.ExpireDate.ToString("dd/MM/yyyy"),
                    EDate = y.ExpireDate.ToString("yyyy-MM-dd"),
                    DocumentDate = y.DocumentDate.ToString("dd/MM/yyy"),
                    DDate = y.DocumentDate.ToString("yyyy-MM-dd"),
                    DocumentFiles = y.DocumentFiles.Select(z => new { z.Url, z.Name, z.Id }),
                    y.DocumentNo,
                    y.Id
                }),
                x.LogoUrl,
            }).FirstOrDefault();
            PageResponse.Data = data;
            return PageResponse;
        }


        [HttpGet("delete/{id}")]
        public async Task<dynamic> delete(Guid id)
        {
            var data = _context.Products.Include(x => x.Documents).ThenInclude(x => x.DocumentFiles).Where(x => x.Id == id).FirstOrDefault();
            if (!string.IsNullOrEmpty(data.LogoUrl))
            {
                FileUploadService.Delete(data.LogoUrl, _hostingEnvironment);
            }
            //var documnets = _context.Documents.Where(x => x.CompanyId == data.Id);
            _context.Documents.RemoveRange(data.Documents.ToList());
            _context.Products.Remove(data);

            _context.SaveChanges();


            return PageResponse;
        }

    }
}
