'use strict';
function AddAddress() {
    var address = {
        ZipCode: $('#ZipCode').val()
            , Street: $('#Street').val()
            , Number: $('#Number').val()
            , AddOn: $('#AddOn').val()
            , NeighborHood: $('#NeighborHood').val()
            , City: new City($('#City option:selected').val(), $('#City option:selected').text())
    }
    if (address.Street == '' && address.NeighborHood == '' && (address.City == undefined || address.City == null)) {
        return;
    }
    addresses.push(address);
    var sRow = '';
    BuildTableAddress();
    ClearAddressFields();
}
$(function () {
    $('#ZipCode').keyup(function () {
        if ($('#ZipCode').val().length == 9 && $('#ZipCode').val().indexOf('_') < 0) {
            GetCep($('#ZipCode').val());
        }
    });

    $('#Addresses_0__ZipCode').keyup(function () {
        if ($('#Addresses_0__ZipCode').val().length == 9 && $('#Addresses_0__ZipCode').val().indexOf('_') < 0) {
            $.ajax({
                type: 'GET',
                url: "http://viacep.com.br/ws/" + $('#Addresses_0__ZipCode').val().replace('-', '') + "/json/ ",
                success: function (response) {
                    if (response != null && response.erro === undefined) {
                        var state = response.uf;
                        $('#Addresses_0__Street').val(response.logradouro.toUpperCase());
                        $('#Addresses_0__NeighborHood').val(response.bairro.toUpperCase());
                        $('#States option:contains(' + GetStateName(state) + ')').prop('selected', true);
                        localidade = response.localidade;
                        $('#Addresses_0__City_CityId').empty();
                        var stateid = $('#States option:selected').val();
                        if (stateid == '') {
                            return;
                        }
                        $.post('/common/getcities', JSON.stringify(stateid), function (result) {
                            $.each(result, function (index, key) {
                                $('#Addresses_0__City_CityId').append($('<option/>', {
                                    value: key.cityId,
                                    text: key.name
                                }));
                            });
                        });
                        setTimeout(function () {
                            $('#Addresses_0__City_CityId option:contains(' + localidade + ')').prop('selected', true);
                        }, 3500);
                    }
                }
            });
        }
    });

    $('#User_Addresses_0__ZipCode').keyup(function () {
        if ($('#User_Addresses_0__ZipCode').val().length == 9 && $('#User_Addresses_0__ZipCode').val().indexOf('_') < 0) {

            $.ajax({
                type: 'GET',
                url: "http://viacep.com.br/ws/" + $('#User_Addresses_0__ZipCode').val().replace('-', '') + "/json/ ",
                success: function (response) {
                    if (response != null && response.erro === undefined) {
                        var state = response.uf;
                        $('#User_Addresses_0__Street').val(response.logradouro.toUpperCase());
                        $('#User_Addresses_0__NeighborHood').val(response.bairro.toUpperCase());
                        $('#States option:contains(' + GetStateName(state) + ')').prop('selected', true);
                        localidade = response.localidade;
                        $('#States').trigger('change');
                        setTimeout(function () {
                            $('#City option:contains(' + localidade + ')').prop('selected', true);
                            $('#User_Addresses_0__City_CityId').val($('#City option:selected').val());
                        }, 3500);
                    }
                }
            });



        }
    });

    $('#States').on('change', function () {
        $('#City').empty();
        var stateid = $('#States option:selected').val();
        if (stateid == '') {
            return;
        }
        $.post('/common/getcities', JSON.stringify(stateid), function (result) {
            $.each(result, function (index, key) {
                $('#City').append($('<option/>', {
                    value: key.cityId,
                    text: key.name
                }));
            });
        });
    });

    $('#City').on('change', function () {
        $('#User_Addresses_0__City_CityId').val($('#City').val());
    });

});
function GetCep(cep) {
    $.ajax({
        type: 'GET',
        url: "http://viacep.com.br/ws/" + cep.replace('-', '') + "/json/ ",
        success: function (response) {
            if (response != null && response.erro === undefined) {
                var state = response.uf;
                $('#Street').val(response.logradouro.toUpperCase());
                $('#NeighborHood').val(response.bairro.toUpperCase());
                $('#States option:contains(' + GetStateName(state) + ')').prop('selected', true);
                localidade = response.localidade;
                $('#States').trigger('change');
                setTimeout(function () {
                    $('#City option:contains(' + localidade + ')').prop('selected', true);
                }, 3500);
            } 
        }
    });
}
function GetStateName(initials) {
    switch (initials) {
        case 'AC':
            return 'ACRE'
        case 'AL':
            return 'ALAGOAS'
        case 'AP':
            return 'AMAPÁ'
        case 'AM':
            return 'AMAZONAS'
        case 'BA':
            return 'BAHIA'
        case 'CE':
            return 'CEARÁ'
        case 'DF':
            return 'DISTRITO FEDERAL'
        case 'ES':
            return 'ESPÍRITO SANTO'
        case 'GO':
            return 'GOIÁS'
        case 'MA':
            return 'MARANHÃO'
        case 'MT':
            return 'MATO GROSSO'
        case 'MS':
            return 'MATO GROSSO DO SUL'
        case 'MG':
            return 'MINAS GERAIS'
        case 'PA':
            return 'PARÁ'
        case 'PB':
            return 'PARAÍBA'
        case 'PR':
            return 'PARANÁ'
        case 'PE':
            return 'PERNAMBUCO'
        case 'PI':
            return 'PIAUÍ'
        case 'RJ':
            return 'RIO DE JANEIRO'
        case 'RN':
            return 'RIO GRANDE DO NORTE'
        case 'RS':
            return 'RIO GRANDE DO SUL'
        case 'RO':
            return 'RONDÔNIA'
        case 'RR':
            return 'RORAIMA'
        case 'SC':
            return 'SANTA CATARINA'
        case 'SP':
            return 'SÃO PAULO'
        case 'SE':
            return 'SERGIPE'
        case 'TO':
            return 'TOCANTIS'
    }
}
function BuildTableAddress() {
    var sRow = '';
    var counter = 0;
    $('#bodyAddress').empty();
    $.each(addresses, function (index, key) {
        if ($('#City option:selected').val() != '') {
            cityId = $('#City option:selected').val();
            citName = $('#City option:selected').text();
        }        
        sRow += '<tr>';
        sRow += '<td><input type=\'text\' name=\'Addresses[' + counter + '].ZipCode\' id=\'Address[' + counter + '].ZipCode\' value=\'' + key.ZipCode + '\' style=\'border-style:none;\' /></td>';
        sRow += '<td><input type=\'text\' name=\'Addresses[' + counter + '].Street\' id=\'Address[' + counter + '].Street\' value=\'' + key.Street.toUpperCase() + '\' style=\'border-style:none;\' /></td>';
        sRow += '<td><input type=\'text\' name=\'Addresses[' + counter + '].Number\' id=\'Address[' + counter + '].Number\' value=\'' + key.Number.toUpperCase() + '\' style=\'border-style:none;\' /></td>';
        sRow += '<td><input type=\'text\' name=\'Addresses[' + counter + '].AddOn\' id=\'Address[' + counter + '].AddOn\' value=\'' + key.AddOn.toUpperCase() + '\' style=\'border-style:none;\' /></td>';
        sRow += '<td><input type=\'text\' name=\'Addresses[' + counter + '].NeighborHood\' id=\'Address[' + counter + '].NeighborHood\' value=\'' + key.NeighborHood.toUpperCase() + '\' style=\'border-style:none;\' /></td>';
        sRow += '<td><input type=\'text\' id=\'Address[' + counter + '].Citi\' value=\'' + citName.toUpperCase() + '\' style=\'border-style:none;\' />';
        sRow += '<input type=\'hidden\' name=\'Addresses[' + counter + '].City.CityId\' id=\'Address[' + counter + '].City.CityId\' value=\'' + cityId + '\' />';
        sRow += '<input type=\'hidden\' name=\'Addresses[' + counter + '].AddressId\' id=\'Address[' + counter + '].AddressId\' value=\'' + key.AddressId + '\' /></td>';
        sRow += '<td><button id=\'' + key.AddressId + '\' onClick=\'RemoveAddress(this.id)\' type=\'button\' class=\'btn btn-info\' style=\'font-size:small;\'>REMOVER</button></td>';
        sRow += '</tr>';
        counter++;
    });
    $('#bodyAddress').append(sRow)
}
function ClearAddressFields() {
    $('#ZipCode').val('');
    $('#Street').val('');
    $('#Number').val('');
    $('#AddOn').val('');
    $('#NeighborHood').val('');
    $('#States option:first-child').prop('selected', 'selected');
    $('#City').empty();
}

