using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [Authorize]
    public class BaseAccountController : Controller
    {
        // Общий функционал для всех контроллеров личного кабинета
    }
}
