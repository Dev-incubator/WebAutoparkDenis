﻿using System.Collections.Generic;

namespace WebAutopark.BusinessLogic.Services.Base
{
    public interface IDtoService<T>
    {
        IEnumerable<T> GetAllItems();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
