using System;
using System.Collections.Generic;

namespace XmlDict
{
    public interface IXmlDictNode
    {
        string Text { get; }

		int TextAsInt { get; }

        double TextAsDouble { get; }

		bool Exists { get; }

        XmlAttributeList Attributes { get; }

        IEnumerator<IXmlDictNode> GetEnumerator();

        string Name { get; }

        IXmlDictNode this[string name] { get; }

        IXmlDictNode this[int index] { get; }

        int Count { get; }

        IEnumerable<IXmlDictNode> Where(Func<IXmlDictNode, bool> predicate);
    }
}
