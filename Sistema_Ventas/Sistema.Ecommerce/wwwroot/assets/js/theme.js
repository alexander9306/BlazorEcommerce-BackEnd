window.CarritoToaster = () => {
    $('.toast').toast('show');
}


window.blazorExtensions = {
    WriteCookie: function (cookie) {
        //var expires;
        //if (days) {
        //    var date = new Date(days);
        //    //date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        //    expires = "; expires=" + date.toGMTString();
        //}
        //else {
        //    expires = "";
        //}
        //document.cookie = name + "=" + value + expires + "; path=/";
        document.cookie = cookie;
    }
}