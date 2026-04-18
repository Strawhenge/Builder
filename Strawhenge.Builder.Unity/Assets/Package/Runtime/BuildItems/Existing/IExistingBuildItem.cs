using Strawhenge.Builder.Unity.BuildItems.New;

namespace Strawhenge.Builder.Unity.BuildItems.Existing
{
    interface IExistingBuildItem : IBuildItem
    {
        void Scrap();
    }
}