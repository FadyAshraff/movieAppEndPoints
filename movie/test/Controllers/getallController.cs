using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.context;
using test.model;
using test.NewFolder;
using test.services;
namespace test.services

{
    [Route("api/[controller]")]
    [ApiController]
    public class getallController : ControllerBase
    {
        public readonly igenerservices _igenerservices;
        public getallController(igenerservices context)
        {
            _igenerservices = context;
        }
        [HttpGet("getAllData")]
        public async Task<IActionResult> Getall()
        {
            var getalldata = _igenerservices.GetAsync();
            return Ok(getalldata);
        }



        [HttpPost("write_data")]
        public async Task<IActionResult> createasync(creategeneredto dto)
        {
            var genere = new genre { name = dto.name };
            await _igenerservices.createdata(genere);
            return Ok(genere);
        }



        [HttpPut("updatedata/{Id}")]

        public async Task<IActionResult> updatasync(int Id, [FromBody] creategeneredto dto)
        {
            var genre = await _igenerservices.getbyid(Id);
            if (genre == null)
            {
                return NotFound($"this {Id}is not found");
            }
            else
            {
                genre.name = dto.name;
                _igenerservices.updatedata(genre);
                return Ok(genre);
            }
        }





        [HttpDelete("deletedata/{Id}")]
        public async Task<IActionResult> deleteasync(int Id)
        {
            var genre = await _igenerservices.getbyid(Id);
            if (genre == null)
              return NotFound($"the{Id}is not found");
     
                _igenerservices.deletedata(genre);
            return Ok(genre);



        }
    };
};
