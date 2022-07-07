namespace Console.Models
{
    public class Mock
    {
        public string Message { get; set; }

        public Mock()
        {
            Message = "Your princess was in another castle.";
        }

        public Mock(string message)
        {
            Message = message;
        }
    }
}