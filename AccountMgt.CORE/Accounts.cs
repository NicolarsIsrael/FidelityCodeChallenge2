using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountMgt.CORE
{
    public class Accounts : Entity
    {
        [Required]
        [StringLength(128)]
        public string CompanyName { get; set; }

        public string Website { get; set; }

        public IEnumerable<Users> Users { get; set; }
    }
}
