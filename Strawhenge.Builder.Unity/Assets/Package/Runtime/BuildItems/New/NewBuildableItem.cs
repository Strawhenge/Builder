namespace Strawhenge.Builder.Unity.BuildItems.New
{
    class NewBuildableItem
    {
        public NewBuildableItem(string identifier, IBuildItem buildItem, Recipe recipe)
        {
            Identifier = identifier;
            BuildItem = buildItem;
            Recipe = recipe;
        }

        public string Identifier { get; }

        public IBuildItem BuildItem { get; }

        public Recipe Recipe { get; }
    }
}