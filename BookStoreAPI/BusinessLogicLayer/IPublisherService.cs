using BookStoreAPI.Models;

namespace BookStoreAPI.BLL
{
    public interface IPublisherService
    {
        List<Publisher> GetAllPublishers();
        Publisher GetPublisherById(int publisherId);
        void AddPublisher(Publisher publisher);
        void UpdatePublisher(int publisherId, Publisher publisher);
        void DeletePublisher(int publisherId);
    }
}
