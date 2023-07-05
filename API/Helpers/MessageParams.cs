namespace API.Helpers
{
    public class MessageParams : PaginationParams
    {
        public string User { get; set; }
        public string Container { get; set; } = "Unread";
    }
}