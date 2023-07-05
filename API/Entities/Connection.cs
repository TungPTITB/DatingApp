namespace API.Entities
{
    public class Connection
    {
        public Connection()
        {
            
        }
        public Connection(string connectionId, string user)
        {
            ConnectionId = connectionId;
            User = user;
        }

        public string ConnectionId { get; set; }
        public string User { get; set; }
    }
}