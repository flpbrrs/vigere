using Microsoft.AspNetCore.Mvc;
using vigere.comunication.Responses;
using vigere.comunication.Requests;

namespace vigere.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<ApiErrorResponseJson>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] RequestRegisterUserJson request
    )
    {
        Console.WriteLine($"Registering user with email: {request.Email}");
        return Created(string.Empty, request.Email);
    }
}
