using NUnit.Framework;
using Strawhenge.Builder.Unity.Blueprints;
using System.Collections.Generic;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests.TestCases
{
    public class CancelNewItem : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            BuilderOn();
            InvokeOpenMenu();
            InvokeSelectFromMenu(BlueprintSamples.Wall.Name);
            InvokeCancelSelectedItem();
        }

        protected override IEnumerable<IBlueprint> GetBlueprints()
        {
            yield return BlueprintSamples.Wall;
        }

        [Test]
        public void Menu_should_be_open()
        {
            VerifyMenuIsOpen();
        }
    }
}