using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Monobehaviours;

namespace Strawhenge.Builder.Unity
{
    public class ExistingBlueprintFactory
    {
        public ExistingBlueprint Create(BuildItemScript buildItemScript)
        {
            var buildItem = new ExistingBuildItem(buildItemScript);
            var scrapValue = buildItemScript.ScrapValue;

            return new ExistingBlueprint(buildItemScript.name, buildItem, scrapValue);
        }
    }
}