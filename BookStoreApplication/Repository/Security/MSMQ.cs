using System;
using System.Collections.Generic;
using System.IO;
using Experimental.System.Messaging;
using Repository.Common;
using static Repository.Common.BookStoreException;

namespace BookStoreRepositoryLayer.JsonErrorHandler
{
    public class MSMQ
    {
        public void SendMessage(string msg, object value)
        {
            MessageQueue messageQueue = null;
            string description = msg;
            //string path = @".\Private$\temp";
            string path = @".\Private$\IDG";
            try
            {
                if (MessageQueue.Exists(path))
                {
                    messageQueue = new MessageQueue(path);
                    messageQueue.Label = description;
                }
                else
                {
                    MessageQueue.Create(path);
                    messageQueue = new MessageQueue(path);
                    messageQueue.Label = description;
                }
                string result = msg + value;
                messageQueue.Send(result, description);
            }
            catch(BookStoreException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string ReceiveMessage()
        {
            MessageQueue MyQueue = null;
            string result = null;
            string path = @".\Private$\temp";
            try
            {
                MyQueue = new MessageQueue(path);
                Message[] message = MyQueue.GetAllMessages();
                if (message.Length > 0)
                {
                    foreach (Message msg in message)
                    {
                        msg.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                        result = msg.Body.ToString();
                        MyQueue.Receive();
                        File.WriteAllText(@"E:\BookstoreApp\BookStoreApp_Cohart_B/ReceiveMessages.txt",result);
                         }
                    MyQueue.Refresh();
                }
                else
                {
                    Console.WriteLine("No Message");
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
