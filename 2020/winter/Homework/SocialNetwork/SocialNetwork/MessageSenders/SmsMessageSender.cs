using System;

namespace SocialNetwork.MessageSenders
{
    public class SmsMessageSender:IMessageSender
    {
        public void Send(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}