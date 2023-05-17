namespace Lumini.FireKeeper.Domain.Entities.Upload
{
    public class AnonymousUpload
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public Guid ContainerId { get; set; }
        public string FileOriginName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
