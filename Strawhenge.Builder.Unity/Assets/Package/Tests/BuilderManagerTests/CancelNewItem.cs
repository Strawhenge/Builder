using NUnit.Framework;

namespace Strawhenge.Builder.Unity.Tests.BuilderManagerTests
{
    public class CancelNewItem : BaseBuilderManagerTest
    {
        protected override void Act()
        {
            Sut.On();
            InvokeOpenMenu();
            InvokeSelectFromMenu();
            InvokeCancelSelectedItem();
        }

        [Test]
        public void Menu_should_be_open()
        {
            Assert.True(IsMenuOpen());
        }
    }
}