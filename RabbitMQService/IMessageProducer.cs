namespace student_registration.RabbitMQService
{
    public interface IMessageProducer
    {
        void SendMessage<T> (T message);
    }
}