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

    $('#fotoInputFile').change(function () {
        var element = $('#fotoInputFile');
        var extend = element.val();
        var regExp = /(.jpg)/

        if (!regExp.exec(extend)) {
            toastr.warning("Solo se Permite Formato JPEG/JPG.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            $('#fotoInputFile').val('');
        }

    })

    $('#Enviar').click(function () {
        var documentUCurp = $('#UCurp').val();
        var documentURfc = $('#URfc').val();
        var documentImg = $('#fotoInputFile').val();

        if (documentUCurp == '' && documentURfc == '' && documentImg == '') {
            toastr.warning("Tienes que Cargar tus Documentos.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            return false;
        } else if (documentURfc == '' && documentImg == '') {
            toastr.warning("Tienes que Cargar tu Documento de RFC y Foto de Perfil.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  })
            return false;
        } else if (documentUCurp == '' && documentImg == '') {
            toastr.warning("Tienes que Cargar tu Documento de la Curp y Foto de Perfil", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            return false;
        }else if (documentUCurp == '') {
            toastr.warning("Tienes que Cargar tu Documento de la Curp", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            return false;
        } else if (documentURfc == '') {
            toastr.warning("Tienes que Cargar tu Documento del RFC", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            return false;
        } else if (documentImg == '') {
            toastr.warning("Tienes que Cargar tu Foto de Perfil", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            return false;
        } else {
            return true;
        }

    })


})