using Microsoft.AspNetCore.Mvc;
using Elect.Web.Models;
using Elect.Web.Swagger.Attributes;
using Goblin.Core.Web.Filters.Exception;
using Goblin.Core.Web.Filters.Validation;
using Goblin.Notification.Filters;

namespace Goblin.Notification.Controllers
{
    [ShowInApiDoc]
    [Produces(ContentType.Json, ContentType.FormUrlEncoded, ContentType.MultipartFormData)]
    [ServiceFilter(typeof(GoblinApiAuthFilter))]
    [ServiceFilter(typeof(GoblinApiValidationActionFilterAttribute))]
    [ServiceFilter(typeof(GoblinApiExceptionFilterAttribute))]
    public class BaseController : Controller
    {
    }
}