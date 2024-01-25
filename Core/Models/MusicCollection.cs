using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_asp.Core.Models
{
    public class MusicCollection
    {

        public List<MusicItem> Musics { get; set; } = [];
    }

    public class Base
    {
        private Guid? _id;

        public Guid? Id
        {
            get { return _id ?? Guid.NewGuid(); }
            set { _id = value; }
        }
    }

    public class MusicItem : Base
    {
        public string? Name { get; set; }

        public string? Comment { get; set; }

        public List<Artist> Artists { get; set; } = [];

    }

    public class Artist : Base
    {
        public string? Name { get; set; }
    }

}