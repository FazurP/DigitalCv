$(document).ready(function () {

    

    $('#btnGuardar').click(function () {

        var file = $('#documentoInputFile');
        var ext = file.val();

        var regExp = /(.pdf)/;

        if (!regExp.exec(ext)) {
            toastr.warning("Solo se permiten archivos PDF");
            return false;
        } else {
            toastr.success("Archivos cargado correctamente");
            return true;
            document.clear();
        }
    })



    

})