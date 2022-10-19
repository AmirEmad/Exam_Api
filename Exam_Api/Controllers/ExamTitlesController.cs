using Exam_Api.Models;
using Exam_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamTitlesController : ControllerBase
    {
        private readonly IExamServices<ExamTitle> _services;

        public ExamTitlesController(IExamServices<ExamTitle> services)
        {
            _services = services;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetExamTitlesAsync()
        {
            return Ok(await _services.GetAllAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateExamAsync(ExamTitle examTitle)
        {
            return Ok(await _services.Add(examTitle));
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id ,[FromBody] ExamTitle examTitle)
        { 
            if (id != examTitle.Id)
            {
                return NotFound();
            }
            _services.Update(examTitle);
            return Ok(examTitle);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exam = _services.GetById(id);
            if (exam==null)
            {
                return NotFound();
            }
            _services.Delete(exam);
            return Ok(exam);
        }
    }
}
