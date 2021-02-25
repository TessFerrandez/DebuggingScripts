using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCRootsToDgml
{
    class QualifiedName : IEqualityComparer<QualifiedName>
    {
        string _name;
        Type _type;

        private QualifiedName(string name, Type type)
        {
            _name = name;
            _type = type;
        }

        static Dictionary<QualifiedName, QualifiedName> _map = new Dictionary<QualifiedName, QualifiedName>();

        public static QualifiedName Get(string name, Type type)
        {
            QualifiedName temp = new QualifiedName(name, type);
            QualifiedName result = null;
            if (_map.TryGetValue(temp, out result))
            {
                return result;
            }
            _map[temp] = temp;
            return temp;
        }

        public override string ToString()
        {
            return _name;
        }

        public string Name { get { return _name; } }
        public Type Type { get { return _type; } }

        public bool Equals(QualifiedName x, QualifiedName y)
        {
            if (x == null) return y == null;
            if (y == null) return false;
            if (x == y) return true;
            return (x._name == y._name && x._type == y._type);
        }

        public int GetHashCode(QualifiedName obj)
        {
            if (obj == null) return 0;
            int result = 0;
            if (obj._name != null) result += obj._name.GetHashCode();
            if (obj._type != null) result += obj._type.GetHashCode();
            return result;
        }
    }

    class QualifiedIdentifier : IEquatable<QualifiedIdentifier>
    {
        QualifiedName _name;
        object _value;

        private QualifiedIdentifier()
        {
        }

        public static QualifiedIdentifier GetPartial(QualifiedName name, string value)
        {
            return new QualifiedIdentifier()
            {
                _name = name,
                _value = value
            };
        }

        public static QualifiedIdentifier GetNested(params QualifiedIdentifier[] nested)
        {
            return new QualifiedIdentifier()
            {
                _value = nested
            };
        }
        public static QualifiedIdentifier GetArray(QualifiedName name, int dimensions)
        {
            return new QualifiedIdentifier()
            {
                _name = name,
                _value = dimensions
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            GetString(sb);
            return sb.ToString();
        }

        void GetString(StringBuilder sb)
        {
            if (_value == null)
            {
                sb.Append(_name);
            }
            else
            {
                if (_value is string)
                {
                    sb.Append(_name);
                    sb.Append('=');
                    sb.Append(_value);
                }
                else if (_value is int)
                {
                    sb.Append(_name);
                    sb.Append('[');
                    sb.Append(_value.ToString());
                    sb.Append(']');
                }
                else if (_value is QualifiedIdentifier[])
                {
                    sb.Append('(');
                    bool first = true;
                    foreach (QualifiedIdentifier id in (QualifiedIdentifier[])_value)
                    {
                        if (first)
                        {
                            first = false;
                        }
                        else
                        {
                            sb.Append(' ');
                        }
                        id.GetString(sb);
                    }
                    sb.Append(')');
                }
            }
        }

        public override int GetHashCode()
        {
            int result = 0;
            if (_name != null) result = _name.GetHashCode();
            if (_value != null)
            {
                if (_value is string)
                {
                    result += _value.GetHashCode();
                }
                else if (_value is int)
                {
                    result += _value.GetHashCode();
                }
                else if (_value is QualifiedIdentifier[])
                {
                    foreach (QualifiedIdentifier id in ((QualifiedIdentifier[])_value))
                    {
                        result += id.GetHashCode();
                    }
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            QualifiedIdentifier id = obj as QualifiedIdentifier;
            if (id == null) return false;
            return this.Equals(id);
        }

        public bool Equals(QualifiedIdentifier y)
        {
            if (_name != y._name) return false;
            if (_value == null) return y._value == null;
            if (y._value == null) return false;
            if (y._value.GetType() != _value.GetType()) return false;

            if (_value is string)
            {
                return ((string)_value) == ((string)y._value);
            }
            else if (_value is int)
            {
                return ((int)_value) == ((int)y._value);
            }
            else if (_value is QualifiedIdentifier[])
            {
                QualifiedIdentifier[] a = (QualifiedIdentifier[])_value;
                QualifiedIdentifier[] b = (QualifiedIdentifier[])y._value;
                if (a.Length != b.Length) return false;
                for (int i = 0, n = a.Length; i < n; i++)
                {
                    QualifiedIdentifier u = a[i];
                    QualifiedIdentifier v = b[i];
                    if (!u.Equals(v)) return false;
                }
            }
            return true;
        }
    }
}
