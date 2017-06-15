using System.Xml;

namespace XmlDict
{
    public class XmlAttributeList
    {
        private XmlAttributeCollection _attributes;

        public string this[string key]
        {
            get
            {
                if (_attributes != null && _attributes.GetNamedItem(key) != null)
                    return _attributes.GetNamedItem(key).Value;
                else
                    return "";
            }
        }

        public XmlAttributeList(XmlAttributeCollection attributes)
        {
            _attributes = attributes;
        }

        public XmlAttributeList()
        {
        }

    }
}
