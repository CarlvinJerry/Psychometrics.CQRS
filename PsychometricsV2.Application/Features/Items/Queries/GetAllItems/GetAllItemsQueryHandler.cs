using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.Items.Queries.GetAllItems;

public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<Item>>
{
    private readonly IRepository<Item> _itemRepository;

    public GetAllItemsQueryHandler(IRepository<Item> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        return await _itemRepository.GetAllAsync();
    }
} 