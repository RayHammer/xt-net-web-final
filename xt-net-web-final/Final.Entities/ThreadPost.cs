namespace Final.Entities
{
    public class ThreadPost
    {
        public int Id
        {
            get; set;
        }

        public int ThreadId
        {
            get; set;
        }

        public int? AuthorId
        {
            get; set;
        }

        public string Message
        {
            get; set;
        }
    }
}