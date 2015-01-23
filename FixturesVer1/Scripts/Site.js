$(function () {
    //$('#search-box').keyup(function (e) {
    //    if (e.keyCode == 13) {
    //        event.preventDefault();
    //        var location = this.val();
    //        console.log("location: " + location);
    //        //$("#search-form").attr("action", "/Properties/Listing/?location=" + location);
    //        //$("#search-form").submit();
    //    }
    //});
    $("#search-form").submit(function (e) {
        //e.preventDefault();


        //var location = $('#search-box').val();
        //console.log("location: " + location);
        //$("#search-form").attr("action", "/Properties/Listing/?location=" + location);
        //$("#search-form").submit();
    });
})