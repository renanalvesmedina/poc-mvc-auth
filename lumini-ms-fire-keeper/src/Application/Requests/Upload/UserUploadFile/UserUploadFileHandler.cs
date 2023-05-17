using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Lumini.FireKeeper.Application.Services.Upload;
using Lumini.FireKeeper.Data.Contexts;
using Lumini.FireKeeper.Domain.Catalogs;
using Lumini.FireKeeper.Domain.Entities.Upload;

namespace Lumini.FireKeeper.Application.Requests.Upload.UserUploadFile
{
    public class UserUploadFileHandler : Handler<UserUploadFileRequest>
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly DataContext _dataContext;

        public UserUploadFileHandler(IFileUploadService fileUploadService, DataContext dataContext)
        {
            _fileUploadService = fileUploadService;
            _dataContext = dataContext;
        }

        public override async Task<Result> Handle(UserUploadFileRequest request, CancellationToken cancellationToken)
        {
            var userUpload = new UserUpload
            {
                FileId = Guid.NewGuid(),
                UserId = request.UserId,
                FileOriginName = request.File.FileName,
                CreatedOn = DateTime.Now
            };

            var result = await _fileUploadService.Send(request.UserId.ToString(), userUpload.FileId.ToString(), request.File, cancellationToken);

            if(!result.IsSuccessful())
            {
                return Error(ErrorCatalog.WithMessage(result.Error.Message));
            }

            await _dataContext.AddAsync(userUpload, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
