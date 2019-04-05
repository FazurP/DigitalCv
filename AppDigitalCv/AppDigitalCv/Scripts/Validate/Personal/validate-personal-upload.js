$(document).ready(function () {

    $('#Enviar').click(function () {

        //Archivo Pdf Curp
        var element = $('#UCurp');
        var extend = element.val();

        //Archivo Pdf Rfc
        var element2 = $('#URfc');
        var extend2 = element2.val();

        //Imaganes JPG
        var element3 = $('#fotoInputFile');
        var extend3 = element3.val();

        //RegExp para archivos PDF
        var regExp = /(.pdf)/
        //RegExp para Imaganes JPG
        var regExp2 = /(.jpg)/

        if (!regExp.exec(extend) || !regExp.exec(extend2) || !regExp2.exec(extend3)) {
            toastr.warning("Solo se permiten archivos pdf e imagenes JPG.");
            return false;
        } else {
            toastr.success("Archivos cargados correctamente");
            return true;
        }

    })



})