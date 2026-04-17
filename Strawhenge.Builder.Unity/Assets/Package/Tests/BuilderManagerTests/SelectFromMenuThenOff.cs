using NUnit.Framework;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class SelectFromMenuThenOff : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeOpenMenu();
            InvokeSelectFromMenu(BlueprintSamples.Wall.Name);
            BuilderOff();
        }

        protected override IEnumerable<IBlueprint> GetBlueprints()
        {
            yield return BlueprintSamples.Wall;
        }

        [Test]
        public void Build_item_selector_should_disable()
        {
            Assert.False(IsExistingBuildItemSelectorEnabled());
        }

        [Test]
        public void Should_disable_builder_manager_UI()
        {
            Assert.False(IsBuilderManagerUIEnabled());
        }

        [Test]
        public void Menu_should_be_closed()
        {
            Assert.False(IsMenuOpen());
        }
    }
}