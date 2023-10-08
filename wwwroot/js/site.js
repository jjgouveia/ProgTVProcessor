$('form').submit(function (event) {
    event.preventDefault();
    var formData = new FormData(this);
    $.ajax({
        url: '/Index?handler=ProcessVideo',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            var jsonString = JSON.stringify(data, null, 4);
            $('#jsonDisplay').text(jsonString);
        }
    });
});
