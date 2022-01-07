﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IDataService<VehicleDto> _vehicleDtoService;
        private readonly IMapper _mapper;

        public VehicleController(IDataService<VehicleDto> vehicleDtoService, IMapper mapper)
        {
            _vehicleDtoService = vehicleDtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vehicleListDto = _vehicleDtoService.GetAllItems();

            var vehicleViewModel = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicleListDto);
            return View(vehicleViewModel);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var vehicleListDto = _vehicleDtoService.GetItem(id);

            if (vehicleListDto is null)
                return NotFound();

            var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleListDto);
            return View(vehicleViewModel);
        }


        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleListDto = _mapper.Map<VehicleDto>(vehicleViewModel);
                _vehicleDtoService.Create(vehicleListDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var vehicleDto = _vehicleDtoService.GetItem(id);

            if (vehicleDto is null)
                return NotFound();

            var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleDto);
            return View(vehicleViewModel);
        }

        [HttpPost]
        public IActionResult Update(VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleDto = _mapper.Map<VehicleDto>(vehicleViewModel);
                _vehicleDtoService.Update(vehicleDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var vehicleDto = _vehicleDtoService.GetItem(id);

            if (vehicleDto is null)
                return NotFound();

            var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleDto);
            return View(vehicleViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _vehicleDtoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
