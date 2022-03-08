using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.terrain.pipeline
{
    public abstract class Node
    {
        private ISet<Connection> inputConnectionSet = default;
        private ISet<Connection> outputConnectionSet = default;

        public Type GetConnectionType(ConnectionMode mode, string name)
        {
            switch(mode)
            {

            }
        }
    }
}
