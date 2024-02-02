using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Models.Abstract;

namespace dotnetcore_asp.Core.Models
{
    public class Bookmarker : BaseEntity
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Url { get; set; }

        public ICollection<Bookmarker>? Bookmarkers { get; set; } = [];

        [ForeignKey("Bookmarker")]
        public int? BookmarkerId { get; set; }

    }
}