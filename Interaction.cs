using System;
namespace CMDengine
{
    struct Interaction
    {
        public Interaction(string i_message, int[] i_responses_id)
        {
            _message = i_message;
            _responses_ids = i_responses_id;
        }
        string _message;
        int[] _responses_ids;
        public void Execute()
        {
            Console.WriteLine(_message);
            Response[] _responses = new Response[_responses_ids.Length];
            for (int i = 0; i < _responses_ids.Length; i++)
            {
                _responses[i] = DataContainer.GetResponse(_responses_ids[i]);
            }
            InputManager.recieve(_responses);
        }
    }
}