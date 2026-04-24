using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.UI.Scrap
{
    public class NullScrapUI : IScrapUI
    {
        public static IScrapUI Instance { get; } = new NullScrapUI();

        NullScrapUI()
        {
        }

        public void Show(string scrapName, IEnumerable<ScrapAddition> additions)
        {
        }

        public void Hide()
        {
        }
    }
}