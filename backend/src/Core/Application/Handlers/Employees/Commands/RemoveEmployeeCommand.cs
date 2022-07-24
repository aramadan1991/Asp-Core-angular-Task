using Application.Constants;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Wrappers.Abstract;
using Application.Wrappers.Concrete;
using MediatR;

namespace Application.Handlers.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<IResponse>
    {
        public Guid Id { get; set; }

        public DeleteEmployeeCommand(Guid id)
        {
            Id = id;
        }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, IResponse>
        {
            private readonly IEmployeeRepository _EmployeeRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEasyCacheService _easyCacheService;

            public DeleteEmployeeCommandHandler(IEmployeeRepository EmployeeRepository, IUnitOfWork unitOfWork, IEasyCacheService easyCacheService)
            {
                _EmployeeRepository = EmployeeRepository;
                _unitOfWork = unitOfWork;
                _easyCacheService = easyCacheService;
            }

            public async Task<IResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var exisEmployee = await _EmployeeRepository.GetByIdAsync(request.Id);
                if (exisEmployee == null)
                {
                    throw new ApiException(404, Messages.NotFound);
                }
                _EmployeeRepository.Remove(exisEmployee);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessResponse(200, Messages.DeletedSuccessfully);
            }
        }
    }
}