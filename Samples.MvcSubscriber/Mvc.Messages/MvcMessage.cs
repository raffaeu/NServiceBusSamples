using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Messages
{
    public class MvcMessage : IMessage
    {
        public Guid Id { get; private set; }

        public string BodyContent { get; private set; }

        public static MvcMessage Create(string content)
        {
            return new MvcMessage
            {
                Id = Guid.NewGuid(),
                BodyContent = content
            };
        }
    }
}
