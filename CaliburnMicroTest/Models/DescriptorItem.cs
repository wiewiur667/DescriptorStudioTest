using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace DescriptorStudioTest.Models
{
    public class DescriptorItem : PropertyChangedBase
    {
        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                NotifyOfPropertyChange("Type");
            }
        }

        public BindableCollection<DescriptorProperty> _values;
        public BindableCollection<DescriptorProperty> Values
        {
            get { return _values; }
            set
            {
                _values = value;
                NotifyOfPropertyChange("Values");
            }
        }

        private BindableCollection<DescriptorItem> _children = new BindableCollection<DescriptorItem>();
        public BindableCollection<DescriptorItem> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                NotifyOfPropertyChange("Children");
            }
        }

        private XElement _xElement;

        #region Constructors
        public DescriptorItem()
        {
            Values = new BindableCollection<DescriptorProperty>();
        }

        public DescriptorItem(string type) : this()
        {
            Type = type;
        }

        public DescriptorItem(XElement element) : this()
        {
            _xElement = element;
            Type = _xElement.Name.ToString();

            foreach (var e in element.Elements())
            {
                var val = e.Value != string.Empty ? int.Parse(e.Value) : 0;
                var type = e.Attribute("type")?.Value;
                Values.Add(new DescriptorProperty(e.Name.ToString(), new DescriptorValue(val, type)));
            }
        }
        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Values.Count > 0)
            {
                foreach (var kvp in Values)
                {
                    sb.AppendLine(
                        $"\t<{kvp.Name} type={kvp.Value.Type} Min={kvp.Value.Range.Min} Max={kvp.Value.Range.Max}>{kvp.Value.Value}</{kvp.Name}>");
                }
            }


            return sb.ToString();
        }


        public class DescriptorProperty : PropertyChangedBase
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                private set
                {
                    _name = value;
                    NotifyOfPropertyChange("Name");
                }
            }

            private DescriptorValue _value;
            public DescriptorValue Value
            {
                get { return _value; }
                set
                {
                    _value = value;
                    NotifyOfPropertyChange("Value");

                }
            }

            public DescriptorProperty() { }

            public DescriptorProperty(string name, DescriptorValue value)
            {
                Name = name;
                Value = value;
            }
        }


        public class DescriptorValue : PropertyChangedBase
        {
            public ValueRange Range { get; private set; }
            
            public string Type;

            public DescriptorValue(){}

            public DescriptorValue(int value, string type)
            {
                Range = new ValueRange(type);
                Value = value;
                Type = type;
            }

            private int _value;
            public int Value
            {
                get { return _value; }
                set
                {
                    if (value > Range.Max)
                    {
                        throw new ValueRange.OutOfRangeException("Value to large");
                    }
                    if (value < Range.Min)
                    {
                        throw new ValueRange.OutOfRangeException("Value to small");
                    }
                    _value = value;
                    NotifyOfPropertyChange("Value"); 
                }
            }


            public class ValueRange
            {
                public ValueRange(string type)
                {
                    switch (type)
                    {
                        case "ubyte":
                            Min = byte.MinValue;
                            Max = byte.MaxValue;
                            break;
                        case "ushort":
                            Min = ushort.MinValue;
                            Max = ushort.MaxValue;
                            break;
                        default:
                            Min = 0;
                            Max = 0;
                            break;
                    }
                }

                public ValueRange(int min, int max)
                {
                    Min = min;
                    Max = max;
                }

                public int Min { get; private set; }
                public int Max { get; private set; }

                [Serializable]
                public class OutOfRangeException : Exception
                {
                    public OutOfRangeException()
                    {
                    }

                    public OutOfRangeException(string message) : base(message)
                    {
                    }

                    public OutOfRangeException(string message, Exception innerException) : base(message, innerException)
                    {
                    }

                    protected OutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
                    {
                    }
                }
            }
        }
    }
}
