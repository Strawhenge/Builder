using Strawhenge.Builder.Unity.Monobehaviours;
using Strawhenge.Common.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Builder.Unity
{
    public class BuilderProgressTracker : IBuilderProgressTracker, IBuilderProgressAccessor
    {
        readonly ILogger _logger;

        readonly Dictionary<BuildItemScript, BuildItemData> _dataByScript =
            new Dictionary<BuildItemScript, BuildItemData>();

        public BuilderProgressTracker(ILogger logger)
        {
            _logger = logger;
        }

        public BuilderProgressData GetCurrentProgress()
        {
            return new BuilderProgressData
            {
                BuildItems = _dataByScript.Values.ToArray()
            };
        }

        public void Add(BuildItemScript script, string blueprintName)
        {
            if (_dataByScript.ContainsKey(script))
            {
                _logger.LogWarning($"Build item '{script.gameObject.name}' already being tracked.");
                Update(script);
                return;
            }

            var transform = script.transform;
            var data = new BuildItemData
            {
                Name = blueprintName,
                Position = transform.position,
                Rotation = transform.rotation
            };

            _dataByScript.Add(script, data);
        }

        public void Update(BuildItemScript script)
        {
            if (!_dataByScript.ContainsKey(script))
            {
                _logger.LogError($"Cannot update build item '{script.gameObject.name}', as it has not been added.");
                return;
            }

            var transform = script.transform;
            var data = _dataByScript[script];
            data.Position = transform.position;
            data.Rotation = transform.rotation;
        }

        public void Remove(BuildItemScript script)
        {
            if (!_dataByScript.ContainsKey(script))
            {
                _logger.LogWarning($"Cannot remove build item '{script.gameObject.name}', as it wasn't being tracked.");
                return;
            }

            _dataByScript.Remove(script);
        }

        public void Clear()
        {
            _logger.LogInformation("Clearing builder progress.");
            _dataByScript.Clear();
        }
    }
}