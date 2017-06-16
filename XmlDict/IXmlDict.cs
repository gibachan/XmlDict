
using System.Collections.Generic;

namespace XmlDict
{
    public interface IXmlDict
    {
        string Text { get; }

        bool Exists { get; }

        XmlAttributeList Attributes { get; }

        IEnumerable<IXmlDict> Enumerable { get; }
    }
}
