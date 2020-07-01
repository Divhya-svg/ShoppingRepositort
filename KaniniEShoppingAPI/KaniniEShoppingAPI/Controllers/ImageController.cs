using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanini.ECommerce.EShopiee.BL.Images;
using Kanini.ECommerce.EShopiee.Model;
using Microsoft.AspNetCore.Mvc;

namespace KaniniEShoppingAPI.Controllers
{
    [ApiController]
    public class ImageController : Controller
    {
        IImageRepo bl;
        public ImageController(IImageRepo repo)
        {
            this.bl = repo;
        }
        [HttpGet]
        [Route("api/[controller]/GetImage")]
        public List<CheckImage> Get()
        {
            return this.bl.GetImage();
        }
    }
}