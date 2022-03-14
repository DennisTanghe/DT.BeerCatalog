var BreweryCreate = /** @class */ (function () {
    function BreweryCreate() {
    }
    BreweryCreate.prototype.init = function () {
        var self = this;
        $("#addressSelector").change(function () {
            if ($(this).val() === "-1") {
                $("#addressForm").css("display", "block");
            }
            else {
                $("#addressForm").css("display", "none");
                // Get the selected address details
                var addressId = parseInt($(this).val().toString());
                self.getAddress(addressId);
            }
        });
    };
    BreweryCreate.prototype.getAddress = function (id) {
        $.ajax({
            url: "https://localhost:7066/api/address/" + id
        }).then(function (address) {
            $("#CurrentBrewery_Address_Id").val(address.id);
            $("#CurrentBrewery_Address_Street").val(address.street);
            $("#CurrentBrewery_Address_Number").val(address.number);
            $("#CurrentBrewery_Address_PostalCode").val(address.postalCode);
            $("#CurrentBrewery_Address_City").val(address.city);
            $("#CurrentBrewery_Address_Country").val(address.country);
        }).catch(function (error) {
            console.error("Failed to retrieve the address from the web api", error);
        });
    };
    return BreweryCreate;
}());
$(document).ready(function () {
    var breweryCreate = new BreweryCreate();
    breweryCreate.init();
});
//# sourceMappingURL=BreweryForm.js.map