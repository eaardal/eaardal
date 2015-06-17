using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eaardal.Akka;
using NUnit.Framework;

namespace Eaardal.UnitTests.AkkaTests
{
    [TestFixture]
    public class RemoteActorMetadataTests
    {
        private readonly string _defaultRemotePath = "akka://test-system@localhost:8080";

        [Test]
        public void SetsRemoteBasePath()
        {
            var meta = new RemoteActorMetadata("foo", _defaultRemotePath);

            Assert.AreEqual(_defaultRemotePath, meta.RemoteBasePath);
        }

        [Test]
        public void WithNoParent_SetsRemotePathTo_RemotePathSlashUserSlashName()
        {
            var meta = new RemoteActorMetadata("foo", _defaultRemotePath);

            Assert.AreEqual("akka://test-system@localhost:8080/user/foo", meta.RemotePath);
        }

        [Test]
        public void WithNoParent_WithBasePathWithNoTrailingSlash_RemotePathIsBasePathSlashUserSlashName()
        {
            var meta = new RemoteActorMetadata("foo", "akka://test-system@localhost:8080");

            Assert.AreEqual("akka://test-system@localhost:8080/user/foo", meta.RemotePath);
        }

        [Test]
        public void WithParent_RemotePathIsRemoteBasePathSlashUserSlashParentNameSlashName()
        {
            var parent = new RemoteActorMetadata("foo", _defaultRemotePath);
            var child = new RemoteActorMetadata("bar", _defaultRemotePath, parent);

            Assert.AreEqual(_defaultRemotePath + "/user/" + parent.Name + "/" + child.Name, child.RemotePath);
        }

        [Test]
        public void WithGrandParent_RemotePathIsRemoteBasePathSlashUserSlashGrandParentNameSlashParentNameSlashName()
        {
            var grandParent = new RemoteActorMetadata("foo", _defaultRemotePath);
            var parent = new RemoteActorMetadata("bar", _defaultRemotePath, grandParent);
            var child = new RemoteActorMetadata("xyz", _defaultRemotePath, parent);

            Assert.AreEqual(_defaultRemotePath + "/user/" + grandParent.Name + "/" + parent.Name + "/" + child.Name, child.RemotePath);
        }
    }
}
