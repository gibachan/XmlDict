using System.Xml;

namespace XmlDict
{
    public class XmlAttributeList
    {
        private XmlAttributeCollection _attributes;

        public XmlAttribute this[string key]
        {
            get
            {
                if (_attributes != null && _attributes.GetNamedItem(key) != null)
                    return new XmlAttribute(_attributes.GetNamedItem(key).Value);
                else
                    return new XmlAttribute();
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
