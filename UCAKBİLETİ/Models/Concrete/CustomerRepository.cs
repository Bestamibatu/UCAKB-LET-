using UCAKBİLETİ.Models;
using UCAKBİLETİ.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace UCAKBİLETİ.Models.Concrete
{
    public class CustomerRepository : ITicketRepository<Customer>
    {
        private readonly CustomerDBContext _context;

        // Yapıcı metot: CustomerDBContext parametresi alacak
        public CustomerRepository(CustomerDBContext context)
        {
            _context = context;
        }

        // Create - Yeni müşteri oluşturma
        public Customer Create(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        // Delete - Müşteri silme
        public void Delete(int id)
        {
            var deletecustomer = GetById(id);
            if (deletecustomer != null)
            {
                _context.Customers.Remove(deletecustomer);
                _context.SaveChanges();
            }
        }

        // GetAll - Tüm müşterileri getirme
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        // GetById - ID'ye göre müşteri getirme
        public Customer GetById(int id)
        {
            var customer = _context.Customers.Find(id);
            return customer ?? throw new Exception($"Customer with ID {id} not found.");
        }

        // Update - Müşteri bilgilerini güncelleme
        public Customer Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
