'use strict';
var guidEmpty = '00000000-0000-0000-0000-000000000000';
var imgRender = '';
var img64Bits = '';
var localidade = '';
var addresses = [];
var contactList = [];
var cityId = '';
var citName = '';
$.ajaxSetup({
    beforeSend: function (xhr) {
        xhr.setRequestHeader('Content-Type', 'application/json');
    }
});
var Info = {
    Empty: 'Necessário preencher Informações',
    Email: 'E-mail inválido',
    FormSuccess: 'Registro inserido com êxito',
    FormFailure: 'Erro no envio do formulário',
    CNPJ: 'CNPJ inválido',
    CONTACT: 'Informações de contato são requeridas',
    ADDRESS: 'Informações de endereço são requeridas'
};
var tamanho = '';
var numeros = '';
var digitos = '';
var soma = '';
var pos = '';
var resultado = '';
var i = 0;
function validarCNPJ(cnpj) {
    cnpj = cnpj.replace(/[^\d]+/g, '');
    if (cnpj == '') return false;
    if (cnpj.length != 14)
        return false;
    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999")
        return false;
    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
        return false;
    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
        return false;
    return true;

}
function guid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
}
function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}
function serializeFormJSON(formPost) {
    var resArray = $(formPost).serializeArray();
    var jsonResult = '{';
    $.each(resArray, function (index, key) {
        jsonResult += '\"' + key.name + '\":\"' + key.value + '\",';
    });
    jsonResult = jsonResult.substring(0, jsonResult.length - 1)
    jsonResult += '}';
    return jsonResult;
}
function showNotification(notification, typeNote) {
    var color = typeNote;
    $.notify({
        icon: 'ti-gift',
        message: notification

    }, {
       // type: type[color],
        timer: 4000,
        placement: {
            from: 'top',
            align: 'right'
        }
    });
}
function readUrl(input) {
    SetFileToStoreImg64(input.id);
    var filesSelected = '';
    var sourceData = '';
    if (input.files && input.files[0]) {
        filesSelected = input.files[0];
        var fileToLoad = filesSelected;
        var fileReader = new FileReader();
        fileReader.onload = function (fileLoadedEvent) {
            sourceData = fileLoadedEvent.target.result;
            $('#' + img64Bits).val(sourceData);
        }
        fileReader.readAsDataURL(fileToLoad);
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#' + imgRender).attr('src', e.target.result);
        }
        reader.readAsDataURL(filesSelected);
    }
};
function SetFileToStoreImg64(controlName) {
    switch (controlName) {
        case 'imgSource':
            img64Bits = 'UrlData';
            imgRender = 'imgRender'
            break;
        case 'CategoryImage':
            img64Bits = 'UrlCarteLogo';
            imgRender = 'imgRender';
            break;
        case 'ItemImage':
            img64Bits = 'Photo';
            imgRender = 'imgRender';
            break;
    }
}
function serializeFormJSON(formPost) {
    var resArray = $(formPost).serializeArray();
    var jsonResult = '{';
    $.each(resArray, function (index, key) {
        jsonResult += '\"' + key.name + '\":\"' + key.value + '\",';
    });
    jsonResult = jsonResult.substring(0, jsonResult.length - 1)
    jsonResult += '}';
    return jsonResult;
}
function ClearFields(matriz) {
    $.each(matriz, function (index, key) {
        $('#' + key).val('');
    });
}
function Clear() {
    $(':text').val('');
    $('input[type=password]').val('');
    $('input[type=email]').val('');
    $('input[type=hidden]').val('');
}
class Customer {
    constructor(customerId, legalName, exhibitionName,connectionType,isRepresentative,isCompetitor, cnpj, inscEst, inscMun,comments,webSite,addresses,contacts) {
        this.CustomerId = customerId;
        this.LegalName = legalName;
        this.ExhibitionName = exhibitionName;
        this.Connection = connectionType;
        this.IsRepresentative = isRepresentative;
        this.IsCompetitor = isCompetitor;
        this.CNPJ = cnpj;
        this.InscEst = inscEst;
        this.InscMun = inscMun;
        this.Comments = comments;
        this.WebSite = webSite;
        this.Addresses = addresses;
        this.Contacts = contacts;
    }
}
class Contact {
    constructor(contactId,name, phone, cellPhone, email) {
        this.ContactId = contactId;
        this.ContactName = name;
        this.Phone = phone;
        this.CellPhone = cellPhone;
        this.Email = email;
    }
}
class City {
    constructor(cityId, name) {
        this.CityId = cityId;
        this.Name = name;
    }
}
class Address {
    constructor(addressId, street, number, addOn, zipCode, neighborHood,city) {
        this.AddressId = addressId;
        this.Street = street;
        this.Number = number;
        this.AddOn = addOn;
        this.ZipCode = zipCode;
        this.NeighborHood = neighborHood;
        this.City = city;

    }
}
class LegalUser {
    constructor(legalUserId, legalName, exhibitionName, cnpj, inscEst, inscMun) {
        this.LegalUserId = legalUserId;
        this.LegalName = legalName;
        this.NormalizedLegalName = legalName.toUpperCase();
        this.ExhibitionName = exhibitionName;
        this.NormalizedExhibitionName = exhibitionName.toUpperCase();
        this.CNPJ = cnpj;
        this.InscEst = inscEst;
        this.InscMun = inscMun;
        this.UrlData = '-';
    }
}

