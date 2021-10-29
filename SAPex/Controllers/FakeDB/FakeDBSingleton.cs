using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using SAPex.Models;
using System.IO;

namespace SAPex.Controllers
{
    public class FakeDBSingleton
    {
        static private FakeDBSingleton instance;
        private string path = Directory.GetCurrentDirectory() + "\\Controllers\\FakeDB\\";
            
        public FakeDBSingleton()
        {
            instance = FakeDBSingleton.getInstance(this);
        }
        private static FakeDBSingleton getInstance(FakeDBSingleton j)
        {
            if (instance == null) {
                if (j == null) {
                    instance = new FakeDBSingleton();
                } else
                {
                    instance = j;
                }
            }
            return instance;    
        }

        public async Task<List<T>> getJsonData<T> () where T : AbstractIdViewModel
        {
            string _path = this.path + typeof(T).Name + ".json";

            if (!File.Exists(_path))
            {
                await this.setJsonData<T>(new List<T>() { });
            }

            using (StreamReader r = new StreamReader(_path))
            {
                string json = r.ReadToEnd();
                return await Task.FromResult(JsonSerializer.Deserialize<List<T>>(json));
            }
        }

        public async Task setJsonData<T>(List<T> data) where T : AbstractIdViewModel
        {
            string _path = this.path + typeof(T).Name + ".json";
            using FileStream createStream = File.Create(_path);
            await JsonSerializer.SerializeAsync(createStream, data);
            await createStream.DisposeAsync();
        }

        public List<T> getJsonData_Sync<T>() where T : AbstractIdViewModel
        {
            string _path = this.path + typeof(T).Name + ".json";

            if (!File.Exists(_path)) {
                using FileStream createStream = File.Create(_path);
                JsonSerializer.SerializeAsync(createStream, new List<T>() {});
                createStream.DisposeAsync();
            }

            using (StreamReader r =  new StreamReader(_path))
            {
                string json = r.ReadToEnd();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
        }
    }
}
