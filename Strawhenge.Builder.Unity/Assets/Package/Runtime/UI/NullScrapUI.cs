using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.UI
{
    public class NullScrapUI : IScrapUI
    {   
        public void Show(string scrapName, IEnumerable<ScrapAddition> additions)
        {
        }

        public void Hide()
        {
        }
    }
}