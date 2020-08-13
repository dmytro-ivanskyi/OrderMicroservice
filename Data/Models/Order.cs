using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        public JobType JobType { get; set; }

        public string Notes { get; set; }
    }
}
