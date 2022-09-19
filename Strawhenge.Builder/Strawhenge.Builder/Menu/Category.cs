namespace Strawhenge.Builder.Menu
{
    public class Category
    {
        public Category(string name)
        {
            Name = name;
            Parent = Maybe.None<Category>();
        }

        public Category(string name, Category parent)
        {
            Name = name;
            Parent = Maybe.Some(parent);
        }

        public string Name { get; }

        public Maybe<Category> Parent { get; }
    }
}
