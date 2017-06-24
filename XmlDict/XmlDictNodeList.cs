using System;
using System.Collections.Generic;

namespace XmlDict
{
    public class XmlDictNodeList : IXmlDictNode
    {
        private List<XmlDictNode> _dictionaries = new List<XmlDictNode>();

        #region IXMLDict
        public string Text { get { return FirstNode.Text; } }

        public int TextAsInt { get { return FirstNode.TextAsInt; } }

		public double TextAsDouble { get { return FirstNode.TextAsDouble; } }
		
        public bool Exists { get { return _dictionaries.Count > 0 ? true : false; } }

        public XmlAttributeList Attributes { get { return FirstNode.Attributes; } }

		public IEnumerator<IXmlDictNode> GetEnumerator()
		{
			foreach (var child in _dictionaries)
				yield return child;
		}

        public string Name { get { return FirstNode.Name; } }

		public IXmlDictNode this[string name]
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

		public IXmlDictNode this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException();
				return _dictionaries[index];
			}
		}

		public int Count { get { return _dictionaries.Count; } }

		public IEnumerable<IXmlDictNode> Where(Func<IXmlDictNode, bool> predicate)
		{
			foreach (var node in _dictionaries)
			{
				if (predicate(node))
				{
					yield return node;
				}
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

        private IXmlDictNode FirstNode
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
