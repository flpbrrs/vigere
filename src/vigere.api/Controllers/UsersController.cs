using Microsoft.AspNetCore.Mvc;
using vigere.comunication.Responses;
using vigere.comunication.Requests;
using vigere.application.UseCases.Users.Register;

namespace vigere.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<ApiErrorResponseJson>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] RequestRegisterUserJson request,
        [FromServices] IRegisterUserUseCase _usecase
    )
    {
        var result = await _usecase.Execute(request);

        return Created(string.Empty, result);
    }
}
