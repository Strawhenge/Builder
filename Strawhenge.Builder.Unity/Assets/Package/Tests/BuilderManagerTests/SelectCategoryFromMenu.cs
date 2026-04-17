using NUnit.Framework;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class SelectCategoryFromMenu : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeOpenMenu();
            InvokeSelectCategoryFromMenu(BlueprintSamples.Furniture.CategoryName);
        }

        protected override IEnumerable<IBlueprint> GetBlueprints()
        {
            yield return BlueprintSamples.Wall;
            yield return BlueprintSamples.Furniture.Chair;
        }

        [Test]
        public void Menu_should_be_open()
        {
            VerifyMenuIsOpen();
        }

        [Test]
        public void Menu_should_show_items()
        {
            VerifyMenuIsShowingItems(BlueprintSamples.Furniture.Chair.Name);
        }
    }
}