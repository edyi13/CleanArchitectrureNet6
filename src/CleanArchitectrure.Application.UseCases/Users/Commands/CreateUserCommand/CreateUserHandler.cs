using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Application.UseCases.Commons.Bases;
using CleanArchitectrure.Domain.Entities;
using MediatR;
using BC = BCrypt.Net.BCrypt;

namespace CleanArchitectrure.Application.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserHandler: IRequestHandler<CreateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var user = _mapper.Map<User>(request);
                user.Secret = BC.HashPassword(user.Secret);

                response.Data = await _unitOfWork.Users.InsertAsync(user);

                if (response.Data)
                {
                    response.Success = true;
                    response.Message = "Registro Exitoso";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

    }
}
