$(document).ready(function () {

    $('#Numero').prop('disabled', true);
    $('#Vigencia').prop('disabled', true);
    $('#Expedicion').prop('disabled', true);
    $('#Evidencia').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#Documentos').change(function () {
        var documento = $('#Documentos').val();

        if (documento == '--Seleccionar--') {

            $('#Numero').prop('disabled', true);
            $('#Vigencia').prop('disabled', true);
            $('#Expedicion').prop('disabled', true);
            $('#Evidencia').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Numero').val('');
            $('#Expedicion').val('');
            $('#Vigencia').val('');
            $('#Evidencia').val('');
            $('#lblNumero').html("Numero");
            $('#lblExpedicion').html("Expedicion");
            $('#lblVigencia').html("Vigencia");
            $('#lblEvidencia').html("Evidencia");

        } else {
            $('#Numero').prop('disabled', true);
            $('#Vigencia').prop('disabled', true);
            $('#Expedicion').prop('disabled', true);
            $('#Evidencia').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Numero').val('');
            $('#Expedicion').val('');
            $('#Vigencia').val('');
            $('#Evidencia').val('');
            $('#lblNumero').html("Numero");
            $('#lblExpedicion').html("Expedicion");
            $('#lblVigencia').html("Vigencia");
            $('#lblEvidencia').html("Evidencia");
           

            if (documento == 'IFE' || documento == 'Comprobante de Domicilio' || documento == 'Solicitud de Empleo') {
                $('#lblNumero').html("N/A");
                $('#lblExpedicion').html('N/A');
                $('#lblVigencia').html('N/A');
                $('#Numero').prop('disabled', true);
                $('#Vigencia').prop('disabled', true);
                $('#Expedicion').prop('disabled', true);
                $('#Evidencia').prop('disabled', false);

                if (documento == 'IFE') {
                    $('#Evidencia').prop('disabled', true);
                    $('#Expedicion').prop('disabled', false);
                    $('#lblExpedicion').html('Expedición IFE');
                    $('#lblVigencia').html('Vigencia IFE');
                    $('#lblEvidencia').html('Evidencia IFE');
                } else if (documento == 'Comprobante de Domicilio') {
                    $('#lblEvidencia').html('Evidencia Comprobante');
                } else if (documento == 'Solicitud de Empleo') {                 
                    $('#lblEvidencia').html('Evidencia Solicitud');
                }

                toastr.success("Tipo de Documento Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });

            } else {
                $('#Numero').prop('disabled', false);
                if (documento == 'Licencia de Manejo') {
                    $('#lblNumero').html('Numero de Licencia');
                    $('#lblVigencia').html('Vigencia de Licencia');
                    $('#lblExpedicion').html('Expedicion de Licencia');
                    $('#lblEvidencia').html('Evidencia de Licencia');
                } else if (documento == 'Pasaporte') {
                    $('#lblNumero').html('Numero de Pasaporte');
                    $('#lblExpedicion').html('Expedicion Pasaporte');
                    $('#lblVigencia').html('Vigencia de Pasaporte');
                    $('#lblEvidencia').html('Evidencia de Pasaporte');
                } else if (documento == 'Visa de USA') {
                    $('#lblNumero').html('Numero de Visa USA');
                    $('#lblExpedicion').html('Expedicion de Visa');
                    $('#lblVigencia').html('Vigencia de Visa USA');
                    $('#lblEvidencia').html('Evidencia de Visa USA');
                } else if (documento == 'Visa de Canada') {
                    $('#lblNumero').html('Numero de Visa Canada');
                    $('#lblExpedicion').html('Expedicion de Visa');
                    $('#lblVigencia').html('Vigencia de Visa Canada');
                    $('#lblEvidencia').html('Evidencia de Visa Canada');
                } else if (documento == 'Seguridad Social') {
                    $('#lblNumero').html('Numero de Seguridad');
                    $('#lblExpedicion').html('Expedicion Seguridad');
                    $('#lblVigencia').html('Vigencia de Seguridad');
                    $('#lblEvidencia').html('Evidencia de Seguridad Social');
                } else if (documento == 'Registro Prof, Estatal') {
                    $('#lblNumero').html('Numero de Prof, Estatal');
                    $('#lblExpedicion').html('Expedicion Prof, Estatal');
                    $('#lblVigencia').html('Vigencia de Prof, Estatal');
                    $('#lblEvidencia').html('Evidencia de Prof, Estatal');
                } else if (documento == 'Cartilla Militar') {
                    $('#lblNumero').html('Numero Cartilla Militar');
                    $('#lblExpedicion').html('Expedicion Cart, Militar');
                    $('#lblVigencia').html('N/A');
                    $('#lblEvidencia').html('Evidencia de Cartilla Militar');
                }
                toastr.success("Tipo de Documento Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            }
           
        }

    })

    $('#Numero').keyup(function () {
        var numero = $('#Numero').val();

        if (numero == null || numero == "" || numero == '') {
            $('#Vigencia').prop('disabled', true);
            $('#Expedicion').prop('disabled', true);
            $('#Evidencia').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Expedicion').val('');
            $('#Vigencia').val('');
            $('#Evidencia').val('');
        } else {
            $('#Expedicion').prop('disabled', false);
        }
    })

    $('#Expedicion').change(function () {
        var expedicion = $('#Expedicion').val();

        if (expedicion == null || expedicion == "" || expedicion == '') {
            $('#Vigencia').prop('disabled', true);
            $('#Evidencia').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Vigencia').val('');
            $('#Evidencia').val('');
        } else {
            var documento = $('#Documentos').val();
            if (documento == 'Cartilla Militar') {
                $('#Vigencia').prop('disabled', true);
                $('#Evidencia').prop('disabled', false);
            } else {
                $('#Vigencia').prop('disabled', false);
            }
            
        }
    })

    $('#Vigencia').change(function () {
        var vigencia = $('#Vigencia').val();

        if (vigencia == null || vigencia == "" || vigencia == '') {

            $('#Evidencia').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Evidencia').val('');
        } else {
            $('#Evidencia').prop('disabled', false);
        }
    })

    $('#Evidencia').change(function () {
        var evidencia = $('#Evidencia').val();

        if (evidencia == "") {
            $('#btnGuardar').prop('disabled', true);
        } else {
            $('#btnGuardar').prop('disabled', false);
        }
    })

})
