using System;
namespace CMDengine
{
    static class InputManager
    {
        public static void recieve(Response[] interaction_responses)
        {
            string user_input = Console.ReadLine();
            //Engine commands
            switch (user_input)
            {
                case "quit": { Environment.Exit(0); } break;
            }
            //Enteraction responses
            foreach (Response R in interaction_responses)
            {
                if (user_input == R.Argument)
                {
                    R.Execute();
                }
            }
            //else
            System.Console.WriteLine("Unrecognized response");
            recieve(interaction_responses);
        }
    }
}