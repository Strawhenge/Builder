using NUnit.Framework;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class OpenMenu : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeOpenMenu();
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
        public void Menu_should_show_categories()
        {
            VerifyMenuIsShowingCategories(BlueprintSamples.Furniture.CategoryName);
        }

        [Test]
        public void Menu_should_show_items()
        {
            VerifyMenuIsShowingItems(BlueprintSamples.Wall.Name);
        }

        [Test]
        public void Build_item_selector_should_be_disabled()
        {
            VerifyExistingBuildItemSelectorDisabled();
        }

        [Test]
        public void Manager_UI_should_be_disabled()
        {
            VerifyBuilderManagerUIDisabled();
        }
    }
}