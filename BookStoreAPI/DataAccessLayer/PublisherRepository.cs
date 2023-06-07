using BookStoreAPI.Models;

namespace BookStoreAPI.DAL
{
    public class PublisherRepository : IPublisherRepository
    {
        private BookStoreContext _context;

        public PublisherRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void AddPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void DeletePublisher(int publisherId)
        {
            _context.Publishers.Remove(GetPublisherById(publisherId));
            _context.SaveChanges();
        }

        public List<Publisher> GetAllPublisher()
        {
            return _context.Publishers.ToList();
        }

        public Publisher GetPublisherById(int publisherId)
        {
            return _context.Publishers.FirstOrDefault(x => x.PubId == publisherId);
        }

        public void UpdatePublisher(int publisherId, Publisher publisher)
        {
            Publisher p = GetPublisherById(publisherId);
            p.PublisherName = publisher.PublisherName;
            p.City = publisher.City;
            p.State = publisher.State;
            p.Country = publisher.Country;
            _context.SaveChanges();
        }
    }
}
