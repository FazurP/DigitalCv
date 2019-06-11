$(document).ready(function () {

    $('#strUrlDocumento').prop('disabled', true);
    $('#IdInstitucionSuperior').prop('disabled', true);
    $('#FechaInicio').prop('disabled', true);
    $('#FechaTermino').prop('disabled', true);
    $('#btnSubmit').prop('disabled', true);


    $('#rdbSi').change(function () {
        $('#strUrlDocumento').prop('disabled', false);
        toastr.info("Seleccione su(s) Evidencia(s) del Curso(s) Impartido.", "Digital-Cv dice", { timeOut: 1000, closeButton: true })
    })

    $('#rdbNo').change(function () {
        $('#strUrlDocumento').prop('disabled', true);
               
    })

    $('#IdCurso').change(function () {

        var curso = $('#IdCurso').val();

        if (curso == null || curso == 0 || curso == '0' || curso == "0") {

            $('#IdInstitucionSuperior').prop('disabled', true);
            $('#FechaInicio').prop('disabled', true);
            $('#FechaTermino').prop('disabled', true);
            
            $('#btnSubmit').prop('disabled', true);

            $('#IdInstitucionSuperior').val(0);
            $('#FechaInicio').val('');
            $('#FechaTermino').val('');

        } else {
            $('#IdInstitucionSuperior').prop('disabled', false);
            toastr.success('Institución Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#IdInstitucionSuperior').change(function () {

        var institucion = $('#IdInstitucionSuperior').val();

        if (institucion == null || institucion == 0 || institucion == '0' || institucion == "0") {
            $('#FechaInicio').prop('disabled', true);
            $('#FechaTermino').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);
        } else {
            $('#FechaInicio').prop('disabled', false);
            toastr.success('Institución Selecccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#FechaInicio').change(function () {
        var fechaInicio = $('#FechaInicio').val();
        if (fechaInicio == null || fechaInicio == 0 || fechaInicio == '0' || fechaInicio == "0")
        {
            $('#FechaTermino').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);
        }
        else {
            $('#FechaTermino').prop('disabled', false);
            toastr.success('Fecha de Inicio Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#FechaTermino').change(function () {
        var fechaTermino = $('#FechaTermino').val();
        if (fechaTermino == null || fechaTermino == 0 || fechaTermino == '0' || fechaTermino == "0")
        {
            if (Date.parse($('#FechaTermino').val()) >= Date.parse($('#FechaInicio').val() )) {
                $('#btnSubmit').prop('disabled', true);
            }
            else
            {
                toastr.warning('Selecciona una fecha valida', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            }            
        }
        else {
            $('#btnSubmit').prop('disabled', false);
            toastr.success('Fecha de Termino Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    
})