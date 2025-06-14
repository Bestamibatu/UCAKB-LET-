﻿namespace UCAKBİLETİ.Models.Abstract
{
    public interface ITicketRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T entity);

        T Update(T entity);
        void Delete(int id);    

    }
}
