using System;
namespace CMDengine
{
    struct Interaction
    {
        public Interaction(int id, string i_message, Response[] i_responses)
        {
            ID = id;
            _message = i_message;
            _responses = i_responses;
        }
        int ID;
        string _message;
        Response[] _responses;
        public void Execute()
        {
            Console.WriteLine(_message);
            InputManager.recieve(_responses);
        }
    }
}