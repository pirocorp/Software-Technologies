function addItemToList(text) {
    let li = $('<li>')
        .append($('<span>').text(text))
        .append(" ")
        .append($("<a href='#' onclick='deleteItem(this)'>[delete]</a>"));
    $("#items").append(li);
}

$(function(){
    addItemToList("First");
    addItemToList("Second");
});

function deleteItem(link) {
    $(link).parent().remove();
}

function addItem() {
    let selector = '#newItemText';
    let text = $(selector).val();
    addItemToList(text);
    $(selector).val('');
}

$(function () {
    let selector = '#newItemText';
    $(selector).keypress(function (e) {
        if(e.keyCode === 13){
            $(selector + ' + input[type="button"]').click();
        }
    })
});