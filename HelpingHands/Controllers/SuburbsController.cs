using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HelpingHands.Models;
using HelpingHands.Interfaces;

namespace HelpingHands.Controllers
{
    public class SuburbsController : Controller
    {
        private readonly ISuburb _suburb;
        private readonly ICity _city;

        public SuburbsController(ISuburb suburb, ICity city)
        {
            _suburb = suburb;
            _city = city;
        }

        #region Index and Details

        // GET: Suburbs
        public async Task<IActionResult> Index()
        {
            try
            {
                var suburbs = await _suburb.GetSuburbs();
                if(suburbs == null)
                {
                    return NotFound();
                }

                return View(suburbs);
            } catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }

        // GET: Suburbs/Details/:id
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var suburb = await _suburb.GetSuburb(id);
                if(suburb == null)
                {
                    return NotFound();
                }
                return View(suburb.FirstOrDefault());
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

        #region Create

        // GET: Suburbs/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var cities = await _city.GetCities();
                ViewData["CityId"] = new SelectList(cities, "CityId", "Name");
                return View();
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: Suburbs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuburbId,Name,PostalCode,CityId,Active")] Suburb suburb)
        {
            if(suburb == null)
            {
                return NotFound();
            }
            try
            {
                await _suburb.AddSuburb(suburb);
                return RedirectToAction(nameof(Index));
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

        #region Edit

        // GET: Suburbs/Edit/:id
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var suburb = await _suburb.GetSuburb(id);
                if (suburb == null)
                {
                    return NotFound();
                }
                return View(suburb.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: Suburbs/Edit/:id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuburbId,Name,PostalCode,CityId,Active")] Suburb suburb)
        {
            if (id != suburb.SuburbId)
                return NotFound();

            try
            {
                await _suburb.UpdateSuburb(suburb);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

        #region Delete

        // GET: Suburbs/Delete/:id
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

        // POST: Suburbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _suburb.DeleteSuburb(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion
    }
}
