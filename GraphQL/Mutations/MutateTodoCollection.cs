using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Database;
using dotnetcore_asp.Core.Models;
using dotnetcore_asp.Core.Services;

namespace dotnetcore_asp.GraphQL.Mutations
{

    [ExtendObjectType("Mutation")]
    public class MutateTodoCollection
    {
        public async Task<Todo> CreateTodo(MyAppDbContext ct, CreateTodoInputArgs inputArgs)
        {

            var newTodo = new Todo
            {
                Name = inputArgs.Name,
                DueDate = inputArgs.DueDate,
                Completed = inputArgs.Complated
            };

            await ct.AddAsync(newTodo);
            await ct.SaveChangesAsync();

            return newTodo;
        }
    }

    public record CreateTodoInputArgs(string Name, DateTime DueDate, bool Complated = false);

}