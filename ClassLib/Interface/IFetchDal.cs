﻿using System.Collections.Generic;

namespace ClassLib.Data
{
    public interface IFetchDal<out T> where T : class
    {
        IEnumerable<T> getAll();
        T getById(int id);
        IEnumerable<T> search(string searchString);
        T verifyLogin(string email, string password);
    }
}
