using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PublisherAndSubcriber.Models;

namespace PublisherAndSubcriber.Data
{
    public class SubscriberContext:DbContext
    {
        public SubscriberContext(DbContextOptions<SubscriberContext> options): base(options)
        {

        }
        public DbSet<Subscribe> Subscribes { get; set; }
    }
}
