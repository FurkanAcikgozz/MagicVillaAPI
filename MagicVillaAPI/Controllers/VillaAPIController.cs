using MagicVillaAPI.Data;
using MagicVillaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MagicVillaAPI.Controllers
{
    //[Route("api/VillaAPI")]
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return VillaStore.villaList;
        }

        [HttpGet("{id:int}")]
        public VillaDTO GetVilla(int id)
        {
            return VillaStore.villaList.FirstOrDefault(u => u.Id == id);
        }

        //[HttpGet]
        //public IEnumerable<VillaDTO> GetVillas()
        //{   
        //    return new List<VillaDTO> {
        //    new VillaDTO{Id=1,Name="Pool View" },
        //    new VillaDTO{Id=2,Name="Beach View" }
        //    };
        //}

        //[HttpGet]
        //public IEnumerable<Villa> GetVillas()
        //{
        //    return new List<Villa> {
        //    new Villa{Id=1,Name="Pool View" },
        //    new Villa{Id=2,Name="Beach View" }
        //    };
        //}



    }
}
