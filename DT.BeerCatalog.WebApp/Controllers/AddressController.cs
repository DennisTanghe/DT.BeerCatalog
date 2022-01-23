using DT.BeerCatalog.Models;
using DT.BeerCatalog.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DT.BeerCatalog.WebApp.Controllers
{
    public class AddressController : Controller
    {
        private IAddressRepository _addressRepository;
        private AddressViewModel _addressViewModel = new AddressViewModel();

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: AddressController
        public ActionResult Index()
        {
            _addressViewModel.Addresses = _addressRepository.GetAllAddresses();
            _addressViewModel.PageTitle = "Address List";

            return View(_addressViewModel);
        }

        // GET: AddressController/Details/5
        public ActionResult Details(int id)
        {
            _addressViewModel.PageTitle = "Address Details";
            _addressViewModel.CurrentAddress = _addressRepository.GetAddress(id);

            return View(_addressViewModel);
        }

        // GET: AddressController/Create
        public ActionResult Create()
        {
            _addressViewModel.PageTitle = "Add new address";
            _addressViewModel.CurrentAddress = new Address();

            return View(_addressViewModel);
        }

        // POST: AddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressViewModel addressViewModel)
        {
            try
            {
                addressViewModel.PageTitle = "Add new address";

                if (ModelState.IsValid)
                {
                    _addressRepository.AddAddress(addressViewModel.CurrentAddress);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                // TODO add logging functionality

                addressViewModel.ErrorMessage = "Sorry, something went wrong.";
            }

            return View(addressViewModel);
        }

        // GET: AddressController/Edit/5
        public ActionResult Edit(int id)
        {
            _addressViewModel.PageTitle = "Update address";
            _addressViewModel.CurrentAddress = _addressRepository.GetAddress(id);

            return View(_addressViewModel);
        }

        // POST: AddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddressViewModel addressViewModel)
        {
            try
            {
                addressViewModel.PageTitle = "Update address";

                if (ModelState.IsValid)
                {
                    _addressRepository.UpdateAddress(addressViewModel.CurrentAddress);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                // TODO add logging functionality

                addressViewModel.ErrorMessage = "Sorry, something went wrong.";
            }

            return View(addressViewModel);
        }

        // GET: AddressController/Delete/5
        public ActionResult Delete(int id)
        {
            _addressViewModel.PageTitle = "Delete address";
            _addressViewModel.CurrentAddress = _addressRepository.GetAddress(id);

            return View(_addressViewModel);
        }

        // POST: AddressController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AddressViewModel addressViewModel)
        {
            try
            {
                addressViewModel.PageTitle = "Delete address";

                _addressRepository.DeleteAddress(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // TODO add logging functionality

                addressViewModel.ErrorMessage = "Sorry, something went wrong.";
            }

            return View(addressViewModel);
        }
    }
}
