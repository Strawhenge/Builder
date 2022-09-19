namespace Strawhenge.Builder.Menu
{
    public class Category : ICategory
    {
        public Category(string name)
        {
            Name = name;
            Parent = Maybe.None<ICategory>();
        }

        public Category(string name, ICategory parent)
        {
            Name = name;
            Parent = Maybe.Some(parent);
        }

        public string Name { get; }

        public Maybe<ICategory> Parent { get; }
    }
}
