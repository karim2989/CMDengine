using System;
namespace CMDengine
{
    struct Response
    {
        public Response(string i_argument, Action i_action, Interaction i_interaction)
        {
            argument = i_argument;
            OnExecute = i_action;
            Next_Interaction = i_interaction;
        }
        public void Execute()
        {
            OnExecute();
            Next_Interaction.Execute();
        }
        public string Argument
        {
            get { return argument; }
        }
        private string argument;
        private Action OnExecute;
        private Interaction Next_Interaction;
    }
}