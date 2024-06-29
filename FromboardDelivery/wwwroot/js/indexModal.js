
var modalC_el = document.getElementById('modalC');
var modalQ_el = document.getElementById('modalQ');

if (modalC_el !== null) {
    var modalC = bootstrap.Modal.getOrCreateInstance(modalC_el);
    modalC.show();
}

if (modalQ_el !== null) {
    var modalQ = bootstrap.Modal.getOrCreateInstance(modalQ_el);
    modalQ.show();
}
