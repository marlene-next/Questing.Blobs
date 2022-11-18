namespace blobs.Application;

public interface IQuery<T> where T : IViewModel
{
    T Run();
}