
using System.Text;
using dotnetcore_asp.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace dotnetcore_asp.Core.Services
{
    public class TodoCollectionService
    {
        private const string JsonFile = "todos.json";

        public static TodoCollection FromJson()
        {
            if (File.Exists(JsonFile))
            {
                var jsonContent = File.ReadAllText(JsonFile, Encoding.UTF8);
                return JsonConvert.DeserializeObject<TodoCollection>(jsonContent) ?? new();
            }

            return new();
        }

        public static void ToJson(TodoCollection TodoCollection)
        {
            var JsonContent = JsonConvert.SerializeObject(TodoCollection, new JsonSerializerSettings
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