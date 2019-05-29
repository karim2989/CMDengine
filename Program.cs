using System;

namespace CMDengine
{
    class Program
    {
        static void Main(string[] args)
        {
            Response Response1 = new Response("yes",null,new Interaction());
            Interaction testInteraction = new Interaction(0,"Wanna help",new Response[] {Response1});
            testInteraction.Execute();
        }
    }
}
