using BookStoreAPI.Models;

namespace BookStoreAPI.DAL
{
    public interface IPublisherRepository
    {
        List<Publisher> GetAllPublisher();
        Publisher GetPublisherById(int publisherId);
        void AddPublisher(Publisher publisher);
        void UpdatePublisher(int publisherId, Publisher publisher);
        void DeletePublisher(int publisherId);
    }
}
