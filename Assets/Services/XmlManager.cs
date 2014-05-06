using System;
using System.IO;
using System.Xml.Serialization;
using Assets.Extensions;
using UnityEngine;

namespace Assets.Services
{
    public class XmlManager<T>
    {
        public Type Type { get; set; }

        public XmlManager()
        {
            Type = typeof(T);
        }

        public T Load(string path)
        {
            T instance;
            using (TextReader reader = new StreamReader("{0}/{1}".ToFormat(Application.persistentDataPath, path)))
            {
                var xml = new XmlSerializer(Type);
                instance = (T)xml.Deserialize(reader);
            }
            return instance;
        }

        public void Save(string path, object obj)
        {
            using (TextWriter writer = new StreamWriter("{0}/{1}".ToFormat(Application.persistentDataPath, path)))
            {
                var xml = new XmlSerializer(Type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
