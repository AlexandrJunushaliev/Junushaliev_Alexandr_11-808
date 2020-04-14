using System;

namespace SocialNetwork.MessageSenders
{
    public class EmailMessageSender : IMessageSender
    {
        public void Send(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}