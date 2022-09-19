using Strawhenge.Builder.Menu;

namespace Strawhenge.Builder.Tests.Menu
{
    class SampleBuildItem : ICategorizable
    {
        public const string STRUCTURE = "Structure";
        public const string FURNITURE = "Furniture";
        public const string DECORATIVE_FURNITURE = "Decorative Furniture";

        public static SampleBuildItem Wall { get; } = new SampleBuildItem { Name = nameof(Wall) };

        public static SampleBuildItem Floor { get; } = new SampleBuildItem { Name = nameof(Floor) };

        public static SampleBuildItem Roof { get; } = new SampleBuildItem { Name = nameof(Roof) };

        public static SampleBuildItem Chair { get; } = new SampleBuildItem { Name = nameof(Chair) };

        public static SampleBuildItem Table { get; } = new SampleBuildItem { Name = nameof(Table) };

        public static SampleBuildItem Box { get; } = new SampleBuildItem { Name = nameof(Box) };

        public static SampleBuildItem Barrel { get; } = new SampleBuildItem { Name = nameof(Barrel) };

        public static SampleBuildItem Poster { get; } = new SampleBuildItem { Name = nameof(Poster) };

        public static SampleBuildItem Painting { get; } = new SampleBuildItem { Name = nameof(Painting) };

        public string Name { get; set; }

        public Maybe<ICategory> Category { get; set; } = Maybe.None<ICategory>();

        public SampleBuildItem InCategory(string category)
        {
            Category = Maybe.Some<ICategory>(new Category(category));
            return this;
        }

        public SampleBuildItem InCategory(string category, string parentCategory)
        {
            Category = Maybe.Some<ICategory>(new Category(category, new Category(parentCategory)));
            return this;
        }

        public static SampleBuildItem[] GetItemsWithoutCategories()
        {
            return new SampleBuildItem[]
            {
                Box,
                Barrel
            };
        }

        public static SampleBuildItem[] GetItemsInStructureCategory()
        {
            return new SampleBuildItem[]
            {
                Wall.InCategory(STRUCTURE),
                Floor.InCategory(STRUCTURE),
                Roof.InCategory(STRUCTURE)
            };
        }

        public static SampleBuildItem[] GetItemsInFurnitureCategory()
        {
            return new SampleBuildItem[]
            {
                Chair.InCategory(FURNITURE),
                Table.InCategory(FURNITURE)
            };
        }

        public static SampleBuildItem[] GetItemsInDecorativeFurnitureCategory()
        {
            return new SampleBuildItem[]
            {
                Poster.InCategory(DECORATIVE_FURNITURE, parentCategory: FURNITURE),
                Painting.InCategory(DECORATIVE_FURNITURE, parentCategory: FURNITURE)
            };
        }
    }
}
