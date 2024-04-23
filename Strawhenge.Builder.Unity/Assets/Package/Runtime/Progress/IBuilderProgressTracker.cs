using Strawhenge.Builder.Unity.Monobehaviours;

namespace Strawhenge.Builder.Unity.Progress
{
    public interface IBuilderProgressTracker
    {
        void Add(BuildItemScript script, string blueprintName);

        void Update(BuildItemScript script);

        void Remove(BuildItemScript script);

        void Clear();
    }
}