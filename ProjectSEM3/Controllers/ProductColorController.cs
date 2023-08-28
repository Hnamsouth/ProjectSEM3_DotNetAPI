using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.DTOs.Auth;
using ProjectSEM3.Entities;
using ProjectSEM3.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (id == null)
            {
                var pcls = await _context.ProductColors.Include(e => e.ProductColorImages).Include(e => e.ProductSizes).ThenInclude(e => e.Size).ToListAsync();
                return Ok(pcls);
            }
            var pcl = await _context.ProductColors.Include(e => e.ProductColorImages).Include(e => e.ProductSizes).ThenInclude(e => e.Size).Where(c => c.ProductId == id).ToListAsync();
            if (pcl == null) return NotFound();
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

        [HttpPut]
        async public Task<IActionResult> Update(ProductColorUpdate data)
        {
            if (ModelState.IsValid)
            {
                var pcl= await _context.ProductColors.FindAsync(data.Id);
                if(pcl==null) return NotFound();

                var pclUD = new ProductColor { Id = data.Id, Name = data.Name };
                 _context.ProductColors.Update(pclUD);
                await _context.SaveChangesAsync();

                if(data.Img!=null)
                {
                    var index = 0;
                    foreach (var file in data.Img)
                    {
                        var pclImg = await UploadImg.UploadStr(file, "Products/sp" + data.ProductId, (data.Name + index).Trim(), "#PP" + data.Name.Trim());
                        await _context.ProductColorImages.AddAsync(new ProductColorImage { Url = pclImg.url, PublicId = pclImg.public_id, Folder = pclImg.folder, AssetId = pclImg.asset_id, ProductColorId = pcl.Id });
                        await _context.SaveChangesAsync();
                        index++;
                    }
                }
                return Ok(new { pcl, Img = await _context.ProductColorImages.Where(e => e.ProductColorId.Equals(pcl.Id)).ToListAsync() });
            }
            return BadRequest();
        }

        [HttpDelete,Route("delete-img")]
        async public Task<IActionResult> DeleteImg(ProductColorImage data)
        {
            if (ModelState.IsValid)
            {
                var pclImg = await _context.ProductColorImages.FindAsync(data.Id);
                if (pclImg == null) return NotFound(new { msg = "Not found product img !!!", status = false });

                _context.ProductColorImages.Remove(pclImg);
                var check = await UploadImg.DeleteImg(data.PublicId);
                if (!check) return NotFound(new {msg="Not found publicId !!!",status=false});
                return Ok(new { msg = "Delete done.", status = true });
            }
            return BadRequest();

        }

        [HttpGet,Route("test-delete")]
        async public Task<IActionResult> GetImg(string? data)
        {
            var rs = UploadImg.DeleteImg(data);
            if(rs.Result==null) return NotFound();
            return Ok(rs.Result);
        }


    }
}
