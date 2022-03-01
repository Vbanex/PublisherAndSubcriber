using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;

namespace PublisherAndSubcriber.Models
{
    public class Publisher
    {
        private readonly List<ISubscriberObserver> subscriberObservers = new List<ISubscriberObserver>();

        public string Message { get; set; }

        public void Subscribe(ISubscriberObserver subscriberObserver)
        {
            subscriberObservers.Add(subscriberObserver);
        }

        public void Unsubscribe(ISubscriberObserver subscriberObserver)
        {
            subscriberObservers.Remove(subscriberObserver);
        }

        public List<ISubscriberObserver> NotifySubscriberObservers()
        {
            List<ISubscriberObserver> sub = new List<ISubscriberObserver>();
          
            foreach(ISubscriberObserver subscriberObserver  in subscriberObservers)
            {
               sub.Add((ISubscriberObserver)subscriberObserver.UpdateSubscribers(Message)); 
            }
            return sub;

        }
    }
}
