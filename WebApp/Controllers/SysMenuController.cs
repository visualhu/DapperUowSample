using Data.Model.Sentry;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SysMenuController : Controller
    {
        private readonly ISysMenuRepository _repository;
        private readonly IUnitOfWorkFactory _uowFactory;

        public SysMenuController(ISysMenuRepository repository,
            IUnitOfWorkFactory uowFactory)
        {
            _repository = repository;
            _uowFactory = uowFactory;
        }

        [HttpGet]
        public JsonResult Index()
        {
            var result = _repository.GetByIdAsync("0bcf01c5-4002-4b4c-ad73-8fe10dfa6571").Result;

            return Json(result);
        }
    }
}