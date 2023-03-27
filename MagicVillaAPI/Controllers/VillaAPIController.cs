using MagicVillaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Controllers
{
    [ApiController]
    [Route("api/VillaAPI")]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return new List<Villa> {
            new Villa{Id=1,Name="Pool View" },
            new Villa{Id=2,Name="Beach View" }
            };
        }


        [HttpPost]
        public IEnumerable<Villa> GetVillas2()
        {
            return new List<Villa> {
            new Villa{Id=1,Name="Pool View" },
            new Villa{Id=2,Name="Beach View" }
            };
        }
        [HttpPut]
        public IEnumerable<Villa> GetVillas3()
        {
            return new List<Villa> {
            new Villa{Id=1,Name="Pool View" },
            new Villa{Id=2,Name="Beach View" }
            };
        }
        [HttpPatch]
        public IEnumerable<Villa> GetVillas4()
        {
            return new List<Villa> {
            new Villa{Id=1,Name="Pool View" },
            new Villa{Id=2,Name="Beach View" }
            };
        }
        [HttpDelete]
        public IEnumerable<Villa> GetVillas5()
        {
            return new List<Villa> {
            new Villa{Id=1,Name="Pool View" },
            new Villa{Id=2,Name="Beach View" }
            };
        }
      
        [Route("api/VillaAPI/del2")]
        [HttpDelete]
        public IEnumerable<Villa> GetVillas6()
        {
            return new List<Villa> {
            new Villa{Id=1,Name="Pool View" },
            new Villa{Id=2,Name="Beach View" }
            };
        }
    }
}
