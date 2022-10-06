using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.UI
{
    public interface IScrapUI
    {
        void Show(string scrapName, IEnumerable<ScrapAddition> additions);

        void Hide();
    }
}