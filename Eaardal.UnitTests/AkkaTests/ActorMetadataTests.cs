using Eaardal.Akka;
using NUnit.Framework;

namespace Eaardal.UnitTests.AkkaTests
{
    public class ActorMetadataTests
    {
        [Test]
        public void SetsName()
        {
            const string name = "foo";

            var meta = new ActorMetadata(name);

            Assert.AreEqual(name, meta.Name);
        }

        [Test]
        public void WhenNoParent_PathIsSlashUserSlashName()
        {
            const string name = "foo";

            var meta = new ActorMetadata(name);

            Assert.AreEqual("/user/" + name, meta.Path);
        }

        [Test]
        public void WithParent_PathIsSlashUserSlashParentNameSlashName()
        {
            const string parentName = "foo";
            const string name = "bar";
            
            var parent = new ActorMetadata(parentName);
            var meta = new ActorMetadata(name, parent);

            Assert.AreEqual("/user/" + parentName + "/" + name, meta.Path);
        }

        [Test]
        public void WithGrandParent_PathIsSlashUserSlashGrandParentNameSlashParentName()
        {
            const string grandParentName = "foo";
            const string parentName = "bar";
            const string name = "xyz";

            var grandParent = new ActorMetadata(grandParentName);
            var parent = new ActorMetadata(parentName, grandParent);
            var meta = new ActorMetadata(name, parent);

            Assert.AreEqual("/user/" + grandParentName + "/" + parentName + "/" + name, meta.Path);
        }
    }
}
