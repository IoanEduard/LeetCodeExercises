using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Code.Observer_Pattern.Example_One
{
    public class EmailAlertsListener : IEventListener
    {
        private string _message;
        private string _email;

        public EmailAlertsListener(string email, string message)
        {
            _message = message;
            _email = email;
        }

        public void Update(string filename)
        {
            Console.WriteLine($"Message: {_message}: {filename}\n Sending notification to Email: {_email}");
        }
    }
}
