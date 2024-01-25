using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_asp.Core.Models
{
    public class Bookmarker
    {

        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Url { get; set; }

        public List<Bookmarker> bookmarker { get; set; } = [];

    }
}