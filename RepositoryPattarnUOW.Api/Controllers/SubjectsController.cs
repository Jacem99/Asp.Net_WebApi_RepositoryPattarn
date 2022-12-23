using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattarnUOW.Core.Consts;
using RepositoryPattarnUOW.Core.Interfaces;
using RepositoryPattarnUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattarnUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        public readonly IBaseRepository<Subject> _booksRepository;
        public SubjectsController(IBaseRepository<Subject> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetById() => Ok(await _booksRepository.GetById(1));

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName() => Ok(await _booksRepository.GetByName(t => t.Name.Contains("Arabic")));
       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() => Ok(await _booksRepository.GetAll());

        [HttpGet("GetAllAscending")]
        public async Task<IActionResult> GetAllAcending() => Ok(await _booksRepository.GetAll(o => o.Id));
        [HttpGet("GetAllDescending")]
        public async Task<IActionResult> GetAllDescending() => Ok(await _booksRepository.GetAll(o => o.Id, OrderBy.Descending));


        [HttpGet("ListOfInclude")]
        public async Task<IEnumerable<Subject>> ListOfInclude() => await _booksRepository.ListOfInclude(b => b.TeacherId == 1, new[] { "Teacher" });
        
        [HttpGet("ListOfInclude_Wiht_OrderByAscnending_withId")]
        public async Task<IEnumerable<Subject>> ListOfInclude_Wiht_OrderByAscnending() => await _booksRepository.ListOfInclude(null, o => o.Id , new[] { "Teacher" });
        
        [HttpGet("ListOfInclude_Wiht_OrderByDescending_withName")]
        public async Task<IEnumerable<Subject>> ListOfInclude_Wiht_OrderByDescending() => await _booksRepository.ListOfInclude(null, o => o.Name, new[] { "Teacher" }, OrderBy.Descending);


        [HttpPost("Add")]
        public async Task<IActionResult> Add(Subject t) => Ok(await _booksRepository.Add(t));

        [HttpPut("Update")]
        public IActionResult Update(Subject t) => Ok(_booksRepository.Update(t));

        [HttpDelete("Delete")]
        public void Delete(Subject t) => _booksRepository.Delete(t);


        [HttpDelete("DeleteById")]
        public void DeleteById(int Id) => _booksRepository.Delete(Id);


    }
}
