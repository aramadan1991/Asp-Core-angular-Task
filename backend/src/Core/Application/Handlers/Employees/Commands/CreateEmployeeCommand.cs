using Application.Constants;
using Application.Dtos;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Wrappers.Abstract;
using Application.Wrappers.Concrete;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<IResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, IResponse>
        {
            private readonly IEmployeeRepository _EmployeeRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IEasyCacheService _easyCacheService;

            public CreateEmployeeCommandHandler(IEmployeeRepository EmployeeRepository, IUnitOfWork unitOfWork, IEasyCacheService easyCacheService, IMapper mapper)
            {
                _EmployeeRepository = EmployeeRepository;
                _unitOfWork = unitOfWork;
                _easyCacheService = easyCacheService;
                _mapper = mapper;
            }

            public async Task<IResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
        
                var Employee = await _EmployeeRepository.AddAsync(new Employee()
                {
                    DateOfBirth = request.DateOfBirth,
                    Email=request.Email,
                    FirstName=request.FirstName,
                    LastName=request.LastName,
                    PhoneNumber=request.PhoneNumber
                });
                await _unitOfWork.SaveChangesAsync();
                await _easyCacheService.RemoveByPrefixAsync("GetAuthenticatedUserWithEmployees");
                var mappedEmployee = _mapper.Map<EmployeeDTO>(Employee);
                return new DataResponse<EmployeeDTO>(mappedEmployee, 200, Messages.AddedSuccesfully);
            }
        }
    }
}