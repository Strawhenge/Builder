using NUnit.Framework;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests.TestCases
{
    public class SelectFromMenu : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeOpenMenu();
            InvokeSelectFromMenu(BlueprintSamples.Wall.Name);
        }

        protected override IEnumerable<IBlueprint> GetBlueprints()
        {
            yield return BlueprintSamples.Wall;
        }

        [Test]
        public void Menu_should_be_closed()
        {
            VerifyMenuIsNotOpen();
        }

        [Test]
        public void Build_item_should_be_controlled()
        {
            VerifyBuildItemControlsEnabled();
        }
    }
}