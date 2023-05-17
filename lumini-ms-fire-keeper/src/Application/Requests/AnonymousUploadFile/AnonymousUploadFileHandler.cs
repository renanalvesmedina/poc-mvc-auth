using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Lumini.FireKeeper.Application.Services.Upload;
using Lumini.FireKeeper.Data.Contexts;
using Lumini.FireKeeper.Domain.Catalogs;
using Lumini.FireKeeper.Domain.Entities.Upload;

namespace Lumini.FireKeeper.Application.Requests.AnonymousUploadFile
{
    public class AnonymousUploadFileHandler : Handler<AnonymousUploadFileRequest>
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly DataContext _dataContext;

        public AnonymousUploadFileHandler(IFileUploadService fileUploadService, DataContext dataContext)
        {
            _fileUploadService = fileUploadService;
            _dataContext = dataContext;
        }

        public override async Task<Result> Handle(AnonymousUploadFileRequest request, CancellationToken cancellationToken)
        {
            var anonymousUpload = new AnonymousUpload
            {
                Id = Guid.NewGuid(),
                FileId = Guid.NewGuid(),
                ContainerId = request.ContainerId,
                FileOriginName = request.File.FileName,
                CreatedOn = DateTime.Now
            };

            var result = await _fileUploadService.Send(anonymousUpload.ContainerId.ToString(), anonymousUpload.FileId.ToString(), request.File, cancellationToken);

            if (!result.IsSuccessful())
            {
                return Error(ErrorCatalog.WithMessage(result.Error.Message));
            }

            await _dataContext.AddAsync(anonymousUpload, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
