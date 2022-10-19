namespace Exam_Api.Services
{
    public interface IExamServices<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(int id = 0);  
        Task<TEntity> Add(TEntity entity);  
        TEntity Update(TEntity entity);  
        TEntity Delete(TEntity entity);  
        TEntity GetById(int id);
    }
}
