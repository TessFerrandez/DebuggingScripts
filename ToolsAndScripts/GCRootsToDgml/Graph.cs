using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace GCRootsToDgml
{
    class Graph
    {
        Nodes _nodes = new Nodes();
        Links _links = new Links();

        public Graph()
        {
        }

        public Nodes Nodes { get { return _nodes; } }
        public Links Links { get { return _links; } }

        internal const string DgmlNamespace = "http://schemas.microsoft.com/vs/2009/dgml";

        public void Save(string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true
            };
            
            using (XmlWriter w = XmlWriter.Create(fileName, settings))
            {
                w.WriteStartElement("DirectedGraph", DgmlNamespace);
                _nodes.WriteTo(w);
                _links.WriteTo(w);                
                w.WriteEndElement();
            }
        }
    }

    class Nodes : IEnumerable<Node>
    {
        Dictionary<QualifiedIdentifier, Node> _nodes = new Dictionary<QualifiedIdentifier,Node>();

        public Node GetOrCreate(QualifiedIdentifier id, string label)
        {
            Node result = null;
            if (!_nodes.TryGetValue(id, out result))
            {
                result = new Node(id, label);
                _nodes[id] = result;
            }
            return result;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return _nodes.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _nodes.Values.GetEnumerator();
        }

        internal void WriteTo(XmlWriter w)
        {
            w.WriteStartElement("Nodes", Graph.DgmlNamespace);

            foreach (Node node in this)
            {
                node.WriteTo(w);
            }

            w.WriteEndElement();
        }
    }


    class Links : IEnumerable<Link>
    {
        Dictionary<QualifiedIdentifier, Link> _links = new Dictionary<QualifiedIdentifier, Link>();

        public Link GetOrCreate(Node source, Node target)
        {
            QualifiedIdentifier linkKey = QualifiedIdentifier.GetNested(source.Id, target.Id);
            Link result = null;
            if (!_links.TryGetValue(linkKey, out result))
            {
                result = new Link(source, target);
                _links[linkKey] = result;
            }
            return result;
        }

        public IEnumerator<Link> GetEnumerator()
        {
            return _links.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _links.Values.GetEnumerator();
        }

        internal void WriteTo(XmlWriter w)
        {
            w.WriteStartElement("Links", Graph.DgmlNamespace);

            foreach (Link link in this)
            {
                link.WriteTo(w);
            }

            w.WriteEndElement();
        }
    }

    class Node
    {
        QualifiedIdentifier _id;
        string _label;

        public Node(QualifiedIdentifier id, string label)
        {
            _id = id;
            _label = label;
        }

        public QualifiedIdentifier Id { get { return _id; } }
        public string Label { get { return _label; } }

        internal void WriteTo(XmlWriter w)
        {
            w.WriteStartElement("Node", Graph.DgmlNamespace);
            w.WriteAttributeString("Id", _id.ToString());
            w.WriteAttributeString("Label", _label);            
            w.WriteEndElement();
        }
    }

    class Link
    {
        Node _source;
        Node _target;

        public Link(Node source, Node target)
        {
            _source = source;
            _target = target;
        }

        public Node Source { get { return _source; } }
        public Node Target { get { return _target; } }


        internal void WriteTo(XmlWriter w)
        {
            w.WriteStartElement("Link", Graph.DgmlNamespace);
            w.WriteAttributeString("Source", _source.Id.ToString());
            w.WriteAttributeString("Target", _target.Id.ToString());
            w.WriteEndElement();
        }
    }
}
