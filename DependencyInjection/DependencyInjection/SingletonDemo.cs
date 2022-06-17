using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    class SingletonDemo: ISingletonDemo
    {
        public SingletonDemo()
        {
            ObjectId = Guid.NewGuid();
        }
        public Guid ObjectId { get; }
    }
}
