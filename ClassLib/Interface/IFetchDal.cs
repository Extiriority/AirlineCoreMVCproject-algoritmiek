using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Data
{
    public interface IFetchDal<out T> where T : class
    {
        IEnumerable<T> getAll();
        T getById(int id);
        IEnumerable<T> search(string searchString);
    }
}
