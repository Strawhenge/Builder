using UnityEngine;

namespace Strawhenge.Builder.Unity.UI
{
    public class StandardScrapUIScript : BaseScrapUIScript
    {
        [SerializeField] BuildItemCompositionUIScript _buildItemCompositionUI;

        public override IScrapUI ScrapUI => _buildItemCompositionUI;
    }
}