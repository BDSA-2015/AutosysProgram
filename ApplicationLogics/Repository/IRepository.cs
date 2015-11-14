using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Repository
{
    public interface IStorage<T> where T : class
    {
        void Create(T item);
        T Read(int id);
        IEnumerable<T> Read();
        void Update(T item);
        void Delete(T item);
    }
}
