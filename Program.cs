using System;
using System.IO;

namespace CMDengine
{
    class Program
    {
        static void Main(string[] args)
        {
            PunchCard game;
            if (File.Exists("AutoExe.PuchCard")) { game = PunchCardsManager.TXTfile2PunchCard("AutoExe.PuchCard"); }
            else
            {
                System.Console.WriteLine("specify a filepath for a punchcard");
                game = PunchCardsManager.TXTfile2PunchCard(Console.ReadLine());
            }
            Console.BackgroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine($"CMDengine now playing {game.Name} by {game.Creator} :");
            Console.ResetColor();
            DataContainer.FillContainer(game.responses, game.interactions);
            DataContainer.GetInteraction(0).Execute();
        }
    }
}
