using AtlasApis.Data;
using AtlasApis.Models;
using AtlasApis.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AtlasApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtlasPhotoController : Controller
    {
        private readonly AppDbContext _contex;

        public AtlasPhotoController(AppDbContext contex)
        {
            _contex = contex;
        }

        [HttpGet("GetPhotos")]
        public ResponseDto GetPhotos()
        {
            var _response = new ResponseDto();
            try
            {
                IEnumerable<AtlasPhoto> photos = _contex.Photos.ToList();
                _response.Data = photos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }


        [HttpGet("GetPhotoById/{id}")]
        public ResponseDto GetPhotoById(int id)
        {
            var _response = new ResponseDto();
            try
            {
               var photo = _contex.Photos.FirstOrDefault(p => p.Id == id);
                _response.Data = photo;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }


        [HttpGet("GetPhotoByTitle/{title}")]
        public ResponseDto GetPhotoById(string title)
        {
            var _response = new ResponseDto();
            try
            {
                var photo = _contex.Photos.FirstOrDefault(p => p.Title == title);
                _response.Data = photo;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }


        [HttpPost("PostPhoto")]
        public ResponseDto PostPhoto([FromBody] AtlasPhoto photo)
        {
            var _response = new ResponseDto();
            try
            {
                _contex.Photos.Add(photo);
                _contex.SaveChanges();

                _response.Data = photo;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }



        [HttpPut("PutPhoto")]
        public ResponseDto PutPhoto([FromBody] AtlasPhoto photo)
        {
            var _response = new ResponseDto();
            try
            {
                _contex.Photos.Update(photo);
                _contex.SaveChanges();

                _response.Data = photo;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }


        [HttpDelete("DeleteById/{id}")]
        public ResponseDto DeleteById(int id)
        {
            var _response = new ResponseDto();
            try
            {
                var photo = _contex.Photos.FirstOrDefault(p => p.Id == id);
                _contex.Remove(photo);
                _contex.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
