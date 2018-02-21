using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class StateTests
    {
        [TestMethod]
        public void SetMetadata_Should_UpdateStateMetadata()
        {
            var metadata = new StateMetadata
            {
                Value = State.Ok.Value,
                Priority = 1,
                Icon = "icon",
                Color = "color",
                DisplayName = "name",
            };

            var metadataCollection = new StateMetadata[] { metadata };

            State.SetMetadata(metadataCollection);

            Assert.AreEqual(metadataCollection[0].Icon, State.Ok.Metadata.Icon);
            Assert.AreEqual(metadataCollection[0].Color, State.Ok.Metadata.Color);
            Assert.AreEqual(metadataCollection[0].Value, State.Ok.Metadata.Value);
            Assert.AreEqual(metadataCollection[0].Priority, State.Ok.Metadata.Priority);
            Assert.AreEqual(metadataCollection[0].DisplayName, State.Ok.Metadata.DisplayName);
        }
    }
}
