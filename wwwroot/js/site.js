// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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
            $('#result').html('Informações do vídeo: ' + JSON.stringify(data));
        }
    });
});