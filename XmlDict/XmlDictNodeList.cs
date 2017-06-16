using System;
using System.Collections.Generic;

namespace XmlDict
{
    public class XmlDictNodeList : IXmlDict
    {
        private List<XmlDictNode> _dictionaries = new List<XmlDictNode>();

        #region IXMLDict
        public string Text { get { return FirstNode.Text; } }

        public bool Exists { get { return _dictionaries.Count > 0 ? true : false; } }

        public XmlAttributeList Attributes { get { return FirstNode.Attributes; } }

		public IEnumerable<IXmlDict> Enumerable
		{
			get
			{
				foreach (var child in _dictionaries)
					yield return child;
			}
		}
        #endregion

        public void Add(XmlDictNode dict)
        {
            _dictionaries.Add(dict);
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= _dictionaries.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            _dictionaries.RemoveAt(index);
        }

        public int Count { get { return _dictionaries.Count; } }


        public XmlDictNode this[string name]
        {
            get
            {
                foreach (var node in FirstNode)
                {
                    if (node.Name == name)
                        return node;
                }
                return new XmlDictNode();
            }
        }

        public XmlDictNode this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException();
                return _dictionaries[index];
            }
        }


        private XmlDictNode FirstNode
        {
            get
            {
                if (_dictionaries.Count > 0)
                    return _dictionaries[0];
                else
                    return new XmlDictNode();
            }
        }

    }
}
