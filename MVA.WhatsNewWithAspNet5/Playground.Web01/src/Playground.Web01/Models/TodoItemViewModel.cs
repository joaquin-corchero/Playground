using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Web01.Models
{
    public class TodoItemViewModel
    {
        [Display(Name ="Description")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Description { get; set; }

        [Display(Name ="Creation Date")]
        [Required]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Done")]
        public bool Done { get; set; }

        public TodoItemViewModel()
        {
            CreationDate = DateTime.Now;
        }
    }
}
