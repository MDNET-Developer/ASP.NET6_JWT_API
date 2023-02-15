using MD.JWTApp.Back.Core.Application.Dtos;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Queries;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _appuserRepo;
        private readonly IRepository<AppRole> _approleRepo;

        public CheckUserRequestHandler(IRepository<AppUser> appuserRepo, IRepository<AppRole> approleRepo)
        {
            _appuserRepo = appuserRepo;
            _approleRepo = approleRepo;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            //daxil etdiyimiz elementler elimizde olsun
            var dto = new CheckUserResponseDto();

            var user = await _appuserRepo.GetByFilterAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await _approleRepo.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definiton;
            }
            return dto;
        }
    }
}
