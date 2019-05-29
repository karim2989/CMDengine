using System.Collections.Generic;
namespace CMDengine
{
    static class DataContainer
    {
        public static Interaction GetInteraction(int index)
        {
            if (index > _interactionList.Length - 1)
            {
                System.Console.WriteLine("application failed");
                System.Console.Beep();
            }
            return _interactionList[index];
        }
        public static Response GetResponse(int index)
        {
            if (index > _interactionList.Length - 1)
            {
                System.Console.WriteLine("application failed");
                System.Console.Beep();
            }
            return _responseList[index];
        }

        static Interaction[] _interactionList;
        static Response[] _responseList;

    }
}