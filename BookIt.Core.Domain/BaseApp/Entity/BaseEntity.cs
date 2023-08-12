using BookIt.Core.Domain.BaseApp.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIt.Core.Domain.BaseApp.Entity
{
    public class BaseEntity<TKey>
    {
        public required TKey Id { get; set; }
        
        public RecordStatus RecordStatus { get; set; }

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; }

    }
}
