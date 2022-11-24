using Strawhenge.Builder.Unity.BuildItems;

namespace Strawhenge.Builder.Unity
{
    public class ExistingBlueprint
    {
        public ExistingBlueprint(string identifier, IExistingBuildItem buildItem, ScrapValue scrapValue)
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