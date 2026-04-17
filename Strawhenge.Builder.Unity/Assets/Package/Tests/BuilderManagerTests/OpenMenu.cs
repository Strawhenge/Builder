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
            Assert.True(IsMenuOpen());
        }

        [Test]
        public void Menu_should_show_categories()
        {
            Assert.True(
                IsMenuShowingCategories(BlueprintSamples.Furniture.CategoryName));
        }

        [Test]
        public void Menu_should_show_items()
        {
            Assert.True(
                IsMenuShowingItems(BlueprintSamples.Wall.Name));
        }

        [Test]
        public void Build_item_selector_should_be_disabled()
        {
            Assert.False(IsExistingBuildItemSelectorEnabled());
        }

        [Test]
        public void Manager_UI_should_be_disabled()
        {
            Assert.False(IsBuilderManagerUIEnabled());
        }
    }
}