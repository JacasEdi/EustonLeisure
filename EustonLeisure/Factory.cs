using System.Linq;

namespace EustonLeisure
{
    static class Factory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static Message Get(string messageId, string sender, string subject, string message)
        {
            var firstLetter = messageId.First();

            switch (firstLetter)
            {
                case 'E':
                    return new EmailMessage(sender, subject, message);
                case 'S':
                    return new SmsMessage(sender, message);
                case 'T':
                    return new TweetMessage(sender, message);
                default:
                    return null;
            }
        }
    }
}