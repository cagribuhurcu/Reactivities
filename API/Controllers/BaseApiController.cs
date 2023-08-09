using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

// protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();: Mediator adında bir protected alan tanımlanmıştır. Bu, türetilen tüm controller sınıflarında kullanılabilir. Mediator özelliği, _mediator değişkenini döndürür, ancak eğer _mediator değişkeni null ise HttpContext.RequestServices.GetService<IMediator>() ifadesini kullanarak bir MediatR örneği alır ve _mediator değişkenine atar. Böylece her istek için yeni bir MediatR örneği oluşturulmaz ve aynı örneği kullanılır. Bu, gereksiz bellek tüketimini engeller ve performansı artırır.

// Bu BaseApiController sınıfı, diğer controller sınıflarında miras alınarak MediatR'nin kullanımını kolaylaştırır. Mediator'a erişim sağlamak için tüm controller sınıflarında Mediator özelliği kullanılabilir. Bu sayede, controller sınıfları basit ve temiz bir şekilde MediatR ile komut ve sorguları işleyebilirler.