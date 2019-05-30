using System;
using System.Collections.Generic;
namespace CMDengine
{
    struct FileNode
    {
        public FileNode(string i_key, string i_body)
        {
            key = i_key;
            body = i_body;
            id = -1;
        }
        public int id;
        string key;
        string body;

        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public string Key
        {
            get { return key; }
        }


        public static FileNode SplitArgument(string input)
        {
            FileNode output = new FileNode();
            output.key = input.Split('~')[0];
            output.body = input.Split('~')[1];
            return output;
        }
        public static FileNode[] GetNodesWithKey(string key, FileNode[] input)
        {
            List<FileNode> output = new List<FileNode>();
            foreach (FileNode node in input)
            {
                if (node.key == key) { output.Add(node); }
            }
            return output.ToArray();
        }
        public static FileNode GetNodeWithKey(string key, FileNode[] input)
        {
            foreach (FileNode node in input)
            {
                if (node.key == key) { return node; }
            }
            System.Console.WriteLine($"CMDengine Error : FileNode of key {key} was not found .");
            return new FileNode();
        }
        public static (FileNode fileinfo, FileNode[] responses, FileNode[] interactions) GroupNodes(FileNode[] input)
        {
            FileNode fileinfo = new FileNode();
            List<FileNode> responses = new List<FileNode>();
            List<FileNode> interactions = new List<FileNode>();

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i].Key.ToCharArray()[0])
                {
                    case 'R': { input[i].id = Convert.ToInt32(input[i].key.Split('|')[1]); responses.Add(input[i]); } continue;// R for respose
                    case 'I': { input[i].id = Convert.ToInt32(input[i].key.Split('|')[1]); interactions.Add(input[i]); } continue;//I for interaction
                    case 'F': { fileinfo = input[i]; } continue;//F for FileInfo
                    default: { System.Console.WriteLine($"CMDengine Error : corrupt node(no key found for {input[i].key.ToCharArray()[0] })"); } continue;
                }
            }
            if (fileinfo.Body == "")
            {
                fileinfo.Body = "Name-less punchcard|Unspecified creator";
            }
            return (fileinfo, responses.ToArray(), interactions.ToArray());
        }
    }
}