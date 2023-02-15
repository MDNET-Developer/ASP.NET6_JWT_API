using MD.JWTApp.Back.Core.Application.Enums;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Commands;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IRepository<AppUser> _appuserRepo;

        public RegisterUserCommandHandler(IRepository<AppUser> appuserRepo)
        {
            _appuserRepo = appuserRepo;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _appuserRepo.CreateAsync(new AppUser()
            {
                UserName = request.UserName,
                Password = request.Password,
                AppRoleId = (int)RoleType.Member
            });
            return Unit.Value;
        }
    }
}
