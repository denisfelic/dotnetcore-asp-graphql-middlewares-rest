using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_asp.Core.Models
{
    public class TodoCollection
    {

        public List<TodoItem> Todos { get; set; } = [];
    }



    public class TodoItem : Base
    {
        public string? Name { get; set; }

        public bool? isDone { get; set; } = false;


    }



}