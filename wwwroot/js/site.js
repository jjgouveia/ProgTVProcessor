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
            dataJSON = data;
            var jsonString = JSON.stringify(data, null, 4);
            $('#jsonDisplay').text(jsonString);
        }
    });
});

$('#jsonDisplay').on('DOMSubtreeModified', function () {
    var jsonContent = $('#jsonDisplay').text().trim();
    if (jsonContent === '') {
        $('#downloadLink').hide();
    } else {
        $('#downloadLink').show();
    }
});

$('#downloadLink').click(function () {
    if ($('#downloadLink').is(':visible')) {
        let jsonData = $('#jsonDisplay').text();
        var blob = new Blob([jsonData], { type: "application/json" });
        var url = URL.createObjectURL(blob);
        var a = document.createElement('a');
        a.href = url;
        a.download = `dados_do_video_${dataJSON.title}.json`;
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
    } else {
        return false;
    }
});



