using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApi.Base.BaseModel
{
    public abstract class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
