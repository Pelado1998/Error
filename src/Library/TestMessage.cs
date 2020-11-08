using System;

namespace Bankbot
{
    public class TestMessage: IMessage
    {
        String message{get;set;}
        String id {get;set;}
        string IMessage.message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IMessage.id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TestMessage(String text)
        {
            this.message = text;
            this.id = "123Rafa";
        }
    }
}