
namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
  private readonly HousesService _housesService;
  private readonly Auth0Provider _auth0Provider;

  public HousesController(Auth0Provider auth0Provider, HousesService housesService)
  {
    _housesService = housesService;
    _auth0Provider = auth0Provider;
  }

  [HttpPost, Authorize]
  public async Task<ActionResult<House>> Create([FromBody] House houseData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      houseData.CreatorId = userInfo.Id;
      House house = _housesService.Create(houseData);
      return Ok(house);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}