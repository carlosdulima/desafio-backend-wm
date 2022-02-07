using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Queries;
using Webmotors.ApplicationCore.UseCases.Interfaces;
using Webmotors.UI.Models;

namespace Webmotors.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGetAd _getAd;
        private readonly IGetMake _getMake;
        private readonly IGetModel _getModel;
        private readonly IGetVersion _getVersion;
        private readonly ICreateAd _createAd;
        private readonly IChangeAd _changeAd;
        private readonly IDeleteAd _deleteAd;

        public HomeController(
            IMapper mapper,
            IGetAd getAd,
            IGetMake getMake,
            IGetModel getModel,
            IGetVersion getVersion,
            ICreateAd createAd,
            IChangeAd changeAd,
            IDeleteAd deleteAd)
        {
            _mapper = mapper;
            _getAd = getAd;
            _getMake = getMake;
            _getModel = getModel;
            _getVersion = getVersion;
            _createAd = createAd;
            _changeAd = changeAd;
            _deleteAd = deleteAd;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _getAd.Execute();
            return View(_mapper.Map<IEnumerable<AdViewModel>>(result));
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ReturnJsonAd(int id)
        {
            return Json(await _getAd.Execute(new AdQuery { Id = id } ));
        }

        [HttpGet]
        public async Task<JsonResult> ReturnJsonMake()
        {
            return Json(await _getMake.Execute());
        }

        [HttpGet]
        public async Task<JsonResult> ReturnJsonModel(int makeId)
        {
            return Json(await _getModel.Execute(new ModelQuery { MakeId = makeId }));
        }

        [HttpGet]
        public async Task<JsonResult> ReturnJsonVersion(int modelId)
        {
            return Json(await _getVersion.Execute(new VersionQuery { ModelId = modelId }));
        }

        [HttpPost]
        public async Task<JsonResult> CreateAd(AdViewModel adViewModel)
        {
            await _createAd.Execute(_mapper.Map<Ad>(adViewModel));
            return Json(string.Empty);
        }

        [HttpPost]
        public async Task<JsonResult> ChangeAd(AdViewModel adViewModel)
        {
            await _changeAd.Execute(_mapper.Map<Ad>(adViewModel));
            return Json(string.Empty);
        }

        [HttpPost]
        public async Task<JsonResult> DeletarAd(int id)
        {
            await _deleteAd.Execute(id);
            return Json(string.Empty);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
