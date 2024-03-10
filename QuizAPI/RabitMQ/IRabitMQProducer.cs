namespace QuizAPI.RabitMQ
{
    public interface IRabitMQProducer
    {
        public void SendParticipantMessage<T>(T message);
    }
}
