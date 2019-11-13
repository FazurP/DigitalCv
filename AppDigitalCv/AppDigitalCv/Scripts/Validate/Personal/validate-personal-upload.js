$(document).ready(function () {

    $('#UCurp').change(function () {
        var element = $('#UCurp');
        var extend = element.val();
        var regExp = /(.pdf)/

        if (!regExp.exec(extend)) {
            toastr.warning("Solo se Permite Formato PDF.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#UCurp').val('');
        } else {
            toastr.success("Archivo Cargado Correctamente.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
        }

    })

    $('#URfc').change(function () {
        var element = $('#URfc');
        var extend = element.val();
        var regExp = /(.pdf)/

        if (!regExp.exec(extend)) {
            toastr.warning("Solo se Permite Formato PDF.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            $('#URfc').val('');
        } else {
            toastr.success("Archivo Cargado Correctamente.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
        }

    })

    $('#UNacionalidad').change(function () {
        var element = $(this);
        var extend = element.val();
        var regExp = /(.pdf)/

        if (!regExp.exec(extend)) {
            toastr.warning("Solo se Permite Formato PDF.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $(this).val('');
        } else {
            toastr.success("Archivo Cargado Correctamente.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }

    })

    $('#Enviar').click(function () {
        var documentUCurp = $('#UCurp').val();
        var documentURfc = $('#URfc').val();
        var documentNaci = $('#UNacionalidad').val();

        if (documentUCurp == '' && documentURfc == '' && documentNaci == '') {
            toastr.warning("Tienes que Cargar tus Documentos.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            return false;
        } else if (documentURfc == '' && documentUCurp == '') {
            toastr.warning("Tienes que Cargar tus Documentos de RFC y CURP", "Digital-Cv dice", { timeOut: 1000, closeButton: true })
            return false;
        } else if (documentURfc == '' && documentNaci == '') {
            toastr.warning("Tienes que Cargar tus Documentos de RFC y Nacionalidad", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            return false;
        } else if (documentUCurp == '' && documentNaci == '') {
            toastr.warning("Tienes que Cargar tus Documentos de CURP y Nacionalidad", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            return false;
        } else if (documentURfc == '') {
            toastr.warning("Tienes que Cargar tu Documento del RFC", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            return false;
        } else if (documentUCurp == '') {
            toastr.warning("Tienes que Cargar tu Documento del CURP", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            return false;
        } else if (documentNaci == '') {
            toastr.warning("Tienes que Cargar tu Documento de la Nacionalidad", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            return false;
        }else {
            return true;
        }

    });


})