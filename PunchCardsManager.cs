using System;
using System.Collections.Generic;
using System.IO;
namespace CMDengine
{
    static class PunchCardsManager
    {
        public static PunchCard TXTfile2PunchCard(string filepath)
        {
            //extracting args from file
            string file = File.ReadAllText(filepath);
            file = file.Replace(Environment.NewLine, "");//remouve new lines
            string[] args = file.Split(';');
            FileNode[] nodes = new FileNode[args.Length];

            for (int i = 0; i < nodes.Length; i++)
            {
                string[] node = args[i].Split('~');
                if (node.Length < 2)
                {
                    Console.WriteLine("CMDengine Error : corrupt node (no body found)");
                    continue;
                }
                nodes[i] = new FileNode(node[0], node[1]);
            }
            //grouping args by type
            FileNode fileinfo_node;
            FileNode[] response_nodes;
            FileNode[] interaction_nodes;
            (fileinfo_node, response_nodes, interaction_nodes) = FileNode.GroupNodes(nodes);
            //creating punch card item
            string[] fileInfo = fileinfo_node.Body.Split('|');//analyse fileInfo
            Response[] responses = new Response[response_nodes.Length];
            Interaction[] interactions = new Interaction[interaction_nodes.Length];
            foreach (FileNode R in response_nodes)
            {
                string[] node_body = R.Body.Split('|');
                responses[R.id] = new Response(node_body[0], Convert.ToInt32(node_body[1]));
            }
            foreach (FileNode R in interaction_nodes)
            {
                string[] node_body = R.Body.Split('|');
                string[] response_ids_string = node_body[1].Split(',');
                int[] response_ids_int = new int[response_ids_string.Length];
                for (int i = 0; i < response_ids_string.Length; i++)
                {
                    response_ids_int[i] = Convert.ToInt32(response_ids_string[i]);
                }
                interactions[R.id] = new Interaction(node_body[0], response_ids_int);
            }


            PunchCard output = new PunchCard(fileInfo[0], fileInfo[1], responses, interactions);
            return output;
        }

    }
}