using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.DTOs.Auth;
using ProjectSEM3.Entities;
using ProjectSEM3.Services;

namespace ProjectSEM3.Controllers
{
    [Route("api/product-color")]
    [ApiController]
    public class ProductColorController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public ProductColorController(ProjectSem3Context context)
        {
            _context= context;
        }

        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id != null)
            {
                var pcls = await _context.ProductColors.Include(e=>e.ProductColorImages).ToListAsync();
                return Ok(pcls);
            }
            var pcl= await _context.ProductColors.Include(e => e.ProductColorImages).Where(c=>c.ProductId.Equals(id)).FirstOrDefaultAsync();
            if(pcl==null) return NotFound();
            return Ok(pcl);
        }

        [HttpPost]
        async public Task<IActionResult> Create(ProductColorCreate data)
        {
            if(ModelState.IsValid)
            {
                var pcl = new ProductColor {Name=data.Name,ProductId=data.ProductId};
                await _context.ProductColors.AddAsync(pcl);
                await _context.SaveChangesAsync();
                var index = 0;
                foreach(var file in data.Img)
                {
                    var pclImg = await UploadImg.UploadStr(file, "Products/sp" + data.ProductId, (data.Name + index).Trim(), "#PP" + data.Name.Trim());
                    await _context.ProductColorImages.AddAsync(new ProductColorImage {Url= pclImg.url,PublicId=pclImg.public_id,Folder=pclImg.folder,AssetId=pclImg.asset_id,ProductColorId=pcl.Id });
                    await _context.SaveChangesAsync();
                    index++;
                }
                return Ok(new { pcl ,Img=await _context.ProductColorImages.Where(e=>e.ProductColorId.Equals(pcl.Id)).ToListAsync()});
            }
            return BadRequest();
        }


    }
}
