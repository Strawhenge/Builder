using Strawhenge.Builder.Unity.BuildItems;

namespace Strawhenge.Builder.Unity
{
    public class ExistingBlueprint
    {
        public ExistingBlueprint(string identifier, ExistingBuildItem buildItem, ScrapValue scrapValue)
        {
            Identifier = identifier;
            BuildItem = buildItem;
            ScrapValue = scrapValue;
        }

        public string Identifier { get; }

        public ExistingBuildItem BuildItem { get; }

        public ScrapValue ScrapValue { get; }
    }
}