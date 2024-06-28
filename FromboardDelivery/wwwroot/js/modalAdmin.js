var modalS_el = document.getElementById('modalS');
var modalD_el = document.getElementById('modalD');

if (modalS_el !== null) {
    var modalS = bootstrap.Modal.getOrCreateInstance(modalS_el);
    modalS.show();
}

if (modalD_el !== null) {
    var modalD = bootstrap.Modal.getOrCreateInstance(modalD_el);
    modalD.show();
}