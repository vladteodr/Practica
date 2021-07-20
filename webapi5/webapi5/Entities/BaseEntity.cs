using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi5.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    
        [Required]
        public bool IsDeleted { get; set; }
    }
}
