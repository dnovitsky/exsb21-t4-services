using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SAPex.Models;

namespace SAPex.Controllers
{
    public class FakeDBSingleton
    {
        private static FakeDBSingleton instance;
        private string _path = Directory.GetCurrentDirectory() + "/Controllers/FakeDB/";

        public FakeDBSingleton()
        {
            instance = FakeDBSingleton.GetInstance(this);
        }

        public async Task SetJsonData<T>(List<T> data)
            where T : AbstractIdViewModel
        {
            var path = _path + typeof(T).Name + ".json";
            using FileStream createStream = File.Create(path);
            await JsonSerializer.SerializeAsync(createStream, data);
            await createStream.DisposeAsync();
        }

        public List<T> GetJsonData_Sync<T>()
            where T : AbstractIdViewModel
        {
            var path = _path + typeof(T).Name + ".json";

            if (!File.Exists(path))
            {
                using FileStream createStream = File.Create(path);
                JsonSerializer.SerializeAsync(createStream, new List<T>() { });
                createStream.DisposeAsync();
            }

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
        }

        public async Task<List<T>> GetJsonData<T>()
            where T : AbstractIdViewModel
        {
            var path = _path + typeof(T).Name + ".json";

            if (!File.Exists(path))
            {
                await SetJsonData<T>(new List<T>() { });
            }

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return await Task.FromResult(JsonSerializer.Deserialize<List<T>>(json));
            }
        }

        private static FakeDBSingleton GetInstance(FakeDBSingleton fakeDB)
        {
            if (instance == null)
            {
                if (fakeDB == null)
                {
                    instance = new FakeDBSingleton();
                }
                else
                {
                    instance = fakeDB;
                }
            }

            return instance;
        }
    }
}
