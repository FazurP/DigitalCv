$(document).ready(function () {


    $('#btnEnviar').click(function () {

        //Obtener extension del archivo cargado
        var file = $('#IdRfc');
        var ext = file.val();

        //Obtener extension del archivo cargado
        var file2 = $('#IdCurp');
        var ext2 = file2.val();

        //RegExp para solo PDF
        var regExp = /(.pdf)/

        if (!regExp.exec(ext) || !regExp.exec(ext2)) {
            toastr.warning("Solo se permiten archivos PDF");
            return false;
        } else {
            toastr.success("Archivos cargados correctamente");
            return true;
        }


    })


})