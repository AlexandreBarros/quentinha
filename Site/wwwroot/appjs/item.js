$(function () {
    $('#Categories').on('click', function () {
        var items = $(this)[0].selectedOptions;
        var itemValues = [];
        $.each(items, function (index, key) {
            itemValues.push(key.value);
        });
        SetCategoryItems(itemValues, items.length);
    });
});

function SetCategoryItems(matriz, counter) {
    $('#divCategories').empty();
    sRow = '';
    var num = 0;
    $.each(matriz, function (index, key) {
        sRow += '<input type=\'hidden\' id=\'CategoriesItems[' + num + '].Category.CategoryId\' name=\'CategoriesItems[' + num + '].Category.CategoryId\' value=\'' + key + '\' />';
        num++;
    });
    $('#divCategories').append(sRow);
}