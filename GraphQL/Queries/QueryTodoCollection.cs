using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Database;
using dotnetcore_asp.Core.Models;
using dotnetcore_asp.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_asp.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class QueryTodoCollection
    {

        public async Task<List<Todo>> GetTodoCollection(CancellationToken ct, MyAppDbContext db)
        {
            var todos = await db.Todos.ToListAsync(ct);
            return todos;

        }


        public TodoItem? GetTodo(string id)
        {
            try
            {
                var todos = TodoCollectionService.FromJson();
                var todo = todos.Todos.FirstOrDefault(t => t.Id.ToString() == id);

                return todo;

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }
    }
}