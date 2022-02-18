using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountMgt.CORE
{
    public class Users : Entity
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public int AccountId { get; set; }
        public Accounts Account { get; set; }
    }
}
