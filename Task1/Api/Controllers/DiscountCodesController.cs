using System.Threading.Tasks;
using Api.OutputDto;
using Infra.Storage.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("discount-codes")]
public class DiscountCodesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DiscountCodesController(IMediator mediator) => _mediator = mediator;

    [HttpGet("BatchId/UserId", Name = "GetDiscountCode")]
    public async Task<ActionResult<GetDiscountCodeOutputDto>> GetDiscountCode(string batchId, string userId)
    {
        var discountCode = await _mediator.Send(new GetDiscountCodeQuery {Oid = batchId, UserId = userId});
        if (discountCode == null) return NotFound();
        
        return Ok(new GetDiscountCodeOutputDto
        {
            Id = discountCode.Id,
            Claimed = discountCode.Claimed,
            ClaimedBy = discountCode.ClaimedBy
        });
    }

    [HttpPost(Name = "GenerateDiscountCodes")]
    public async Task<ActionResult<GenerateDiscountCodesOutputDto>> GenerateDiscountCodes(
        [FromBody] GenerateDiscountCodesCommand command)
    {
        var batchId = await _mediator.Send(command);
        return Ok(new GenerateDiscountCodesOutputDto {DiscountCodeBatchId = batchId});
    }
}