using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace VehicleServiceV2.Controllers
{
    public class ColorController : Controller
    {
        private IColorRepository _repository;

        public ColorController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        private IUnitOfWork UnitOfWork { get; set; }


        private IColorRepository Repository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = this.UnitOfWork.Color;
                }

                return _repository;
            }
        }

        public IActionResult Index()
        {
            var model = Repository.FindAll().OrderBy(x => x.Name);
            return View(model);
        }
    }
}