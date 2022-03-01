using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherAndSubcriber.Models
{
    public class Subscribers: ISubscriberObserver
    {
        private Publisher _publisher;

        public string Url { get; set; }
        public string Message { get; set; }
        
        public Subscribers()
        {

        }
        public Subscribers(Publisher publisher, string Url)
        {
            _publisher = publisher;
            this.Url = Url;
        }

        public void Subscribe()
        {
            _publisher.Subscribe(this);
        }

        public void Unsubscribe()
        {
            _publisher.Unsubscribe(this);
        }

        public Subscribers UpdateSubscribers(string Message)
        {
            this.Message = Message;
            Subscribers subscribers = new Subscribers();
            subscribers.Url = this.Url;
            subscribers.Message = this.Message;
            return subscribers;
          // return this.Url + " " + this.Message;
        }
    }
}
