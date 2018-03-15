$('#showTownsButton').click(function() {
    let selectedLi = $('#items li[data-selected=true]');
    let towns = selectedLi.map((i, x) => x.innerText)
        .get().join(', ');
    let townsDiv =
        $('<div>').text("Selected towns: " + towns);
    $('body').append(townsDiv)
});