using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Models;
using dotnetcore_asp.Core.Services;

namespace dotnetcore_asp.GraphQL.Mutations
{

    [ExtendObjectType("Mutation")]
    public class MutateMusicCollection
    {
        public string CreateMusic(CreateMusicInputArgs inputArgs)
        {

            var musicCollection = MusicCollectionService.FromJson();

            var artists = inputArgs.CreateArtistInputArgs.Select(a =>
                new Artist
                {
                    Name = a.Name
                }).ToList();


            musicCollection.Musics.Add(new MusicItem
            {
                Name = inputArgs.Name,
                Comment = inputArgs.Comment,
                Artists = artists
            });
            var createdMusic = musicCollection.Musics.First(m => m.Name == inputArgs.Name);
            MusicCollectionService.ToJson(musicCollection);
            Console.WriteLine(createdMusic);
            return "ok";
        }
    }

    public record CreateMusicInputArgs(string Name, string? Comment, List<CreateArtistInputArgs> CreateArtistInputArgs);

    public record CreateArtistInputArgs(string Name);
}