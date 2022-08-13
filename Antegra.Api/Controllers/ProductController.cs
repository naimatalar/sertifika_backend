using Labote.Api.BindingModel.RequestModel;
using Labote.Api.Controllers.LaboteController;
using Labote.Core;
using Labote.Core.BindingModels;
using Labote.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ProductController : LaboteControllerBase
    {
        private const string pageName = "firma-tanimlari";
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
                LogoUrl = model.LogoUrl,
                Name = model.Name,
                CompanyName = model.CompanyName,


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
            dd.Name = model.Name;

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
                x.Description,
                x.CompanyName,
                x.Id,
                x.LogoUrl,
            });

            PageResponse.Data = data.CreatePagination(model);
            return PageResponse;
        }
        [HttpGet("getById/{id}")]
        public async Task<dynamic> GetAll(Guid id)
        {
            var data = _context.Products.Where(x => x.Id == id).Select(x => new
            {
                x.Name,
                x.Description,
                x.CompanyName,
                x.Id,
                x.LogoUrl,
            }).FirstOrDefault();
            PageResponse.Data = data;
            return PageResponse;
        }
        [HttpGet("delete/{id}")]
        public async Task<dynamic> delete(Guid id)
        {
            var data = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (!string.IsNullOrEmpty(data.LogoUrl))
            {
                FileUploadService.Delete(data.LogoUrl, _hostingEnvironment);
            }
            _context.Products.Remove(data);
            _context.SaveChanges();
            return PageResponse;
        }

    }
}
