$.delete = function (url) {
    return $.ajax({
        url: url,
        type: 'DELETE'
    });
});