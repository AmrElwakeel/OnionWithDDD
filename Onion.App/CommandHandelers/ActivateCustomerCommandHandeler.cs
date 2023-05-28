using MediatR;
using Onion.Core.Commands.Customers;
using Onion.Core.Services.CustomerServices;
using Onion.Domain.BusinessDomain;
using Onion.Domain.DomainEvents;

namespace Onion.App.CommandHandelers
{
    public class ActivateCustomerCommandHandeler : IRequestHandler<ActivateCustomerCommand, bool>
    {
        private readonly ICustomerService _customerService;
        private readonly IPublisher _publisher;

        public ActivateCustomerCommandHandeler(ICustomerService customerService, IPublisher publisher)
        {
            _customerService = customerService;
            _publisher = publisher;
        }
        public async Task<bool> Handle(ActivateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerService.GetByIdAsync(request.Id);

            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            customer.ActivateCustomer();

            await _customerService.EditAsync(customer);
            await _publisher.Publish(new CustomerActivatedNotification (customer.Id, customer.Name));


            return true;
        }
    }
}

