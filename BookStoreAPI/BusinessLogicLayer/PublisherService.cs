using BookStoreAPI.DAL;
using BookStoreAPI.Models;

namespace BookStoreAPI.BLL
{
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public List<Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAllPublisher();
        }

        public Publisher GetPublisherById(int publisherId)
        {
            return _publisherRepository.GetPublisherById(publisherId);
        }

        public void AddPublisher(Publisher publisher)
        {
            _publisherRepository.AddPublisher(publisher);
        }

        public void UpdatePublisher(int publisherId, Publisher publisher)
        {
            _publisherRepository.UpdatePublisher(publisherId, publisher);
        }

        public void DeletePublisher(int publisherId)
        {
            _publisherRepository.DeletePublisher(publisherId);
        }
    }
}
