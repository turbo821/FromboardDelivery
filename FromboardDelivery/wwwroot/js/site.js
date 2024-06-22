
$(function () {
    $("#inputNumber").mask("+7(999)999-99-99");
    $("#inputNumber2").mask("+7(999)999-99-99");
});

const phone = document.getElementById("inputNumber");
const phone2 = document.getElementById("inputNumber2");

phone.addEventListener("click", function () {
    phone.focus();
    phone.setSelectionRange(3, 3);

});
phone2.addEventListener("click", function () {
    phone2.focus();
    phone2.setSelectionRange(3, 3);

});

