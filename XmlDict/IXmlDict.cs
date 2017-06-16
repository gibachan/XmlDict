
namespace XmlDict
{
    interface IXmlDict
    {
        string Text { get; }

        bool Exists { get; }

        XmlAttributeList Attributes { get; }
    }
}
