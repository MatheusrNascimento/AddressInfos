using Microsoft.AspNetCore.Mvc;
using Repository;
using ViaCep;

namespace AddressInfos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressInfosController : ControllerBase
    {
        private readonly ILogger<AddressInfosController> _logger;

        public AddressInfosController(ILogger<AddressInfosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAddressInfosByZipCode")]
        public IActionResult Get(
            string zipCode, 
            [FromServices] IUnitOfWork unitOfWork, 
            [FromServices] AddressRepository repository)
        {
            ViaCepResult result = new ViaCepClient().Search(zipCode);

            unitOfWork.BeginTransaction();
            repository.Save(new AddressInfosModel
            {
                Street = result.Street,
                ZipCode = result.ZipCode,
                City = result.City,
                Complement = result.Complement,
                GIACode = result.GIACode,
                IBGECode = result.IBGECode,
                StateInitials = result.StateInitials,
                Neighborhood = result.Neighborhood,
                Unit = result.Unit
            });
            unitOfWork.Commit();

            return Ok(result);
        }
    }
}
