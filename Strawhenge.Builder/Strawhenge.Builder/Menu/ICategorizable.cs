using FunctionalUtilities;

namespace Strawhenge.Builder.Menu
{
    public interface ICategorizable
    {
        string Name { get; }

        Maybe<ICategory> Category { get; }
    }
}
