namespace Strawhenge.Builder.Menu
{
    public interface ICategory
    {
        string Name { get; }

        Maybe<ICategory> Parent { get; }
    }
}
