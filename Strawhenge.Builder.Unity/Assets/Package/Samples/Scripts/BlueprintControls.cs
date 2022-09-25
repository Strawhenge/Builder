using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class BlueprintControls : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _turnSpeed;

        IBuildItemController _buildItemController;

        VerticalSnap _verticalSnap;
        HorizontalSnap _horizontalSnap;

        void Start()
        {
            _buildItemController = FindObjectOfType<Context>().BuildItemController;
        }

        void Update()
        {
            _buildItemController.CurrentPreview.Do(blueprint =>
            {
                if (_verticalSnap != null)
                {
                    HandleVerticalSnap();
                    return;
                }

                if (_horizontalSnap != null)
                {
                    HandleHorizontalSnap();
                    return;
                }

                ManageBlueprintMovement(blueprint);
                ManageBlueprintSnapping(blueprint);
            });

            if (Input.GetKeyDown(KeyCode.Return))
                _buildItemController.SpawnFinalItem();
        }

        void ManageBlueprintMovement(IBuildItemPreview blueprint)
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                blueprint.Move(_moveSpeed * Time.deltaTime * new Vector3(0, y, 0).normalized);
                blueprint.Turn(_turnSpeed * x * Time.deltaTime);
                return;
            }

            var direction = new Vector3(x, 0, y).normalized;
            blueprint.Move(_moveSpeed * Time.deltaTime * direction);
        }

        void ManageBlueprintSnapping(IBuildItemPreview blueprint)
        {
            if (!Input.GetKey(KeyCode.RightShift))
                return;

            _verticalSnap = blueprint.GetAvailableVerticalSnaps().FirstOrDefault();

            if (_verticalSnap != null)
            {
                _verticalSnap.Snap();
                return;
            }

            _horizontalSnap = blueprint.GetAvailableHorizontalSnaps().FirstOrDefault();

            if (_horizontalSnap != null)
            {
                _horizontalSnap.Snap();
                return;
            }
        }

        void HandleHorizontalSnap()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _horizontalSnap = null;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _horizontalSnap.Flip();
                return;
            }

            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Mathf.Abs(y) > 0.1f)
            {
                _horizontalSnap.Turn(-y * Time.deltaTime * _turnSpeed);
            }

            if (Mathf.Abs(x) > 0.01f)
            {
                _horizontalSnap.Slide(x * _moveSpeed * Time.deltaTime);
            }
        }

        void HandleVerticalSnap()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _verticalSnap = null;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _verticalSnap.TurnNext();
                return;
            }

            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Mathf.Abs(x) > 0.1f)
            {
                _verticalSnap.Turn(x * Time.deltaTime * _turnSpeed);
            }

            if (Mathf.Abs(y) > 0.01f)
            {
                _verticalSnap.Slide(y * _moveSpeed * Time.deltaTime);
            }
        }
    }
}
