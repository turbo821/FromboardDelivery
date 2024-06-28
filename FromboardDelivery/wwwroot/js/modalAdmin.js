
let params = (new URL(document.location)).searchParams;
let deleted = params.get("deleted");
let sended = params.get("sended");

if (deleted === 'True') {
    document.getElementById("del-notif").classList.remove('display-none');

    setTimeout(function () {
        document.getElementById("del-notif").classList.add('display-none');
    }, 4500);
}

if (sended === 'True') {
    document.getElementById("send-notif").classList.remove('display-none');

    setTimeout(function () {
        document.getElementById("send-notif").classList.add('display-none');
    }, 4500);
}
