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
        }).then(function (data) {
            console.info(data);
            $("#CurrentBrewery_Address_Id").val(data.id);
            $("#CurrentBrewery_Address_Street").val(data.street);
            $("#CurrentBrewery_Address_Number").val(data.number);
            $("#CurrentBrewery_Address_PostalCode").val(data.postalCode);
            $("#CurrentBrewery_Address_City").val(data.city);
            $("#CurrentBrewery_Address_Country").val(data.country);
        });
    };
    return BreweryCreate;
}());
$(document).ready(function () {
    var breweryCreate = new BreweryCreate();
    breweryCreate.init();
});
//# sourceMappingURL=BreweryCreate.js.map