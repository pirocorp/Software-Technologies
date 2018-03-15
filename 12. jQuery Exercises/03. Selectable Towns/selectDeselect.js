$('#items li').click(function() {
    let li = $(this);
    if (li.attr('data-selected')) {
        li.removeAttr('data-selected');
        li.css('background', '')
    } else {
        li.attr('data-selected', 'true');
        li.css('background', '#DDD')
    }
});