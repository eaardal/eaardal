using System;

namespace Eaardal.Akka
{
    public class RemoteActorMetadata : ActorMetadata
    {
        public string RemotePath { get; private set; }
        public string RemoteBasePath { get; private set; }
        public new RemoteActorMetadata Parent { get; private set; }

        public RemoteActorMetadata(string name, string remoteBasePath, RemoteActorMetadata parent = null)
            : base(name, parent)
        {
            Parent = parent;
            RemoteBasePath = remoteBasePath;
            RemotePath = string.Format("{0}{1}{2}", remoteBasePath, EndRemotePath(remoteBasePath), Path);
        }

        private static string EndRemotePath(string remoteBasePath)
        {
            return remoteBasePath.EndsWith("/")
                ? remoteBasePath.Substring(0, remoteBasePath.IndexOf("/", StringComparison.Ordinal))
                : "";
        }
    }
}