using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; protected set; }

        public Entity()
        {
            CreateDate = DateTime.Now;
        }

        public Entity(int id) : this()
        {
            Id = id;
        }
    }
}
