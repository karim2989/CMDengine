using System.Collections.Generic;
namespace CMDengine
{
    static class DataContainer
    {
        public static string Status{
            get{return $"num of I {_interactionList.Length} num of R {_responseList.Length}";}
        }
        public static void FillContainer(Response[] Responses, Interaction[] interactions)
        {
            _responseList = Responses;
            _interactionList = interactions;
        }
        public static Interaction GetInteraction(int index)
        {
            if (index > _interactionList.Length)
            {
                System.Console.WriteLine("CMDengine : application failed(no interaction with index)"+index);
                System.Console.Beep();
            }
            return _interactionList[index];
        }
        public static Response GetResponse(int index)
        {
            if (index > _interactionList.Length)
            {
                System.Console.WriteLine("CMDengine : application failed(no response with index)"+index);
                System.Console.Beep();
            }
            return _responseList[index];
        }

        static Interaction[] _interactionList;
        static Response[] _responseList;

    }
}