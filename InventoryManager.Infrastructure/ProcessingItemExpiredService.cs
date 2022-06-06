using System;
using InventoryManager.Application.DTOs.Items;
using InventoryManager.Application.Contracts.Infrastructure;
using InventoryManager.Application.Features.Items.Requests.Commands;
using InventoryManager.Application.Features.Items.Requests.Queries;
using InventoryManager.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InventoryManager.Infrastructure
{

    public class ProcessingItemExpiredService : IProcessingItemExpiredService
    {
        private int executionCount = 0;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ProcessingItemExpiredService(IMediator mediator, ILogger<ProcessingItemExpiredService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

                var entities = await _mediator.Send(new GetItemExpiredListRequest());

                foreach (var item in entities)
                {
                    try
                    {
                        await _mediator.Send(new ChangeItemToExpiredCommand
                        {
                            ChangeItemToExpired = new ChangeItemToExpired
                            {
                                Id = item.Id,
                                Status = ItemStatus.Expired
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation($"Error putting item {item.Id} - {item.Name} as Expired");
                    }
                }

                _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}

