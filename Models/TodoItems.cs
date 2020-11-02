using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace bookkeepingAPI.Models
{
    public class TodoItems
    {
        [Key]
        public int item_id{get;set;}
        public string item_name{get;set;}
    }
}