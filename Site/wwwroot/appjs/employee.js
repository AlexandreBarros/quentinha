function Remove(obj) {
    var confirmar = confirm('Confirma desativação?');
    if (!confirmar) {
        return;
    }
    var identifier = obj.id;
    $.ajax({
        url: 'delete'
        , type: 'POST'
        , data: JSON.stringify(identifier)
        , success: function () {
            location.href = 'index';
        }
    });
}

function Reactivate(obj) {
    var confirmar = confirm('Confirma reativação?');
    if (!confirmar) {
        return;
    }
    var identifier = obj.id;
    $.ajax({
        url: 'reactivate'
        , type: 'POST'
        , data: JSON.stringify(identifier)
        , success: function () {
            location.href = 'index';
        }
    });
}

