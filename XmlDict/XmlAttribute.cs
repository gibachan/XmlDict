namespace XmlDict
{
    public class XmlAttribute
    {
        private string _value;

        public string AsString { get { return _value; } }

        public bool Exists { get { return _value != "" ? true : false; } }

        public XmlAttribute()
        {
            _value = "";
        }

        public XmlAttribute(string value)
        {
            _value = value;
        }
    }
}
