namespace Strawhenge.Builder.Menu
{
    public interface ICategorizable
    {
        string Name { get; }

        Maybe<Category> Category { get; }
    }
}
