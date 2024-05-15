using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using test.dto;
using test.model;
using test.NewFolder;
using test.services;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class movies : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly imovie _movie;
        public readonly igenerservices _igenerservices;
        public movies(imovie movie, igenerservices igenerservices, IMapper mapper)
        {
            _movie = movie;
            _igenerservices = igenerservices;
            _mapper = mapper;
        }

        #region getallmovies
        [HttpGet("getallmovies")]
        public async Task<IActionResult> getalldata()
        {

            var getdata = await _movie.GetAsync();
            var data = _mapper.Map<IEnumerable<moviedto>>(getdata);
            return Ok(getdata);

        }
        #endregion

        #region getdatabyid
        [HttpGet("getdatabyid/{Id}")]
        public async Task<IActionResult> getdatabyid(int Id)
        {
            var movie = await _movie.getmoviebyid(Id);
            if (movie == null)
                return NotFound();
            var data = _mapper.Map<moviedto>(movie);
            return Ok(data);
        }
        #endregion

        #region writeasync
        [HttpPost]
        public async Task<IActionResult> addasync([FromForm] moviedto dto)
        {
            var vaildid = await _igenerservices.isvalid(dto.genreid);
            if (!vaildid)
                return BadRequest("it is not valid");

            using var datastream = new MemoryStream();
            await dto.poster.CopyToAsync(datastream);


            var mov = _mapper.Map<movie>(dto);
            mov.poster=datastream.ToArray();
         _movie.addmovies(mov);
            return Ok(mov);
        }
        #endregion

        #region getbywhere
        [HttpGet("getbywhere")]
        public async Task<IActionResult> getbywhere(int genreId)
        {
            var getbyw = await _movie.GetAsync(genreId);

            return Ok(getbyw);
        }
        #endregion

        [HttpPut("update/{id}")]
        public async Task<IActionResult> updatedata(int id, [FromForm]moviedto dto)
        {
            var upd=await _movie.getmoviebyid(id);
            if (upd == null)
                return NotFound($"this id{id} is not found");

            var check_fk = await _igenerservices.isvalid(dto.genreid);
            if (!check_fk )
                return BadRequest("no fk match with fk");

            if(dto.poster!=null)
            {
                using var datastream = new MemoryStream();    
                await dto.poster.CopyToAsync(datastream);
                upd.poster = datastream.ToArray();

            }


            upd.rate = dto.rate;
            upd.genreid = dto.genreid;
            upd.title = dto.title;
            upd.year = dto.year;
            upd.storeline = dto.storeline;


            _movie.update(upd);
            return Ok(upd);
        }

    }
}
