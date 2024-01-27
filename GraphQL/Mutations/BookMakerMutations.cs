using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Database;
using dotnetcore_asp.Core.Models;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_asp.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class BookMakerMutations
    {


        public async Task<Bookmarker> CreateBookMarker(MyAppDbContext context, string Name, string Url)
        {

            var bookmarker = new Bookmarker
            {
                Name = Name,
                Url = Url,
            };

            await context.AddAsync(bookmarker);
            await context.SaveChangesAsync();

            return bookmarker;

        }

        public async Task<Bookmarker> UpdateBookMarker(MyAppDbContext dbContext, int id, UpdateBookMaker updateDookmarkerData)
        {

            try
            {
                var bookmarker = await dbContext.Bookmarkers.FindAsync(id);

                if (bookmarker is null)
                {
                    Console.WriteLine("null ");
                    throw new GraphQLRequestException("Null");
                }

                if (updateDookmarkerData.Bookmarker is not null)
                {
                    //bookmarker.bookmarker = updateDookmarkerData.Bookmarker;

                    updateDookmarkerData.Bookmarker.ForEach(b =>
                    {
                        var newBookMarker = new Bookmarker { Id = b.Id };
                        dbContext.Bookmarkers.Attach(newBookMarker);
                        bookmarker?.Bookmarkers?.Add(newBookMarker);
                    });
                }

                bookmarker.Name = updateDookmarkerData.Name ?? bookmarker.Name;
                bookmarker.Url = updateDookmarkerData.Url ?? bookmarker.Url;

                dbContext.Update(bookmarker);
                dbContext.SaveChanges();
                return bookmarker;
            }
            catch (System.Exception Exception)
            {

                Console.WriteLine(Exception);
                throw;
            }
        }


        public async Task<Bookmarker?> DeleteBookMaker(MyAppDbContext dbContext, int id)
        {
            try
            {

                var bookmarkerToRemove = await dbContext.Bookmarkers.FindAsync(id);
                if (bookmarkerToRemove is null)
                {

                    return null;
                }

                dbContext.Bookmarkers.Remove(bookmarkerToRemove);
                await dbContext.SaveChangesAsync();
                return bookmarkerToRemove;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public record UpdateBookMaker(string? Name, string? Url, List<Bookmarker>? Bookmarker);

        public class DeleteReturnType<T>
        {

            public string? Message;
            public int? Count;

            public T? Model;
        }


    }
}