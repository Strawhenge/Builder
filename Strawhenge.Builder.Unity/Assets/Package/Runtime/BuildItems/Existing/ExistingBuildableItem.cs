namespace Strawhenge.Builder.Unity.BuildItems.Existing
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