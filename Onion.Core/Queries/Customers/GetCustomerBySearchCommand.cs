using MediatR;
using Onion.Core.Models.Enums;
using Onion.Core.Models.Infrastructure;
using Onion.Core.Models.ViewModels;

namespace Onion.Core.Queries.Customers
{

    public class GetCustomerBySearchCommand : BaseSearchModel, IRequest<PagedListModel<CustomerVm>>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public CustomerStatuses? CustomerStatus { get; set; }

    }


}
