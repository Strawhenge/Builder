using Strawhenge.Builder;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Builder.Unity.Factories;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Builder.Unity.UI;
using System.Linq;
using UnityEngine;

public class Context : MonoBehaviour
{
    [SerializeField] BlueprintScriptableObject blueprint;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;

    BlueprintManager blueprintManager;
    BlueprintFactory blueprintFactory;
    BlueprintScriptableObject currentBlueprint;

    VerticalSnap verticalSnap;
    HorizontalSnap horizontalSnap;

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

        if (verticalSnap != null)
        {
            HandleVerticalSnap();
            return;
        }

        if (horizontalSnap != null)
        {
            HandleHorizontalSnap();
            return;
        }

        blueprintManager.Preview.Do(blueprint =>
        {
            ManageBlueprintMovement(blueprint);
            ManageBlueprintSnapping(blueprint);
        });

        if (Input.GetKeyDown(KeyCode.Return))
            blueprintManager.Build();
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

    void ManageBlueprintMovement(IBuildItemPreview blueprint)
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            blueprint.Move(moveSpeed * Time.deltaTime * new Vector3(0, y, 0).normalized);
            blueprint.Turn(turnSpeed * x * Time.deltaTime);
            return;
        }

        var direction = new Vector3(x, 0, y).normalized;
        blueprint.Move(moveSpeed * Time.deltaTime * direction);
    }

    void ManageBlueprintSnapping(IBuildItemPreview blueprint)
    {
        if (!Input.GetKey(KeyCode.RightShift))
            return;

        verticalSnap = blueprint.GetAvailableVerticalSnaps().FirstOrDefault();

        if (verticalSnap != null)
        {
            verticalSnap.Snap();
            return;
        }

        horizontalSnap = blueprint.GetAvailableHorizontalSnaps().FirstOrDefault();

        if (horizontalSnap != null)
        {
            horizontalSnap.Snap();
            return;
        }
    }

    void HandleHorizontalSnap()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            horizontalSnap = null;
            return;
        }

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Mathf.Abs(x) >= 0.1)
                horizontalSnap.Flip();
            return;
        }

        if (Mathf.Abs(y) > 0.1f)
        {
            horizontalSnap.Turn(-y * Time.deltaTime * turnSpeed);
        }

        if (Mathf.Abs(x) > 0.01f)
        {
            horizontalSnap.Slide(x * moveSpeed * Time.deltaTime);
        }
    }

    void HandleVerticalSnap()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            verticalSnap = null;
            return;
        }

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (x >= 0.1)
                verticalSnap.TurnPrevious();

            if (x <= 0.1)
                verticalSnap.TurnNext();

            return;
        }

        if (Mathf.Abs(x) > 0.1f)
        {
            verticalSnap.Turn(x * Time.deltaTime * turnSpeed);
        }

        if (Mathf.Abs(y) > 0.01f)
        {
            verticalSnap.Slide(y * moveSpeed * Time.deltaTime);
        }
    }
}
