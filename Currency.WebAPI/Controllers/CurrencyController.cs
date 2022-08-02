using Microsoft.AspNetCore.Mvc;
using Сurrency.WebAPI.Infrastructure.Managers.Interfaces;

namespace Сurrency.WebAPI.Controllers;

[ApiController]
[Route("api")]
[Produces("application/json")]
public class CurrencyController : Controller
{
    private readonly ICurrencyManager _currencyManager;
    public CurrencyController(
        ICurrencyManager currencyManager)
    {
        _currencyManager = currencyManager;
    }

    [HttpGet("currency/{code}")]
    public IActionResult Currency(string code)
    {
        var result = _currencyManager.GetByCode(code);
        if (result == null) return BadRequest();
        return Json(result);
    }

    [HttpGet("currencies/{pageIndex:min(1)}/{pageSize:min(1)}")]
    public IActionResult Currencies(int pageIndex, int pageSize)
    {
        var result = _currencyManager.GetPagedList(pageIndex, pageSize);
        if (result == null) return BadRequest();
        return Json(result);
    }
}