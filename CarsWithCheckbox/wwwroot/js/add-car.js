$(() => {
    $("input.form-control").on('keyup', function () {
        ensureFormValidity();
    });

    $("#car-type").on('change', function () {
        ensureFormValidity();
        const carType = $("#car-type").val();
        $("#has-leather-seats").prop('checked', carType === "2");
        $("#has-leather-seats").prop('disabled', carType === "2");
        if (carType === "2") {
            $("form").append("<input type='hidden' id='the-hidden' name='hasLeatherSeats' value='true' />");
        } else {
            $("#the-hidden").remove();
        }
    });

    function ensureFormValidity() {
        const isValid = isFormValid();
        $("#submit-button").prop('disabled', !isValid);
    }

    function isFormValid() {
        const make = $("#make").val();
        const model = $("#model").val();
        const year = $("#year").val();
        const price = $("#price").val();
        const carType = $("#car-type").val();
        return make && model && year && price && carType !== "-1";
    }
});