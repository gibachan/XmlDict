using System;
using System.Collections.Generic;

namespace XmlDict
{
    public interface IXmlDict
    {
        string Text { get; }

		int TextAsInt { get; }

        double TextAsDouble { get; }

		bool Exists { get; }

        XmlAttributeList Attributes { get; }

        IEnumerator<IXmlDict> GetEnumerator();

        string Name { get; }

        IXmlDict this[string name] { get; }

        IXmlDict this[int index] { get; }

        int Count { get; }

        IEnumerable<IXmlDict> Where(Func<IXmlDict, bool> predicate);
    }
}
