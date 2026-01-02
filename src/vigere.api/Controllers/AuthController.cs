using Microsoft.AspNetCore.Mvc;
using vigere.application.UseCases.Auth.Login;
using vigere.comunication.Requests;
using vigere.comunication.Responses;

namespace vigere.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType<ResponseAuthUserJson>(StatusCodes.Status200OK)]
    [ProducesResponseType<ApiErrorResponseJson>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(
        [FromBody] RequestUserLoginJson request,
        [FromServices] ILoginUseCase _usecase
    )
    {
        var response = await _usecase.Execute(request);

        return Ok(response);
    }
}
