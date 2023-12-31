﻿using Microsoft.AspNetCore.Mvc;
using HelpingHands.Models;
using HelpingHands.Interfaces;

/** 
 * A lot of help for implementing a Service was provided by the good people at C# Corner, namely:
 * https://www.c-sharpcorner.com/article/crud-operation-using-entity-framework-core-and-stored-procedure-in-net-core-6-w/
**/

namespace HelpingHands.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICity _city;

        public CitiesController(ICity cityService) => _city = cityService;

        #region Index and Details
        
        // GET: Cities
        public async Task<IActionResult> Index()
        {
            try
            {
                var cities = await _city.GetCities();
                if(cities == null)
                {
                    return NotFound();
                }
                return View(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        // GET: Cities/GetCity/:id
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var city = await _city.GetCity(id);
                if (city == null)
                {
                    return NotFound();
                }
                return View(city.FirstOrDefault());
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Create

        // GET: Cities/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        // POST: Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,Name,Abbreviation,Active")] City city)
        {
            if (city == null)
                return NotFound();
            try
            {
                await _city.AddCity(city);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

        #region Edit

        // GET: Cities/Edit/:id
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var city = await _city.GetCity(id);
                if (city == null)
                {
                    return NotFound();
                }
                return View(city.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: Cities/Edit/:id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,Name,Abbreviation,Active")] City city)
        {
            if(id != city.CityId)
                return NotFound();

            try
            {
                await _city.UpdateCity(city);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

        #region Delete

        // GET: Cities/Delete/:id
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var city = await _city.GetCity(id);
                if (city == null)
                {
                    return NotFound();
                }
                return View(city.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: Cities/Delete/:id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _city.DeleteCity(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion
    }
}
