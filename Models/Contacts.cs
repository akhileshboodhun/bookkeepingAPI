using System.ComponentModel.DataAnnotations;

namespace bookkeepingAPI.Models
{
    public class Contacts
    {
        [Key]
        public int contact_no{get;set;}
        public string contact_name{get;set;}
    }
}