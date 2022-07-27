using System;
using System.ComponentModel.DataAnnotations;


namespace StockApi.Base.BaseModel
{
    public abstract class BaseDto
    {
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
