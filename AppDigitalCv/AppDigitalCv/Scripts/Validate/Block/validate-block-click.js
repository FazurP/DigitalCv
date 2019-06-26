$(document).ready(function () {

    $(document).keydown(function (event) {

        if (event.ctrlKey && event.keyCode == 85) {
            alert("ctrl+u");
            return false;
        } else if (event.ctrlKey && event.shiftKey && event.keyCode == 73) {
            alert("ctrl+shift+i");
            return false;        
        }
    });

    document.oncontextmenu = function () {

        return false;

    }


})