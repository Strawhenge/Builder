using Strawhenge.Builder.Unity.BuildItems.New;

namespace Strawhenge.Builder.Unity.BuildItems.Existing
{
    public interface IExistingBuildItem : IBuildItem
    {
        void Scrap();
    }
}