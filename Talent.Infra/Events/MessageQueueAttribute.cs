using System;

namespace Talent.Infra.Events
{
    public class MessageQueueAttribute : Attribute
    {
        // Private fields.
        private string name;
        private string queueType;
        // This constructor defines two required parameters: name and level.

        public MessageQueueAttribute(string name, string queueType)
        {
            this.name = name;
            this.queueType = queueType;            
        }

        
        public virtual string QueueName
        {
            get { return name; }
        }


        public virtual string QueueType
        {
            get { return queueType; }
        }

       
       
    }
}