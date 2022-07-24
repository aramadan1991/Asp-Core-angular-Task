using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers.Abstract;
using Application.Wrappers.Concrete;
using AutoMapper;
using MediatR;

namespace Application.Handlers.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<IResponse>
    {
        public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IResponse>
        {
            private readonly IEmployeeRepository _EmployeeRepository;
            private readonly IMapper _mapper;

            public GetAllEmployeesQueryHandler(IEmployeeRepository EmployeeRepository, IMapper mapper)
            {
                _EmployeeRepository = EmployeeRepository;
                _mapper = mapper;
            }

            public async Task<IResponse> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {
                var Employees = await _EmployeeRepository.GetAllAsync();
                var mappedEmployees = _mapper.Map<IEnumerable<EmployeeDTO>>(Employees);
                return new DataResponse<IEnumerable<EmployeeDTO>>(mappedEmployees, 200);
            }
        }
    }
}