using System.ServiceModel;

namespace Based.Messaging
{
    [ServiceContract]
    public interface IQueueService<TMsg>
    {
        [OperationContract]
        void Send(TMsg msg);

        [OperationContract]
        TMsg Recieve();
    }
}