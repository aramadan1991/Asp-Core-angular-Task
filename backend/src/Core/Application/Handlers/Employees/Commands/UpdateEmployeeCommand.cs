using Application.Constants;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Wrappers.Abstract;
using Application.Wrappers.Concrete;
using AutoMapper;
using MediatR;

namespace Application.Handlers.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<IResponse>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, IResponse>
        {
            private readonly IEmployeeRepository _EmployeeRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IEasyCacheService _easyCacheService;

            public UpdateEmployeeCommandHandler(IEmployeeRepository EmployeeRepository, IUnitOfWork unitOfWork, IMapper mapper, IEasyCacheService easyCacheService)
            {
                _EmployeeRepository = EmployeeRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _easyCacheService = easyCacheService;
            }

          
            public async Task<IResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var existEmployee = await _EmployeeRepository.GetByIdAsync(request.Id);
                if (existEmployee == null)
                {
                    throw new ApiException(404, Messages.NotFound);
                }

                _mapper.Map(request, existEmployee);
                await _unitOfWork.SaveChangesAsync();

                return new SuccessResponse(200, Messages.UpdatedSuccessfully);
            }
        }
    }
}