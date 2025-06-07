using Application_Layer.Common.Results;
using Application_Layer.Dtos.UserDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Commands.UserCommands.CreateAUser
{
    public class CreateAUserCommand : IRequest<OperationResult>
    {
        public UserDto UserDto { get; set; }
        public CreateAUserCommand(UserDto userdto)
        {
            UserDto = userdto;
        }
    }
}
