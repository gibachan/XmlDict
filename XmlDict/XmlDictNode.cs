using System;
using System.Collections.Generic;
using System.Xml;

namespace XmlDict
{
    public class XmlDictNode : IXmlDict
    {
        private XmlNode _node = null;

        private XmlAttributeList _attributes = new XmlAttributeList();

        #region IXMLDict
        public string Text { get { return _node != null ? _node.InnerText : ""; } }

        public bool Exists { get { return _node != null ? true : false; } }

        public XmlAttributeList Attributes { get { return _attributes; } }

        public IEnumerator<IXmlDict> GetEnumerator()
        {
            if (_node != null)
            {
                foreach (XmlNode child in _node.ChildNodes)
                {
                    yield return new XmlDictNode(child);
                }
            }
        }

		public string Name { get { return _node != null ? _node.Name : ""; } }

		public IXmlDict this[string name]
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

		public IXmlDict this[int index]
		{
			get
			{
			    throw new ArgumentOutOfRangeException();
			}
		}

        public int Count { get { return 1; } }
		#endregion

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
