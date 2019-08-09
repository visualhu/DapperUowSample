using Data.Model.PublicService;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    public class FlightUserController : Controller
    {
        private readonly IFlightUserRepository _repository;
        private readonly IUnitOfWorkFactory _uowFactory;

        public FlightUserController(IFlightUserRepository repository,
            IUnitOfWorkFactory uowFactory)
        {
            _repository = repository;
            _uowFactory = uowFactory;
        }

        [HttpGet]
        public JsonResult Index()
        {
            var result = _repository.GetByIdAsync(1700428).Result;

            return Json(result);
        }

        //    [HttpPost]
        //    public JsonResult PostFlightUser()
        //    {
        //        using (var uow = new IUnitOfWork(_repository)
        //        {
        //            var entity = new FlightUser();
        //        _repository.AddAsync(entity);
        //        _repository.AddAsync(entity);
        //        uow.SaveChanges();
        //    }

        //        return Json("");
        //}

        //[HttpPost]
        //public JsonResult PostFlightUser()
        //{
        //    using (var uow = _uowFactory.Create(DataSourceOptions.TCFlySentryPlus))
        //    {
        //        var entity = new FlightUser();
        //        _repository.AddAsync(entity);
        //        _repository.AddAsync(entity);
        //        uow.SaveChanges();
        //    }

        //    return Json("");
        //}
    }
}