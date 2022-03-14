
class BreweryForm {
    init() {
        const self = this;

        $("#addressSelector").change(function () {
            if ($(this).val() === "-1") {
                $("#addressForm").css("display", "block");
            } else {
                $("#addressForm").css("display", "none");

                // Get the selected address details
                const addressId: number = parseInt($(this).val().toString());
                self.getAddress(addressId);
            }
        });
    }

    private getAddress(id: number) {
        $.ajax({
            url: "https://localhost:7066/api/address/" + id
        }).then(address => {
            $("#CurrentBrewery_Address_Id").val(address.id);
            $("#CurrentBrewery_Address_Street").val(address.street);
            $("#CurrentBrewery_Address_Number").val(address.number);
            $("#CurrentBrewery_Address_PostalCode").val(address.postalCode);
            $("#CurrentBrewery_Address_City").val(address.city);
            $("#CurrentBrewery_Address_Country").val(address.country);
        }).catch(error => {
            console.error("Failed to retrieve the address from the web api", error);
        });
    }
}

$(document).ready(function () {
    const breweryForm = new BreweryForm();
    breweryForm.init();
});