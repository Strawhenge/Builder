using Strawhenge.Builder.Unity.BuildItems;

namespace Strawhenge.Builder.Unity
{
    public class ExistingBuildableItem
    {
        public ExistingBuildableItem(string identifier, IExistingBuildItem buildItem, ScrapValue scrapValue)
        {
            Identifier = identifier;
            BuildItem = buildItem;
            ScrapValue = scrapValue;
        }

        public string Identifier { get; }

        public IExistingBuildItem BuildItem { get; }

        public ScrapValue ScrapValue { get; }
    }
}