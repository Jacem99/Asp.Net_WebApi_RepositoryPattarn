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
    public class TeachersController : ControllerBase
    {
        public readonly IBaseRepository<Teacher> _teacherRepository;
        public TeachersController(IBaseRepository<Teacher> baseRepository)
        {
            _teacherRepository = baseRepository;
        }

        [HttpGet("GetById")]
        public async Task< IActionResult> GetById() => Ok(await _teacherRepository.GetById(1));

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName() => Ok(await _teacherRepository.GetByName(t => t.Name == "ahmed"));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() => Ok(await _teacherRepository.GetAll());

        [HttpGet("GetAllAscending")]
        public async Task<IActionResult> GetAllAcending() => Ok(await _teacherRepository.GetAll(o=>o.Id));
        [HttpGet("GetAllDescending")]
        public async Task<IActionResult> GetAllDescending() => Ok(await _teacherRepository.GetAll(o=>o.Id , OrderBy.Descending));

        [HttpGet("ListOf_OrderByAscnending_withId")]
        public async Task<IEnumerable<Teacher>> ListOf_OrderByAscnending() => await _teacherRepository.ListOfOrderBy(null, o => o.Id, OrderBy.Ascending);
        
        [HttpGet("ListOf_OrderByDescending_withId")]
        public async Task<IEnumerable<Teacher>> ListOf_OrderByDescending() => await _teacherRepository.ListOfOrderBy(null, o => o.Id, OrderBy.Descending);


        [HttpPost("Add")]
        public async Task<IActionResult> Add(Teacher t) => Ok(await _teacherRepository.Add(t));

        [HttpPut("Update")]
        public IActionResult Update(Teacher t) => Ok(_teacherRepository.Update(t));

        [HttpDelete("Delete")]
        public void Delete(Teacher t) => _teacherRepository.Delete(t);


        [HttpDelete("DeleteById")]
        public void DeleteById(int Id) => _teacherRepository.Delete(Id);

        [HttpGet("Count")]
        public void Count(string name) => _teacherRepository.Count(t => t.Name == name);

        [HttpGet("CountAll")]
        public void CountAll() => _teacherRepository.Count();

    }
}
