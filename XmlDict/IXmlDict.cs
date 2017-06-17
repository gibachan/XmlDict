﻿using System.Collections.Generic;

namespace XmlDict
{
    public interface IXmlDict
    {
        string Text { get; }

		int AsInt { get; }

        double AsDouble { get; }

		bool Exists { get; }

        XmlAttributeList Attributes { get; }

        IEnumerator<IXmlDict> GetEnumerator();

        string Name { get; }

        IXmlDict this[string name] { get; }

        IXmlDict this[int index] { get; }

        int Count { get; }
    }
}
