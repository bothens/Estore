using Application_Layer.Common.Results;
using Application_Layer.Interfaces.UserInterface;
using AutoMapper;
using Domain_Layer.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application_Layer.Commands.UserCommands.CreateAUser
{
    public class CreateAUserCommandHandler : IRequestHandler<CreateAUserCommand, OperationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateAUserCommandHandler(IUserRepository userrepository, IMapper mapper)
        {
            _userRepository = userrepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(CreateAUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(request.UserDto);

                var savedUser = await _userRepository.AddUserAsync(user);

                return OperationResult.SuccessOBJ(
                    $"Successfully created User: {savedUser.UserId} {savedUser.Username}",
                    savedUser);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error: {ex.Message}");
            }
        }
    }
}
