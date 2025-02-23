using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Users.Register;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register(RequestUserJson request)
        {

            try
            {
                var useCase = new RegisterUserUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (TechLibraryException ex)
            {
                return BadRequest(new ReponseErrorMessagesJson
                {
                    Errors = ex.GetErrorMessages()

                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ReponseErrorMessagesJson
                {
                    Errors = new List<string> { "Erro Desconhecido"}
                });
            }
        }
    }
}
