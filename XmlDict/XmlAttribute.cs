namespace XmlDict
{
    public class XmlAttribute
    {
        private string _value;

        public string Value { get { return _value; } }

        public int ValueAsInt
        {
            get
            {
                if (_value == "")
                    return 0;
                int value = 0;
                int.TryParse(_value, out value);
                return value;
            }
        }

        public double ValueAsDouble
        {
            get
            {
                if (_value == "")
                    return 0.0;
                double value = 0.0;
                double.TryParse(_value, out value);
                return value;
            }
        }

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
