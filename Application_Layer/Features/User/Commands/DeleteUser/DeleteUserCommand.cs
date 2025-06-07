using Application_Layer.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommand : IRequest<OperationResult>
    {
        public int UserID { get; set; }
        public DeleteUserCommand(int userid)
        {
            UserID = userid;
        }
    }
}
