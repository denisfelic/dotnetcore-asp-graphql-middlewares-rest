using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Models;
using dotnetcore_asp.Core.Services;

namespace dotnetcore_asp.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class QueryMusicCollection
    {
        
        public MusicCollection GetMusicCollection()
        {
            return MusicCollectionService.FromJson();
        }
    }
}