using Strawhenge.Builder.Unity.BuildItems;

namespace Strawhenge.Builder.Unity
{
    public class Blueprint // TODO Rename this. 'Blueprint' refers to the data object. 
    {
        public Blueprint(string identifier, IBuildItem buildItem, Recipe recipe)
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