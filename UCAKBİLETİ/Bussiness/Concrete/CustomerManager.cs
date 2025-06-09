using UCAKBİLETİ.Bussiness.Abstract;
using UCAKBİLETİ.Models;
using UCAKBİLETİ.Models.Abstract;
using UCAKBİLETİ.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UCAKBİLETİ.Bussiness.Concrete
{
    public class CustomerManager : IServices<Customer>
    {
        private readonly ITicketRepository<Customer> _customerRepository;

        public CustomerManager(ITicketRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer Create(Customer entity)
        {
            return _customerRepository.Create(entity);
        }

        public Customer Update(Customer entity)
        {
            return _customerRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }

        public void BookSeat(int flightId, int seatId)
        {
            // BookSeat implementasyonu
        }
    }
}
