using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IDataService<ComponentDto> _componentDtoService;
        private readonly IMapper _mapper;

        public ComponentController(IDataService<ComponentDto> componentDtoService, IMapper mapper)
        {
            _componentDtoService = componentDtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var componentsList = _componentDtoService.GetAllItems();

            var componentViewModel = _mapper.Map<IEnumerable<ComponentViewModel>>(componentsList);
            return View(componentViewModel);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var componentDto = _componentDtoService.GetItem(id);

            if (componentDto is null)
                return NotFound();

            var componentViewModel = _mapper.Map<ComponentViewModel>(componentDto);
            return View(componentViewModel);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ComponentViewModel componentViewModel)
        {
            if (ModelState.IsValid)
            {
                var componentDto = _mapper.Map<ComponentDto>(componentViewModel);
                _componentDtoService.Create(componentDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var componentDto = _componentDtoService.GetItem(id);

            if (componentDto is null)
               return NotFound();

            var componentViewModel = _mapper.Map<ComponentViewModel>(componentDto);
            return View(componentViewModel);
        }

        [HttpPost]
        public IActionResult Update(ComponentViewModel componentModel)
        {
            if (ModelState.IsValid)
            {
                var componentDto = _mapper.Map<ComponentDto>(componentModel);
                _componentDtoService.Update(componentDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var componentDto = _componentDtoService.GetItem(id);

            if (componentDto is null)
                return NotFound();

            var componentViewModel = _mapper.Map<ComponentViewModel>(componentDto);
            return View(componentViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _componentDtoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}