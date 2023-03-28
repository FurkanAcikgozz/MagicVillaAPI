using MagicVillaAPI.Data;
using MagicVillaAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MagicVillaAPI.Controllers
{
    //[Route("api/VillaAPI")]
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;

        public VillaAPIController(ILogger<VillaAPIController> logger)
        {
            _logger = logger;
        }

        #region Get

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Get Villas Requsted:");
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        #endregion

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

        #region Post

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            ////// Validation!
            ////if (VillaStore.villaList.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            ////{
            ////    ModelState.AddModelError("CustomError", "Villa already Exists!");
            ////    return BadRequest(ModelState);
            ////}


            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDTO);


            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);


            // return Ok(villaDTO);
        }

        #endregion

        #region Put_Update

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            villa.Name = villaDTO.Name;
            villa.Sqft = villaDTO.Sqft;
            villa.Occupancy = villaDTO.Occupancy;

            return NoContent();

        }

        #endregion

        #region Patch

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villa, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();

            /* 
              
             [
               {
                 "path": "/sqft",
                 "op":"replace",
                 "value": 11080
               }
             ]
             
             
             */
        }

        #endregion

        #region Delete

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaStore.villaList.Remove(villa);
            return NoContent();

        }

        #endregion
    }
}
