using Strawhenge.Builder;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Factories;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.UI;
using UnityEngine;

public class Context : MonoBehaviour
{
    [SerializeField] BlueprintScriptableObject blueprint;
    [SerializeField] float moveSpeed;

    BlueprintManager blueprintManager;
    BlueprintFactory blueprintFactory;
    BlueprintScriptableObject currentBlueprint;

    void Awake()
    {
        var logger = new UnityLogger(gameObject);
        var inventory = new ComponentInventory(logger);
        var buildItemController = new BuildItemController();
        var recipeFactory = new RecipeFactory();
        var spawner = new Spawner();

        blueprintFactory = new BlueprintFactory(recipeFactory, spawner, logger);
        blueprintManager = new BlueprintManager(inventory, buildItemController, new NullRecipeUI())
        {
            DefaultPosition = transform.position
        };
    }

    void Update()
    {
        SelectBlueprint();
        ManageBlueprint();

        if (Input.GetKeyDown(KeyCode.Return))
            blueprintManager.Build();
    }

    void ManageBlueprint()
    {
        blueprintManager.Preview.Do(blueprint =>
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");
            var direction = new Vector3(x, 0, y).normalized;
            blueprint.Move(moveSpeed * Time.deltaTime * direction);
        });
    }

    void SelectBlueprint()
    {
        if (blueprint == currentBlueprint)
            return;

        if (blueprint == null)
        {
            currentBlueprint = null;
            blueprintManager.Unset();
            return;
        }

        currentBlueprint = blueprint;
        blueprintManager.Set(
            blueprintFactory.Create(blueprint));
    }
}
