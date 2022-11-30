namespace HelperFunctions
{
    public interface IDisplay<T>
    {
        void DisplaySingleResult(T input);
        void DisplayCollection(IEnumerable<T> collection);
    }
}