
$(function () {
    
    $('#Parent').on('change', function () {
        var parent = $('#Parent option:selected').val();
        $('#Parent_CategoryId').val(parent);
    });

});