namespace Bankbot
{
    public interface ICondition<T>
    {
        bool IsSatisfied(T request);
    }
}