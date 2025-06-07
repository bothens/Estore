using Application_Layer.Common.Results;
using Application_Layer.Interfaces.UserInterface;
using AutoMapper;
using MediatR;

namespace Application_Layer.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, OperationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userrepository, IMapper mapper)
        {
            _userRepository = userrepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userToDelete = await _userRepository.RemoveUserAsync(request.UserID);

                if (userToDelete == null)
                {
                    return OperationResult.Failure("Error: User to delete not found!");
                }

                return OperationResult.SuccessOBJ(
                    $"Successfully deleted user: {userToDelete.Username}",
                    userToDelete);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error: {ex.Message}");
            }
        }
    }
}
