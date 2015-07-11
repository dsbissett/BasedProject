using System;
using System.Messaging;
using Based.Messaging.Utilities;

namespace Based.Messaging
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class QueueService<TMsg> : IQueueService<TMsg>
    {
        private static readonly TimeSpan timeout = TimeSpan.FromSeconds(30.0);

        public void Send(TMsg msg)
        {
            using (var scope = new MessageQueueTransaction())            
            {
                try
                {
                    using (var queue = new MessageQueue())
                    {
                        scope.Begin();
                        
                        var message = new Message
                        {
                            BodyStream = msg.ToJsonStream(),
                            Label      = msg.GetMessageType()
                        };

                        queue.DefaultPropertiesToSend.Recoverable = true;
                        queue.Formatter = new BinaryMessageFormatter();
                        queue.Send(message, MessageQueueTransactionType.Automatic);

                        scope.Commit();
                    }
                }
                catch (Exception)
                {
                    scope.Abort();
                }
            }            
        }

        public TMsg Recieve()
        {
            using (var queue = new MessageQueue())
            {
                var message = queue.Receive(timeout, MessageQueueTransactionType.Automatic);

                return message.BodyStream.ReadFromJson<TMsg>();
            }
        }
    }
}
