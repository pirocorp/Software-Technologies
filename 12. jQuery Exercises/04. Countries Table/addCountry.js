function addCountryToTable(country, capital) {
    let countrySelector = "#countriesTable";
    let row = $("<tr>")
        .append($("<td>").text(country))
        .append($("<td>").text(capital))
        .append($("<td>")
            .append($("<a href='#' onclick='moveRowUp(this)'>[Up]</a>"))
            .append(' ')
            .append($("<a href='#' onclick='moveRowDown(this)'>[Down]</a>"))
            .append(' ')
            .append($("<a href='#' onclick='deleteRow(this)'>[Delete]</a>"))
        );
    $(countrySelector).append(row);
    fixRowLinks();
    return row;
}

$(function(){
    addCountryToTable("Bulgaria", "Sofia");
    addCountryToTable("Germany", "Berlin");
    addCountryToTable("Russia", "Moscow");
    addCountryToTable("France", "Paris");
    addCountryToTable("India", "Delhi");
    fixRowLinks();
});

function addCountry() {
    let countrySelector = '#newCountryText';
    let capitalSelector = '#newCapitalText';
    let country = $(countrySelector).val();
    let capital = $(capitalSelector).val();
    let row = addCountryToTable(country, capital);
    row.hide();
    row.fadeIn();
    $(countrySelector).val('');
    $(capitalSelector).val('');
    fixRowLinks();
}

function deleteRow(link) {
    let row = $(link).parent().parent();
    row.fadeOut(function () {
        row.remove();
        fixRowLinks();
    });
}

function moveRowUp(link) {
    let row = $(link).parent().parent();
    row.fadeOut(function () {
        row.insertBefore(row.prev());
        row.fadeIn();
        fixRowLinks();
    });
}

function moveRowDown(link) {
    let row = $(link).parent().parent();
    row.fadeOut(function () {
        row.insertAfter(row.next());
        row.fadeIn();
        fixRowLinks();
    });
}

function fixRowLinks() {
    //Show all links in the table
    let tableLinkSelector = "#countriesTable a";
    $(tableLinkSelector).show();

    //Hide [Up] link in first table row after
    let tableRowsSelector = "#countriesTable tr";
    let tableRows = $(tableRowsSelector);
    $(tableRows[1]).find("a:contains('Up')").hide();

    //Hide the [Down] link in last table row
    $(tableRows[tableRows.length-1]).find("a:contains('Down')").hide();
}