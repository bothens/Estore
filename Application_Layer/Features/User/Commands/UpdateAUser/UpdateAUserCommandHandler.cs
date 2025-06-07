using Application_Layer.Commands.UserCommands.CreateAUser;
using Application_Layer.Common.Results;
using Application_Layer.Interfaces.UserInterface;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application_Layer.Commands.UserCommands.UpdateAUser
{
    public class UpdateAUserCommandHandler : IRequestHandler<UpdateAUserCommand, OperationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateAUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(UpdateAUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _userRepository.GetUserByIdAsync(request.UserResponseDto.UserId);

                if (existingUser == null)
                {
                    return OperationResult.Failure($"User with ID {request.UserResponseDto.UserId} not found.");
                }

                _mapper.Map(request.UserResponseDto, existingUser);
                await _userRepository.UpdateUserAsync(existingUser);

                return OperationResult.SuccessOBJ(
                    $"Successfully updated user details:\nID: {existingUser.UserId}\nUsername: {existingUser.Username}\nEmail: {existingUser.Email}\nFirstName: {existingUser.Username}",
                    existingUser);
            }
            catch (Exception)
            {
                return OperationResult.Failure($"Failed to update user with ID: {request.UserResponseDto.UserId}");
            }
        }
    }
}
