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

        public readonly IUnitOfWork _unitOfWork;
        public TeachersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public async Task< IActionResult> GetById(int Id) => Ok(await _unitOfWork.Teachers.GetById(Id));

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name) => Ok(await _unitOfWork.Teachers.GetByName(t => t.Name == name.Trim()));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() => Ok(await _unitOfWork.Teachers.GetAll());

        [HttpGet("GetAllAscending")]
        public async Task<IActionResult> GetAllAcending() => Ok(await _unitOfWork.Teachers.GetAll(o=>o.Id));
        [HttpGet("GetAllDescending")]
        public async Task<IActionResult> GetAllDescending() => Ok(await _unitOfWork.Teachers.GetAll(o=>o.Id , OrderBy.Descending));

        [HttpGet("ListOf_OrderByAscnending_withId")]
        public async Task<IEnumerable<Teacher>> ListOf_OrderByAscnending() => await _unitOfWork.Teachers.ListOfOrderBy(null, o => o.Id, OrderBy.Ascending);
        
        [HttpGet("ListOf_OrderByDescending_withId")]
        public async Task<IEnumerable<Teacher>> ListOf_OrderByDescending() => await _unitOfWork.Teachers.ListOfOrderBy(null, o => o.Id, OrderBy.Descending);



        [HttpPost("Add")]
        public async Task<IActionResult> Add(Teacher t)
        {
            var teacher = await _unitOfWork.Teachers.Add(t);
            _unitOfWork.Complete();
            return Ok(teacher);
        }

        [HttpPut("Update")]
        public IActionResult Update(Teacher t)
        {
            var teacher = _unitOfWork.Teachers.Update(t);
            _unitOfWork.Complete();
            return Ok(teacher);
        }
        [HttpDelete("Delete")]
        public void Delete(Teacher t)
        {
            _unitOfWork.Teachers.Delete(t);
            _unitOfWork.Complete();
        }

        [HttpDelete("DeleteById")]
        public void DeleteById(int Id)
        {
            _unitOfWork.Teachers.Delete(Id);
            _unitOfWork.Complete();
        }

        [HttpGet("Count")]
        public void Count(string name) => _unitOfWork.Teachers.Count(t => t.Name == name);

        [HttpGet("CountAll")]
        public void CountAll() => _unitOfWork.Teachers.Count();

    }
}
