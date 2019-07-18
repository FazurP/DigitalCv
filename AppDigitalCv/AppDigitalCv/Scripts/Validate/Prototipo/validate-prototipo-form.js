$(document).ready(function () {

    $('#ddlTipoPrototipo').prop("disabled", true);
    $('#txtNombrePrototipo').prop("disabled", true);
    $('#txtObjetivos').prop("disabled", true);
    $('#txtCaracteristicas').prop("disabled", true);
    $('#txtInstitucionDestinada').prop("disabled", true);
    $('#dteFechaPublicacion').prop("disabled", true);
    $('#ddlEstadoActual').prop("disabled", true);
    $('#ddlPais').prop("disabled", true);
    $('#ddlProposito').prop("disabled", true);
    $('#inputFileUpload').prop("disabled", true);
    $('#btnGuardar').prop("disabled", true);

    $('#txtAutor').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#ddlTipoPrototipo').prop("disabled", true);
            $('#txtNombrePrototipo').prop("disabled", true);
            $('#txtObjetivos').prop("disabled", true);
            $('#txtCaracteristicas').prop("disabled", true);
            $('#txtInstitucionDestinada').prop("disabled", true);
            $('#dteFechaPublicacion').prop("disabled", true);
            $('#ddlEstadoActual').prop("disabled", true);
            $('#ddlPais').prop("disabled", true);
            $('#ddlProposito').prop("disabled", true);
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#ddlTipoPrototipo').get(0).selectedIndex = 0;
            $('#txtNombrePrototipo').val('');
            $('#txtObjetivos').val('');
            $('#txtCaracteristicas').val('');
            $('#txtInstitucionDestinada').val('');
            $('#dteFechaPublicacion').val('');
            $('#ddlEstadoActual').get(0).selectedIndex = 0;
            $('#ddlPais').val(0);
            $('#ddlProposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else
        {
            $('#ddlTipoPrototipo').prop("disabled", false);
        }

    })

    $('#ddlTipoPrototipo').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#txtNombrePrototipo').prop("disabled", true);
            $('#txtObjetivos').prop("disabled", true);
            $('#txtCaracteristicas').prop("disabled", true);
            $('#txtInstitucionDestinada').prop("disabled", true);
            $('#dteFechaPublicacion').prop("disabled", true);
            $('#ddlEstadoActual').prop("disabled", true);
            $('#ddlPais').prop("disabled", true);
            $('#ddlProposito').prop("disabled", true);
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#txtNombrePrototipo').val('');
            $('#txtObjetivos').val('');
            $('#txtCaracteristicas').val('');
            $('#txtInstitucionDestinada').val('');
            $('#dteFechaPublicacion').val('');
            $('#ddlEstadoActual').get(0).selectedIndex = 0;
            $('#ddlPais').val(0);
            $('#ddlProposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            toastr.success('Tipo de Prototipo Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#txtNombrePrototipo').prop("disabled", false);
        }

    })

    $('#txtNombrePrototipo').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#txtObjetivos').prop("disabled", true);
            $('#txtCaracteristicas').prop("disabled", true);
            $('#txtInstitucionDestinada').prop("disabled", true);
            $('#dteFechaPublicacion').prop("disabled", true);
            $('#ddlEstadoActual').prop("disabled", true);
            $('#ddlPais').prop("disabled", true);
            $('#ddlProposito').prop("disabled", true);
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#txtObjetivos').val('');
            $('#txtCaracteristicas').val('');
            $('#txtInstitucionDestinada').val('');
            $('#dteFechaPublicacion').val('');
            $('#ddlEstadoActual').get(0).selectedIndex = 0;
            $('#ddlPais').val(0);
            $('#ddlProposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#txtObjetivos').prop("disabled", false);
        }

    })

    $('#txtObjetivos').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#txtCaracteristicas').prop("disabled", true);
            $('#txtInstitucionDestinada').prop("disabled", true);
            $('#dteFechaPublicacion').prop("disabled", true);
            $('#ddlEstadoActual').prop("disabled", true);
            $('#ddlPais').prop("disabled", true);
            $('#ddlProposito').prop("disabled", true);
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#txtCaracteristicas').val('');
            $('#txtInstitucionDestinada').val('');
            $('#dteFechaPublicacion').val('');
            $('#ddlEstadoActual').get(0).selectedIndex = 0;
            $('#ddlPais').val(0);
            $('#ddlProposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#txtCaracteristicas').prop("disabled", false);
        }

    })

    $('#txtCaracteristicas').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#txtInstitucionDestinada').prop("disabled", true);
            $('#dteFechaPublicacion').prop("disabled", true);
            $('#ddlEstadoActual').prop("disabled", true);
            $('#ddlPais').prop("disabled", true);
            $('#ddlProposito').prop("disabled", true);
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#txtInstitucionDestinada').val('');
            $('#dteFechaPublicacion').val('');
            $('#ddlEstadoActual').get(0).selectedIndex = 0;
            $('#ddlPais').val(0);
            $('#ddlProposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#txtInstitucionDestinada').prop("disabled", false);
        }

    })

    $('#txtInstitucionDestinada').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#dteFechaPublicacion').prop("disabled", true);
            $('#ddlEstadoActual').prop("disabled", true);
            $('#ddlPais').prop("disabled", true);
            $('#ddlProposito').prop("disabled", true);
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#dteFechaPublicacion').val('');
            $('#ddlEstadoActual').get(0).selectedIndex = 0;
            $('#ddlPais').val(0);
            $('#ddlProposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#dteFechaPublicacion').prop("disabled", false);
        }

    })

    $('#dteFechaPublicacion').change(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#ddlEstadoActual').prop("disabled", true);
            $('#ddlPais').prop("disabled", true);
            $('#ddlProposito').prop("disabled", true);
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#ddlEstadoActual').get(0).selectedIndex = 0;
            $('#ddlPais').val(0);
            $('#ddlProposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#ddlEstadoActual').prop("disabled", false);
        }

    })

    $('#ddlEstadoActual').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#ddlPais').prop("disabled", true);
            $('#ddlProposito').prop("disabled", true);
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#ddlPais').val(0);
            $('#ddlProposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            toastr.success('Estado Actual Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
            $('#ddlPais').prop("disabled", false);
        }

    })

    $('#ddlPais').change(function () {

        let data = $(this).val();

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#ddlProposito').prop("disabled", true);
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#ddlProposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            toastr.success('Pais Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
            $('#ddlProposito').prop("disabled", false);
        }

    })

    $('#ddlProposito').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#inputFileUpload').prop("disabled", true);
            $('#btnGuardar').prop("disabled", true);

            $('#inputFileUpload').val('');
        } else {
            toastr.success('Proposito Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
            $('#inputFileUpload').prop("disabled", false);
        }

    })

    $('#inputFileUpload').change(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#btnGuardar').prop("disabled", true);
        } else {
            $('#btnGuardar').prop("disabled", false);
        }

    })
})