﻿$(document).ready(function () {


    $('#btnGuardar').click(function () {

        if (!$("#check input[name='idC']").is(':checked')) {
            toastr.warning('Debes Seleccionar una Competencia', "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            return false;
        } else {
            return true;
        }

    })

})