namespace ServiceArticles.IRepository;

public interface IRepository<T> where T : class
{
    T GetById(int id);
    IList<T> GetAll();
    void Add(T item); 
    
    void AddRange(IList<T> items);  
    
}