public interface ICommunicator
{
    public Message GenerateMessage(Person recipient);
    public void ReceiveMessage(Message message);
    public void DeliverMessage(Message message);
}