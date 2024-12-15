using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MultiLanguageSearch.Persistence
{
    internal class Manager<T>
    where T : class, new()
    {
        private readonly string fname;
        private T? instance;

        public Manager(string fname) 
        {
            this.fname = fname;
        }

        public T Value 
        { 
            get 
            {
                if (instance == null) 
                {
                    if (File.Exists(fname))
                    {
                        var content = File.ReadAllText(fname);
                        instance = JsonSerializer.Deserialize<T>(content);
                    }

                    if (instance == null)
                    {
                        instance = new T();
                    }
                }

                return instance;
            } 
        }

        public void Save()
        {
            if (instance == null)
            {
                return;
            }

            var content = JsonSerializer.Serialize(instance, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fname, content);
        }
    }
}
