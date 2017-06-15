using System.Collections.Generic;
using System.Xml;

namespace XmlDict
{
    public class XmlDictNode
    {
        private XmlNode _node = null;

        private XmlAttributeList _attributes = new XmlAttributeList();

        public string Text { get { return _node != null ? _node.InnerText : ""; } }

        public XmlAttributeList Attributes { get { return _attributes; } }

        public XmlDictNodeList this[string name]
        {
            get
            {
                var collection = new XmlDictNodeList();
                if (_node != null)
                {
                    foreach (XmlNode child in _node.ChildNodes)
                    {
                        if (child.Name == name)
                            collection.Add(new XmlDictNode(child));
                    }
                }
                return collection;
            }
        }

        public IEnumerator<XmlDictNode> GetEnumerator()
        {
            if (_node != null)
            {
                foreach (XmlNode child in _node.ChildNodes)
                    yield return new XmlDictNode(child);
            }
        }

        public string Name { get { return _node != null ? _node.Name : ""; } }

        public XmlDictNode()
        {
        }

        public XmlDictNode(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            Init(doc.FirstChild);
        }

        public XmlDictNode(XmlNode node)
        {
            Init(node);
        }

        private void Init(XmlNode node)
        {
            _node = node;
            _attributes = new XmlAttributeList(_node.Attributes);
        }
    }
}
