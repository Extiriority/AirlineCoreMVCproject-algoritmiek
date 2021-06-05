using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Data
{
    public interface IPersistDal<in T> where T : class
    {
        void save(T t);

        void update(T t);

        void delete(int id);
    }
}
