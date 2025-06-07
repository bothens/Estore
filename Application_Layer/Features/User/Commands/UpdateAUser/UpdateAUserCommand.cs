using Application_Layer.Common.Results;
using Application_Layer.Dtos.UserDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Commands.UserCommands.UpdateAUser
{
    public class UpdateAUserCommand : IRequest<OperationResult>
    {
        public UserResponseDto UserResponseDto { get; set; }

        public UpdateAUserCommand(UserResponseDto usertoupdate)
        {
            UserResponseDto = usertoupdate;
        }
    }
}
