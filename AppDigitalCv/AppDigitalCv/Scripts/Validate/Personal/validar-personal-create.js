$(document).ready(function ()
{

    $('#IdEstadoCivil').prop('disabled', true);
    $('input[name=StrGenero]').prop('disabled', true);
    $('#Curp').prop('disabled', true);
    $('#UCurp').prop('disabled', true);
    $('#Rfc').prop('disabled', true);
    $('#Homoclave').prop('disabled', true);
    $('#URfc').prop('disabled', true);
    $('#InstitucionSalud').prop('disabled', true);
    $('#NumeroSeguroSocial').prop('disabled', true);
    $('#NumeroEmpleado').prop('disabled', true);
    $('#Semblanza').prop('disabled', true);
    $('#Enviar').prop('disabled', true);

    $('#idNacionalidad').change(function ()
    {
        let data = $(this).val();

        if (data == 0) {

            $('#IdEstadoCivil').prop('disabled', true);
            $('input[name=StrGenero]').prop('disabled', true);
            $('#Curp').prop('disabled', true);
            $('#UCurp').prop('disabled', true);
            $('#Rfc').prop('disabled', true);
            $('#Homoclave').prop('disabled', true);
            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#IdEstadoCivil').val(0);
            $('#Curp').val("");
            $('#UCurp').get(0).files = null;
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#URfc').get(0).files = null;
            $('#InstitucionSalud').val(0);
            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else
        {
            $('#IdEstadoCivil').prop('disabled', false);
            toastr.success('Nacionalidad Seleccionada', 'Digital-Cv dice:', { timeOut: 1500, closeButton: true });
        }  
    });

    $('#IdEstadoCivil').change(function () {
        let data = $(this).val();

        if (data == 0) {

            $('input[name=StrGenero]').prop('disabled', true);
            $('#Curp').prop('disabled', true);
            $('#UCurp').prop('disabled', true);
            $('#Rfc').prop('disabled', true);
            $('#Homoclave').prop('disabled', true);
            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#Curp').val("");
            $('#UCurp').get(0).files = null;
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#URfc').get(0).files = null;
            $('#InstitucionSalud').val(0);
            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else {
            $('input[name=StrGenero]').prop('disabled', false);
            toastr.success('Estado Civil Seleccionado', 'Digital-Cv dice:', { timeOut: 1500, closeButton: true });
        }
    });

    $('input[name=StrGenero]').change(function () {
        let data = $(this).val();

        if (data == null) {
            
            $('#Curp').prop('disabled', true);
            $('#UCurp').prop('disabled', true);
            $('#Rfc').prop('disabled', true);
            $('#Homoclave').prop('disabled', true);
            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#Curp').val("");
            $('#UCurp').get(0).files = null;
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#URfc').get(0).files = null;
            $('#InstitucionSalud').val(0);
            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else {
            $('#Curp').prop('disabled', false);
            toastr.success('Sexo Seleccionado', 'Digital-Cv dice:', { timeOut: 1500, closeButton: true });
        }
    });

    $('#Curp').keyup(function () {

        let data = $(this).val();

        if (data == "") {

            $('#UCurp').prop('disabled', true);
            $('#Rfc').prop('disabled', true);
            $('#Homoclave').prop('disabled', true);
            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#UCurp').get(0).files = null;
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#URfc').get(0).files = null;
            $('#InstitucionSalud').val(0);
            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else {
            $('#UCurp').prop('disabled', false);
        }{
           
        }
    });

    $('#UCurp').change(function () {

        let data = $(this).get(0).files[0];
        debugger;
        if (data == undefined) {

            $('#Rfc').prop('disabled', true);
            $('#Homoclave').prop('disabled', true);
            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#URfc').get(0).files = null;
            $('#InstitucionSalud').val(0);
            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else {
            $('#Rfc').prop('disabled', false);
        } 
    });
});