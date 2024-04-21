﻿using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Insert (T entity);

        void Update (T entity);

        void Delete (int id);
    }
}
