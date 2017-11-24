using System.Diagnostics;
using System.Threading.Tasks;

namespace FifaApp.Client
{
    public interface IPlatformDataService
    {
        Task LoadAsync();
    }

    public interface IDataService
    {
        Task LoadAsync();
  
    }

    public class RemoteDataService : IDataService
    {
        public Task LoadAsync()
        {
            Debug.WriteLine("This is remote call");

            return Task.Delay(1);

        }
    }

    public class LocalDataService : IDataService
    {
        public Task LoadAsync()
        {
            Debug.WriteLine("This is local call");

            return Task.Delay(1);
        }
    }
}