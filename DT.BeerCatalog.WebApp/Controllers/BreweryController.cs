using DT.BeerCatalog.Models;
using DT.BeerCatalog.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DT.BeerCatalog.WebApp.Controllers
{
    public class BreweryController : Controller
    {
        private readonly IBreweryRepository _breweryRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly BreweryViewModel _breweryViewModel = new();

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
            _breweryViewModel.CurrentBrewery = new Brewery
            {
                Address = new Address(),
                Beers = new List<Beer>()
            };
            _breweryViewModel.AddressList = GetAllAddressesForSelect(_breweryViewModel);

            return View(_breweryViewModel);
        }

        // POST: BreweryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BreweryViewModel breweryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (breweryViewModel.SelectedAddressId == -1)
                    {
                        // Create the new address and link it with the brewery

                        breweryViewModel.CurrentBrewery.Address = _addressRepository.AddAddress(breweryViewModel.CurrentBrewery.Address);
                        breweryViewModel.SelectedAddressId = breweryViewModel.CurrentBrewery.Address.Id;
                    }

                    _breweryRepository.AddBrewery(breweryViewModel.CurrentBrewery);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                // TODO add logging functionality

                breweryViewModel.ErrorMessage = "Sorry, something went wrong.";
            }

            // Reset props when not ok
            breweryViewModel.PageTitle = "Add new brewery";
            breweryViewModel.AddressList = GetAllAddressesForSelect(breweryViewModel);

            return View(breweryViewModel);
        }

        // GET: BreweryController/Edit/5
        public ActionResult Edit(int id)
        {
            _breweryViewModel.PageTitle = "Update brewery";
            _breweryViewModel.CurrentBrewery = _breweryRepository.GetBrewery(id);
            _breweryViewModel.SelectedAddressId = _breweryViewModel.CurrentBrewery.Address.Id;
            _breweryViewModel.AddressList = GetAllAddressesForSelect(_breweryViewModel);

            return View(_breweryViewModel);
        }

        // POST: BreweryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BreweryViewModel breweryViewModel)
        {
            try
            {
                // TODO fix this equaly as with create
                if (breweryViewModel.SelectedAddressId != 0 && breweryViewModel.SelectedAddressId != breweryViewModel.CurrentBrewery.Address.Id)
                {
                    breweryViewModel.CurrentBrewery.Address = _addressRepository.GetAddress(breweryViewModel.SelectedAddressId);
                }

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

            // Reset props when not ok
            breweryViewModel.PageTitle = "Update brewery";
            breweryViewModel.AddressList = GetAllAddressesForSelect(breweryViewModel);

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
                _breweryRepository.DeleteBrewery(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // TODO add logging functionality

                breweryViewModel.ErrorMessage = "Sorry, something went wrong.";
            }

            breweryViewModel.PageTitle = "Delete brewery";

            return View(breweryViewModel);
        }

        private List<SelectListItem> GetAllAddressesForSelect(BreweryViewModel breweryViewModel)
        {
            List<SelectListItem> addresses = new List<SelectListItem>();

            addresses.Add(new SelectListItem
                {
                    Value = "-1",
                    Text = "Choose or add a new address",
                    Selected = breweryViewModel.CurrentBrewery.Address.Id == 0
                }
            );

            addresses.AddRange(
                _addressRepository.GetAllAddresses().Select(a => new SelectListItem { 
                    Value = a.Id.ToString(), 
                    Text = $"{a.Street} {a.Number}, {a.PostalCode} {a.City}", 
                    Selected = breweryViewModel.CurrentBrewery.Address.Id == a.Id
                })
            );

            return addresses;
        }
    }
}
