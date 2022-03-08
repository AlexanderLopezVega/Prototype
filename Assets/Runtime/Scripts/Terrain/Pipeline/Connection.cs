using System;

namespace com.alexlopezvega.prototype.terrain.pipeline
{
    public class Connection
    {
        public Connection() : this(default, default) { }
        public Connection(Node source, Node destination, object data = default)
        {
            Source = source;
            Destination = destination;
            Data = data;
        }

        public Node Source { get; private set; }
        public Node Destination { get; private set; }
        public object Data { get; private set; }

        public Type GetDataType() => typeof(Data);
    }
}
