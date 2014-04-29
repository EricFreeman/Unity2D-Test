using System;
using System.Xml;

namespace Assets.Extensions
{
    public static class XmlExtensions
    {
        public static string GetAttributeOrDefault(this XmlNode node, string attributeName, string defaultValue)
        {
            if(node.Attributes == null) throw new NullReferenceException();

            string rtn = string.Empty;
            var att = node.Attributes[attributeName];

            if (att != null) rtn = att.InnerText;
            if (rtn.IsEmpty() || att == null) rtn = defaultValue;

            return rtn;
        }
    }
}
