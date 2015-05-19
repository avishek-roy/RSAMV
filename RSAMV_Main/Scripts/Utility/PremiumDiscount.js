$(document).ready(function () {
    $('#premiumTxtBox').hide();
    $('#discountTxtBox').hide();


    $('#rbtnPremium').click(function () {
        $('#premiumTxtBox').show();
        $('#discountTxtBox').hide();
    });

    $('#rbtnDiscount').click(function () {
        $('#discountTxtBox').show();
        $('#premiumTxtBox').hide();
    });
});
