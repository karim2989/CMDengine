using System;
namespace CMDengine
{
    struct Response
    {
        public Response(string i_argument, int i_interaction_id)
        {
            argument = i_argument;
            Next_Interaction = i_interaction_id;
        }
        public void Execute()
        {
            DataContainer.GetInteraction(Next_Interaction).Execute();
        }
        public string Argument
        {
            get { return argument; }
        }
        private string argument;
        private int Next_Interaction;
    }
}