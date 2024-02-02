using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_asp.Core.Validation
{
    public class CreateBookmarkerModel
    {

        [Required]
        public required string Name { get; set; }

        [Url]
        public string? Url { get; set; }

        [Range(0, Int64.MaxValue)]
        public int? Bookmarkerid { get; set; }

    }
}