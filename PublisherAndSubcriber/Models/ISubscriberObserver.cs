using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherAndSubcriber.Models
{
   public interface ISubscriberObserver
    {
       Subscribers UpdateSubscribers(string Message);
    }
}
