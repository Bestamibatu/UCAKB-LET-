namespace UCAKBİLETİ.Bussiness.Abstract
{
    public interface IServices<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T entity);

        T Update(T entity);
        void Delete(int id);
        void BookSeat(int flightId, int seatId);
    }
}
