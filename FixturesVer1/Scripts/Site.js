$(function () {
    $('#search-box').keydown(function (e) {
        if (e.keyCode == 13) {
            var location = $('#search-box').val();
            $("#locationTextBox").val(location);
            $('#search-form').submit();
        }
    })
});
