using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;
using AutoMapper;
using LibraryService.WebAPI.SeedData;
using LibraryService.WebAPI.Mapper;
using System;
using System.Collections.Generic;

namespace LibraryService.WebAPI.Controllers
{
  public class BooksController:ControllerBase
  {
		private readonly IBooksService booksService;
        private readonly IMapper mapper;

        public BooksController(IBooksService booksService, IMapper mapper)
        {
			this.booksService = booksService;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("~/api/Books/{id}/")]
        public IActionResult Get(int id, int[] ids)
        {

            try
            {
                ids = new[] { 1, 2, 3, 4 };
                var data = booksService.Get(id, ids);

                var model = mapper.Map<IEnumerable<BookForm>>(data);

                return Ok(new ApiResponse<IEnumerable<BookForm>>()
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

        [HttpPost]
        [Route("~/api/Books/{id}/")]
        public async Task<IActionResult> Add(BookForm model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Book>(model);
                    var result = booksService.Add(data);

                    return Ok(new ApiResponse<Book>()
                    {
                        Code = "201",
                        Status = "Created",
                        Message = "Data Saved",
                        Data = await result
                    });
                }

                return  BadRequest(new ApiResponse<string>()
                {
                    Code = "402",
                    Status = "Bad Request",
                    Message = "No Data Saved",
                    Error = "Data Invalid"
                });

            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "402",
                    Status = "Bad Request",
                    Message = "No Data Saved",
                    Error = ex.Message
                });

            }
        }

    


    }
}
