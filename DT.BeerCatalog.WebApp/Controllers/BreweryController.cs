using DT.BeerCatalog.Models;
using DT.BeerCatalog.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DT.BeerCatalog.WebApp.Controllers
{
    public class BreweryController : Controller
    {
        private IBreweryRepository _breweryRepository;
        private IAddressRepository _addressRepository;
        private BreweryViewModel _breweryViewModel = new BreweryViewModel();

        public BreweryController(IBreweryRepository breweryRepository, IAddressRepository addressRepository)
        {
            _breweryRepository = breweryRepository;
            _addressRepository = addressRepository;
        }

        // GET: BreweryController
        public ActionResult Index()
        {
            _breweryViewModel.Breweries = _breweryRepository.GetAllBreweries();
            _breweryViewModel.PageTitle = "Brewery List";

            return View(_breweryViewModel);
        }

        // GET: BreweryController/Details/5
        public ActionResult Details(int id)
        {
            _breweryViewModel.PageTitle = "Brewery Details";
            _breweryViewModel.CurrentBrewery = _breweryRepository.GetBrewery(id);

            return View(_breweryViewModel);
        }

        // GET: BreweryController/Create
        public ActionResult Create()
        {
            _breweryViewModel.PageTitle = "Add new brewery";
            _breweryViewModel.CurrentBrewery = new Brewery();
            _breweryViewModel.AddressList = _addressRepository.GetAllAddresses().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = $"{a.Street} {a.Number}, {a.PostalCode} {a.City}" }).ToList();

            return View(_breweryViewModel);
        }

        // POST: BreweryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BreweryViewModel breweryViewModel)
        {
            try
            {
                breweryViewModel.PageTitle = "Add new brewery";

                if (ModelState.IsValid)
                {
                    _breweryRepository.AddBrewery(breweryViewModel.CurrentBrewery);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                // TODO add logging functionality

                breweryViewModel.ErrorMessage = "Sorry, something went wrong.";
            }

            return View(breweryViewModel);
        }

        // GET: BreweryController/Edit/5
        public ActionResult Edit(int id)
        {
            _breweryViewModel.PageTitle = "Update brewery";
            _breweryViewModel.CurrentBrewery = _breweryRepository.GetBrewery(id);
            _breweryViewModel.AddressList = _addressRepository.GetAllAddresses().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = $"{a.Street} {a.Number}, {a.PostalCode} {a.City}", Selected = _breweryViewModel.CurrentBrewery.Address.Id == a.Id }).ToList();

            return View(_breweryViewModel);
        }

        // POST: BreweryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BreweryViewModel breweryViewModel)
        {
            try
            {
                breweryViewModel.PageTitle = "Update brewery";

                if (ModelState.IsValid)
                {
                    _breweryRepository.UpdateBrewery(breweryViewModel.CurrentBrewery);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                // TODO add logging functionality

                breweryViewModel.ErrorMessage = "Sorry, something went wrong.";
            }

            return View(breweryViewModel);
        }

        // GET: BreweryController/Delete/5
        public ActionResult Delete(int id)
        {
            _breweryViewModel.PageTitle = "Delete brewery";
            _breweryViewModel.CurrentBrewery = _breweryRepository.GetBrewery(id);

            return View(_breweryViewModel);
        }

        // POST: BreweryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BreweryViewModel breweryViewModel)
        {
            try
            {
                breweryViewModel.PageTitle = "Delete brewery";

                _breweryRepository.DeleteBrewery(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // TODO add logging functionality

                breweryViewModel.ErrorMessage = "Sorry, something went wrong.";
            }

            return View(breweryViewModel);
        }
    }
}
