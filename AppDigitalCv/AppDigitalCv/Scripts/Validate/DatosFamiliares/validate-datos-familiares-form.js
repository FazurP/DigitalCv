$(document).ready(function () {

    $('#domiciliopadre').attr('disabled', true);
    $('#ocupacionpadre').attr('disabled', true);
    $('#FechaNacimientoPadre').attr('disabled', true);
    $('#ApellidoPaternoPadre').attr('disabled', true);
    $('#ApellidoMaternoPadre').attr('disabled', true);

    $('#nombremadre').attr('disabled', true); 
    $('#domiciliomadre').attr('disabled', true); 
    $('#ocupacionmadre').attr('disabled', true); 
    $('#FechaNacimientoMadre').attr('disabled', true);
    $('#ApellidoPaternoMadre').attr('disabled', true);
    $('#ApellidoMaternoMadre').attr('disabled', true);

    $('#nombrepareja').attr('disabled', true);
    $('#domiciliopareja').attr('disabled', true);
    $('#ocupacionpareja').attr('disabled', true);
    $('#FechaNacimientoPareja').attr('disabled', true);
    $('#ApellidoPaternoPareja').attr('disabled', true);
    $('#ApellidoMaternoPareja').attr('disabled', true);

    $('#rdbPadreVive').attr('disabled', true);
    $('#rdbPadreFinado').attr('disabled', true);

    $('#rdbMadreVive').attr('disabled', true);
    $('#rdbMadreFinado').attr('disabled', true);

    $('#rdbParejaVive').attr('disabled', true);
    $('#rdbParejaFinado').attr('disabled', true);

    $('#btnGuardar').attr('disabled', true);

    //Eventos para la validacion de los campos de texto del padre
    $('#nombrepadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ApellidoPaternoPadre').attr('disabled', true);
            $('#ApellidoMaternoPadre').attr('disabled', true);
            $('#domiciliopadre').attr('disabled', true);
            $('#ocupacionpadre').attr('disabled', true);
            $('#FechaNacimientoPadre').attr('disabled', true);           
            $('#nombremadre').attr('disabled', true);
            $('#ApellidoPaternoMadre').attr('disabled', true);
            $('#ApellidoMaternoMadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);           
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);        
            $('#rdbPadreVive').attr('disabled', true);
            $('#rdbPadreFinado').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else
        {
            $('#ApellidoPaternoPadre').attr('disabled', false);
            
        }


    })

    $('#ApellidoPaternoPadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ApellidoMaternoPadre').attr('disabled', true);
            $('#domiciliopadre').attr('disabled', true);
            $('#ocupacionpadre').attr('disabled', true);
            $('#FechaNacimientoPadre').attr('disabled', true);
            $('#nombremadre').attr('disabled', true);
            $('#ApellidoPaternoMadre').attr('disabled', true);
            $('#ApellidoMaternoMadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbPadreVive').attr('disabled', true);
            $('#rdbPadreFinado').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#ApellidoMaternoPadre').attr('disabled', false);
        }


    })

    $('#ApellidoMaternoPadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#domiciliopadre').attr('disabled', true);
            $('#ocupacionpadre').attr('disabled', true);
            $('#FechaNacimientoPadre').attr('disabled', true);
            $('#nombremadre').attr('disabled', true);
            $('#ApellidoPaternoMadre').attr('disabled', true);
            $('#ApellidoMaternoMadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbPadreVive').attr('disabled', true);
            $('#rdbPadreFinado').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#rdbPadreVive').attr('disabled', false);
            $('#rdbPadreFinado').attr('disabled', false);

        }


    })

    $('#domiciliopadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ocupacionpadre').attr('disabled', true);
            $('#FechaNacimientoPadre').attr('disabled', true);
            $('#nombremadre').attr('disabled', true);
            $('#ApellidoPaternoMadre').attr('disabled', true);
            $('#ApellidoMaternoMadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#ocupacionpadre').attr('disabled', false);
        }
    })

    $('#ocupacionpadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#FechaNacimientoPadre').attr('disabled', true);
            $('#nombremadre').attr('disabled', true);
            $('#ApellidoPaternoMadre').attr('disabled', true);
            $('#ApellidoMaternoMadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#FechaNacimientoPadre').attr('disabled', false);
        }
    })

    $('#FechaNacimientoPadre').change(function () {

        var text = $(this).val();

        if (text == "") {

            $('#nombremadre').attr('disabled', true);
            $('#ApellidoPaternoMadre').attr('disabled', true);
            $('#ApellidoMaternoMadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#nombremadre').attr('disabled', false);
        }
    })

    $('#nombremadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ApellidoPaternoMadre').attr('disabled', true);
            $('#ApellidoMaternoMadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#ApellidoPaternoMadre').attr('disabled', false);
        }
    })

    $('#ApellidoPaternoMadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ApellidoMaternoMadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#ApellidoMaternoMadre').attr('disabled', false);
        }
    })

    $('#ApellidoMaternoMadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#rdbMadreVive').attr('disabled', false);
            $('#rdbMadreFinado').attr('disabled', false);
        }
    })

    $('#domiciliomadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ocupacionmadre').attr('disabled', true);
            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#ocupacionmadre').attr('disabled', false);
        }
    })

    $('#ocupacionmadre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#FechaNacimientoMadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#FechaNacimientoMadre').attr('disabled', false);
        }
    })

    $('#FechaNacimientoMadre').change(function () {

        var text = $(this).val();

        if (text == "") {

            $('#nombrepareja').attr('disabled', true);
            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

        } else {
            $('#nombrepareja').attr('disabled', false);
            $('#btnGuardar').attr('disabled', false);
        }
    })

    $('#nombrepareja').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ApellidoPaternoPareja').attr('disabled', true);
            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);

        } else {
            $('#ApellidoPaternoPareja').attr('disabled', false);
        }
    })

    $('#ApellidoPaternoPareja').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ApellidoMaternoPareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);

        } else {
            $('#ApellidoMaternoPareja').attr('disabled', false);
        }
    })

    $('#ApellidoMaternoPareja').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);

        } else {
            $('#rdbParejaVive').attr('disabled', false);
            $('#rdbParejaFinado').attr('disabled', false);
        }
    })

    $('#domiciliopareja').keyup(function () {

        var text = $(this).val();

        if (text == "") {
            $('#ocupacionpareja').attr('disabled', true);
            $('#FechaNacimientoPareja').attr('disabled', true);
        } else {
            $('#ocupacionpareja').attr('disabled', false);
        }
    })

    $('#ocupacionpareja').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#FechaNacimientoPareja').attr('disabled', true);

        } else {
            $('#FechaNacimientoPareja').attr('disabled', false);
        }
    })

})