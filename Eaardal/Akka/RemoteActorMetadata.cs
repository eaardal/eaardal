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
            RemotePath = string.Format("{0}{1}", FormatPathEnd(remoteBasePath), Path);
        }

        private static string FormatPathEnd(string remoteBasePath)
        {
            return remoteBasePath.EndsWith("/")
                ? remoteBasePath.Substring(0, remoteBasePath.LastIndexOf("/", StringComparison.Ordinal))
                : remoteBasePath;
        }
    }
}