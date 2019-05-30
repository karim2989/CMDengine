namespace CMDengine
{
    struct PunchCard
    {
        public PunchCard(string i_name, string i_creator, Response[] i_responses, Interaction[] i_interactions)
        {
            Name = i_name;
            Creator = i_creator;
            responses = i_responses;
            interactions = i_interactions;
        }
        public string Name;
        public string Creator;
        public Response[] responses;
        public Interaction[] interactions;


    }
}