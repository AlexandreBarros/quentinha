$(function () {
    getLocation();
});
function AddContact() {
    var contact = {
        ContactName: $('#ContactName').val() 
                , Email: $('#Email').val()
                , Phone: $('#Phone').val()
                , CellPhone: $('#CellPhone').val()
    };
    if (contact.Email == '' && contact.Phone == '' && contact.CellPhone == '') {
        return;
    }
    if (contact.Email != '' && !validateEmail(contact.Email)) {
        $.notify('Formato inválido para e-mail', 'warn');
        return;
    }
    contactList.push(contact);
    BuildTableContact();
    ClearContact();
}
function ClearContact() {
    $('#ContactName').val('');
    $('#Email').val('');
    $('#Phone').val('');
    $('#CellPhone').val('');
}
function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}
function showPosition(position) {
    $('#Addresses_0__latitude').val(position.coords.latitude);
    $('#Addresses_0__longitude').val(position.coords.longitude);
}


function BuildTableContact() {
    var sRow = '';
    $('#bodyContact').empty();
    var counter = 0;
    var guidId = '';
    $.each(contactList, function (index, key) {
        guidId = guid();
        sRow += '<tr id=\'' + guidId + '\'>';
        if (window.location.pathname.toLowerCase().indexOf('individualuser') < 0) {
            sRow += '<td><input style=\'border-style: none;\' type=\'text\' asp-for=\"Contacts[' + counter + '].ContactName\" name=\'Contacts[' + counter + '].ContactName\' id=\'Contacts[' + counter + '].ContactName\' class=\'form-control\'  value=\'' + key.ContactName + '\'</td>';
        }
        sRow += '<td><input style=\'border-style: none;\' type=\'text\' asp-for=\"Contacts[' + counter + '].Email\" name=\'Contacts[' + counter + '].Email\' id=\'Contacts[' + counter + '].Email\' class=\'form-control\'  value=\'' + key.Email + '\'</td>';
        sRow += '<td><input style=\'border-style: none;\' type=\'text\' asp-for=\"Contacts[' + counter + '].Phone\" name=\'Contacts[' + counter + '].Phone\' id=\'Contacts[' + counter + '].Phone\' class=\'form-control\'  value=\'' + key.Phone + '\'</td>';
        sRow += '<td><input style=\'border-style: none;\' type=\'text\' asp-for=\"Contacts[' + counter + '].CellPhone\" name=\'Contacts[' + counter + '].CellPhone\' id=\'Contacts[' + counter + '].CellPhone\' class=\'form-control\'  value=\'' + key.CellPhone + '\'</td>';
        sRow += '<td><input type=\'button\' class=\'btn btn-default\' onclick=\'RemoveContact(' + guid() + '\') value="Remover" />  </td></tr>';
        counter++;
    });
    $('#bodyContact').append(sRow);
}


