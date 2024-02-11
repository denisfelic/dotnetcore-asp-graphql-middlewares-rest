using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Models;

namespace dotnetcore_asp.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class UpdateBookmarkerFaviconMutation
    {

        public async Task<Bookmarker> UploadFileAsync(IFile file)
        {
            var fileName = file.Name;
            var fileSize = file.Length;
            

            await using Stream stream = file.OpenReadStream();

            // We can now work with standard stream functionality of .NET
            // to handle the file.

            return new Bookmarker();
        }
    }
}