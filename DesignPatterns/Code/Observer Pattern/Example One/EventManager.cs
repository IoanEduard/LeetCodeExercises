namespace DesignPatterns.Code.Observer_Pattern.Example_One
{
    public class EventManager
    {
        public List<EventListeners> Listeners { get; set; } = new List<EventListeners>();

        public void Subscribe(EventListeners eventListener)
        {
            Listeners.Add(eventListener);
        }

        public void Unsubscribe(EventListeners eventListener)
        {
            Listeners.Remove(eventListener);
        }

        public void Notify(string eventType, string data)
        {
            foreach (var item in Listeners)
            {
                if (item.EventType == eventType)
                    item.EventListener.Update(data);

            }
        }
    }

    public class EventListeners
    {
        public EventListeners(IEventListener eventListener, string eventType)
        {
            EventListener = eventListener;
            EventType = eventType;
        }

        public IEventListener EventListener { get; set; }
        public string EventType { get; set; }
    }
}
