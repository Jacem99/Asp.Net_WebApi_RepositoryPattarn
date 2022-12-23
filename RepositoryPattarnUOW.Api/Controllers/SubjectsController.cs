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
        public readonly IUnitOfWork _unitOfWork;
        public SubjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id) => Ok(await _unitOfWork.Subjects.GetById(Id));

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name) => Ok(await _unitOfWork.Subjects.GetByName(t => t.Name.Contains(name.Trim())));
       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() => Ok(await _unitOfWork.Subjects.GetAll());

        [HttpGet("GetAllAscending")]
        public async Task<IActionResult> GetAllAcending() => Ok(await _unitOfWork.Subjects.GetAll(o => o.Id));
        [HttpGet("GetAllDescending")]
        public async Task<IActionResult> GetAllDescending() => Ok(await _unitOfWork.Subjects.GetAll(o => o.Id, OrderBy.Descending));


        [HttpGet("ListOfInclude")]
        public async Task<IEnumerable<Subject>> ListOfInclude() => await _unitOfWork.Subjects.ListOfInclude(b => b.TeacherId == 1, new[] { "Teacher" });
        
        [HttpGet("ListOfInclude_Wiht_OrderByAscnending_withId")]
        public async Task<IEnumerable<Subject>> ListOfInclude_Wiht_OrderByAscnending() => await _unitOfWork.Subjects.ListOfInclude(null, o => o.Id , new[] { "Teacher" });
        
        [HttpGet("ListOfInclude_Wiht_OrderByDescending_withName")]
        public async Task<IEnumerable<Subject>> ListOfInclude_Wiht_OrderByDescending() => await _unitOfWork.Subjects.ListOfInclude(null, o => o.Name, new[] { "Teacher" }, OrderBy.Descending);


        [HttpPost("Add")]
        public async Task<IActionResult> Add(Subject t) => Ok(await _unitOfWork.Subjects.Add(t));

        [HttpPut("Update")]
        public IActionResult Update(Subject t) => Ok(_unitOfWork.Subjects.Update(t));

        [HttpDelete("Delete")]
        public void Delete(Subject t) => _unitOfWork.Subjects.Delete(t);


        [HttpDelete("DeleteById")]
        public void DeleteById(int Id) => _unitOfWork.Subjects.Delete(Id);

    }
}
