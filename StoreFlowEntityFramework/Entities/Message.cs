namespace StoreFlowEntityFramework.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageDetail { get; set; }
        public string SenderNameSurname { get; set; }
        public string SenderImageUrl { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRead { get; set; }
    }
}
