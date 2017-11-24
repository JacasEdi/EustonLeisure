namespace EustonLeisure
{
    /// <summary>
    /// Abstract class from which specific kinds of messages (such as SMS or Email) derive.
    /// </summary>
    public abstract class Message
    {
        public abstract string MessageId { get; set; }

        public abstract string Sender { get; set; }

        public abstract string Body { get; set; }

        protected abstract bool IsValid(string sender, string message);
    }
}