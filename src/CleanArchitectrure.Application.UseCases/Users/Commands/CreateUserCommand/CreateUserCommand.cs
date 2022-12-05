using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectrure.Application.UseCases.Commons.Bases;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand: IRequest<BaseResponse<bool>>
    {
        public int UserId { get; set; }
        public string? Company { get; set; }
        public string? Abbreviation { get; set; }
        public string? Client { get; set; }
        public string? Secret { get; set; }
    }
}
