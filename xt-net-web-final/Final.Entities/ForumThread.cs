namespace Final.Entities
{
    public class ForumThread
    {
        public int Id
        {
            get; set;
        }

        public int? AuthorId
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public string Message
        {
            get; set;
        }
    }
}