using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standalone.Messages
{
    public class StandaloneMessage : IMessage
    {
        public Guid Id { get; private set; }

        public string BodyContent { get; private set; }

        public static StandaloneMessage Create(string content)
        {
            return new StandaloneMessage
            {
                Id = Guid.NewGuid(),
                BodyContent = content
            };
        }
    }
}
