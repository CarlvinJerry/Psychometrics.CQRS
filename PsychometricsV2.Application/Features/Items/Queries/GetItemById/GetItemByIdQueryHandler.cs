using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PsychometricsV2.Application.Interfaces;
using PsychometricsV2.Domain.Entities;

namespace PsychometricsV2.Application.Features.Items.Queries.GetItemById;

public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, Item?>
{
    private readonly IRepository<Item> _itemRepository;

    public GetItemByIdQueryHandler(IRepository<Item> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Item?> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _itemRepository.GetByIdAsync(request.Id);
    }
} 