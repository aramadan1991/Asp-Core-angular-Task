using Application.Constants;
using Application.Dtos;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers.Abstract;
using Application.Wrappers.Concrete;
using AutoMapper;
using MediatR;

namespace Application.Handlers.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<DataResponse<EmployeeDTO>>
    {
        public Guid Id { get; set; }

        public GetEmployeeByIdQuery(Guid id)
        {
            Id = id;
        }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, DataResponse<EmployeeDTO>>
        {
            private readonly IEmployeeRepository _EmployeeRepository;
            private readonly IMapper _mapper;

            public GetEmployeeByIdQueryHandler(IEmployeeRepository EmployeeRepository, IMapper mapper)
            {
                _EmployeeRepository = EmployeeRepository;
                _mapper = mapper;
            }

            public async Task<DataResponse<EmployeeDTO>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            {
                var Employee = await _EmployeeRepository.GetByIdAsync(request.Id);
                if (Employee == null)
                {
                    throw new ApiException(404, Messages.NotFound);
                }
                var mappedEmployee = _mapper.Map<EmployeeDTO>(Employee);
                return new DataResponse<EmployeeDTO>(mappedEmployee, 200);
            }
        }
    }
}