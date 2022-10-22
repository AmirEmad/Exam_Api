using Exam_Api.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Exam_Api.Services
{
    public class ExamServices : IExamServices<ExamTitle>
    {
        private readonly ExamContext _context;

        public ExamServices(ExamContext context)
        {
            _context = context;
        }
        public async Task<ExamTitle> Add(ExamTitle entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public ExamTitle Delete(ExamTitle entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<ExamTitle>> GetAllAsync(int id = 0)
        {
            return await _context.ExamTitles
                .Include(x => x.Questions)
                .OrderBy(x => x.Name).ToListAsync();
        }

        public ExamTitle GetById(int id)
        {
            return _context.ExamTitles.Include(x=>x.Questions).SingleOrDefault(x=>x.Id==id);
        }

        public ExamTitle Update(ExamTitle entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
