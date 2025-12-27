using Microsoft.AspNetCore.Mvc;
using vigere.application.UseCases.Users.Register;
using vigere.comunication.Requests;
using vigere.comunication.Responses;

namespace vigere.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<ResponseAuthUserJson>(StatusCodes.Status201Created)]
    [ProducesResponseType<ApiErrorResponseJson>(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Register(
        [FromBody] RequestRegisterUserJson request,
        [FromServices] IRegisterUserUseCase _usecase
    )
    {
        var response = await _usecase.Execute(request);

        return Created(string.Empty, response);
    }
}
