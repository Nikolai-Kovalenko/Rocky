﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rocky_DatAccess;
using Rocky_DatAccess.Repository.IRepository;
using Rocky_Models;
using Rocky_Utility;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;

namespace Rocky.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class ApplicationTypeController : Controller 
    {
        private readonly IApplicationTypeRepository _appTypeRepo;

        public ApplicationTypeController(IApplicationTypeRepository appTypeRepo)
        {
            _appTypeRepo = appTypeRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> ogjList = _appTypeRepo.GetAll();
            return View(ogjList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if(ModelState.IsValid) {
                _appTypeRepo.Add(obj);
                _appTypeRepo.Save();
                TempData[WC.Success] = "Application Tytpe created successfully";
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = "Error while creating";
            return View(obj);
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _appTypeRepo.Update(obj);
                _appTypeRepo.Save();
                TempData[WC.Success] = "Application Tytpe edited successfully";
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = "Error while editing";
            return View(obj);
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());

            if (obj == null)
            {
                TempData[WC.Error] = "Error while deleting";
                return NotFound();
            }

            _appTypeRepo.Remove(obj);
            _appTypeRepo.Save();
            TempData[WC.Success] = "Application Tytpe deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
