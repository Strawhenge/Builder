using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItemController : IBuildItemController
    {
        readonly IBuildItemControls _buildItemControls;

        IBuildItem _currentBuildItem;
        IBuildItemPreview _currentPreview;
        Func<bool> _canPlaceFinalItem;
        Action _onPlacedFinalItem;
        Action _onCancelled;

        public BuildItemController(IBuildItemControls buildItemControls)
        {
            _buildItemControls = buildItemControls;

            ResetCallbacks();
        }

        public UpdatablePosition LastPlacedPosition { get; } = new UpdatablePosition();

        public void PreviewOn(IBuildItem buildItem, Func<bool> canPlaceFinalItem = null, Action onPlacedFinalItem = null, Action onCancelled = null)
        {
            _currentBuildItem?.Cancel();
            _currentBuildItem = buildItem;

            _canPlaceFinalItem = canPlaceFinalItem ?? (() => true);
            _onPlacedFinalItem = onPlacedFinalItem ?? (() => { });
            _onCancelled = onCancelled ?? (() => { });

            _currentPreview = buildItem.Preview();
            ControlsOn();
        }      

        public void PreviewOff()
        {
            _currentBuildItem?.Cancel();
            _currentBuildItem = null;

            ControlsOff();

            var callback = _onCancelled;
            ResetCallbacks();
            callback();
        }

        void SpawnFinalItem()
        {
            if (_currentBuildItem == null || _currentPreview == null || !_canPlaceFinalItem())
                return;

            _currentBuildItem.PlaceFinal();
            _currentBuildItem = null;

            ControlsOff();

            LastPlacedPosition.Update(_currentPreview.Position, _currentPreview.Rotation);

            var callback = _onPlacedFinalItem;
            ResetCallbacks();
            callback();
        }

        void ControlsOn()
        {
            _buildItemControls.PlaceBuildItem += SpawnFinalItem;
            _buildItemControls.ControlOn(_currentPreview);
        }

        void ControlsOff()
        {
            _buildItemControls.PlaceBuildItem -= SpawnFinalItem;
            _buildItemControls.ControlOff();
        }

        void ResetCallbacks()
        {
            _canPlaceFinalItem = () => true;
            _onPlacedFinalItem = () => { };
            _onCancelled = () => { };
        }
    }
}