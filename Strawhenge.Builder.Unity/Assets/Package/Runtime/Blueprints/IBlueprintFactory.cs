using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Builder.Unity.ScriptableObjects;

namespace Strawhenge.Builder.Unity.Blueprints
{
    public interface IBlueprintFactory
    {
        Blueprint Create(BlueprintScriptableObject scriptableObject);

        ExistingBlueprint Create(BuildItemScript script);
    }
}
