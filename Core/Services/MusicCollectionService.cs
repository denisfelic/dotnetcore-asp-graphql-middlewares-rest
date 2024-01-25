
using System.Text;
using dotnetcore_asp.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace dotnetcore_asp.Core.Services
{
    public class MusicCollectionService
    {
        private const string JsonFile = "musics.json";

        public static MusicCollection FromJson()
        {
            if (File.Exists(JsonFile))
            {
                var jsonContent = File.ReadAllText(JsonFile, Encoding.UTF8);
                return JsonConvert.DeserializeObject<MusicCollection>(jsonContent) ?? new();
            }

            return new();
        }

        public static void ToJson(MusicCollection musicCollection)
        {
            var JsonContent = JsonConvert.SerializeObject(musicCollection, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });
            File.WriteAllText(JsonFile, JsonContent);
        }
    }
}