using CleanArchitectrure.Application.UseCases.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Application.UseCases.Users.Queries.AuthUserQuery
{
    public class AuthUserQuery : IRequest<BaseResponse<string>>
    {
        public string Client { get; set; }
        public string Secret { get; set; }
    }
}
