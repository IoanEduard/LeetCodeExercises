namespace DesignPatterns.Code.Observer_Pattern.Example_One
{
    public class LoggingAlertsListener : IEventListener
    {
        private string _message;

        public LoggingAlertsListener(string message)
        {
            _message = message;
        }

        public void Update(string filename)
        {
            Console.WriteLine($"{_message}: {filename}");
        }
    }
}
