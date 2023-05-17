namespace Lumini.FireKeeper.Domain.Entities.Upload
{
    public class UserUpload
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public Guid UserId { get; set; }
        public string FileOriginName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
