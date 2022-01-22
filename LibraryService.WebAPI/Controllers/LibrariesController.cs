using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;
using System;
using AutoMapper;
using LibraryService.WebAPI.SeedData;
using LibraryService.WebAPI.Mapper;
using System.Collections.Generic;

namespace LibraryService.WebAPI.Controllers
{

   public class LibrariesController : ControllerBase
    {
        private readonly ILibrariesService librariesService;

        public LibrariesController(ILibrariesService librariesService, IMapper mapper)
        {
            this.librariesService = librariesService;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }
        [HttpGet]
        [Route("~/api/Libraries/{id}/")]
        public IActionResult Get( int[] ids)
        {

            try
            {
                ids = new[] { 1, 2, 3, 4 };
                var data = librariesService.Get(ids);

                var model = Mapper.Map<IEnumerable<LibraryForm>>(data);

                return Ok(new ApiResponse<IEnumerable<LibraryForm>>()
                {
                    Code = "201",
                    Status = "Ok",
                    Message = "Data Retrieved",
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "No Data Found",
                    Error = ex.Message
                });

            }
        }

        [HttpDelete]
        [Route("~/Api/Delete")]
        public IActionResult Delete(LibraryForm model)
        {

            try
            {
                var data = Mapper.Map<Library>(model);
                librariesService.Delete(data);

                return Ok(new ApiResponse<LibraryForm>()
                {
                    Code = "204",
                    Status = "Ok",
                    Message = "Data Deleted",
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Bad Request",
                    Message = "No Data Saved",
                    Error = ex.Message
                });

            }
        }

    }

}
