namespace DesignPatterns.Code.Observer_Pattern.Example_One
{
    public class Editor
    {
        public EventManager _eventManager;

        public Editor()
        {
            _eventManager = new EventManager();
        }

        public void OpenFile(string path)
        {
            _eventManager.Notify("open", this.GetType().Name);
        }

        public void SaveFile()
        {
            _eventManager.Notify("save", this.GetType().Name);
        }

    }
}
