namespace Eaardal.Akka
{
    public class ActorMetadata
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ActorMetadata Parent { get; set; }

        public ActorMetadata(string name, ActorMetadata parent = null)
        {
            Name = name;

            var parentPath = parent != null ? parent.Path : "/user";
            Path = string.Format("{0}/{1}", parentPath, Name);
        }
    }
}
