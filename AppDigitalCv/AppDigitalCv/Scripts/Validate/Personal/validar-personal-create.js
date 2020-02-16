$(document).ready(function ()
{

    $('#IdEstadoCivil').prop('disabled', true);
    $('input[name=StrGenero]').prop('disabled', true);
    $('#Curp').prop('disabled', true);
    $('#UCurp').prop('disabled', true);
    $('#Rfc').prop('disabled', true);
    $('#Homoclave').prop('readonly', true);
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
            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#IdEstadoCivil').val(0);
            $('#Curp').val("");
            $('#UCurp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#URfc').val("");
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
            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#Curp').val("");
            $('#UCurp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#URfc').val("");
            $('#InstitucionSalud').val(0);
            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else {
            $('input[name=StrGenero]').prop('disabled', false);
            toastr.success('Estado Civil Seleccionado', 'Digital-Cv dice:', { timeOut: 1500, closeButton: true });
        }
    });

    $('input[name=StrGenero]').on('ifChecked',function () {
       
       $('#Curp').prop('disabled', false);
       toastr.success('Sexo Seleccionado', 'Digital-Cv dice:', { timeOut: 1500, closeButton: true });
    });

    $('#Curp').keyup(function () {

        let data = $(this).val();

        if (data == "") {

            $('#UCurp').prop('disabled', true);
            $('#Rfc').prop('disabled', true);
            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#UCurp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#URfc').val("");
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
        if (data == undefined) {

            $('#Rfc').prop('disabled', true);
            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#URfc').val("");
            $('#InstitucionSalud').val(0);
            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else {
            $('#Rfc').prop('disabled', false);
        } 
    });

    $('#Rfc').keyup(function () {

        let data = $(this).val();
        if (data == "" || data.length < 13) {

            $('#URfc').prop('disabled', true);
            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#Homoclave').val("");
            $('#URfc').val("");
            $('#InstitucionSalud').val(0);
            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");
        } else if (data.length >= 13 && data.length <= 14)
        {
            $('#URfc').prop('disabled', false);
        }
    });

    $('#URfc').change(function () {

        let data = $(this).get(0).files[0];
        if (data == undefined) {

            $('#InstitucionSalud').prop('disabled', true);
            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#InstitucionSalud').val(0);
            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else {
            $('#InstitucionSalud').prop('disabled', false);
        }
    });

    $('#InstitucionSalud').change(function () {

        let data = $(this).val();
        if (data == 0) {

            $('#NumeroSeguroSocial').prop('disabled', true);
            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#NumeroSeguroSocial').val("");
            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else {
            toastr.success("Institución de Salud Seleccionada", "Digital-Cv dice:", { timeOut: 1000, closeButton: true });
            $('#NumeroSeguroSocial').prop('disabled', false);
        }
    });

    $('#NumeroSeguroSocial').keyup(function () {

        let data = $(this).val();
        if (data == "") {

            $('#NumeroEmpleado').prop('disabled', true);
            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#NumeroEmpleado').val("");
            $('#Semblanza').val("");

        } else {
            $('#NumeroEmpleado').prop('disabled', false);
        }
    });

    $('#NumeroEmpleado').keyup(function () {

        let data = $(this).val();
        if (data == "") {

            $('#Semblanza').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#Semblanza').val("");

        } else {
            $('#Semblanza').prop('disabled', false);
        }
    });

    $('#Semblanza').keyup(function () {

        let data = $(this).val();
        if (data == "") {

            $('#Enviar').prop('disabled', true);

        } else {
            $('#Enviar').prop('disabled', false);
        }
    });
});