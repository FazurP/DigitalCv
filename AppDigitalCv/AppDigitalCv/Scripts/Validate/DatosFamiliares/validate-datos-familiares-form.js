$(document).ready(function () {

    $('#domiciliopadre').attr('disabled', true);
    $('#ocupacionpadre').attr('disabled', true);
    $('#edadpadre').attr('disabled', true);
    $('#nombremadre').attr('disabled', true); 
    $('#domiciliomadre').attr('disabled', true); 
    $('#ocupacionmadre').attr('disabled', true); 
    $('#edadmadre').attr('disabled', true); 
    $('#nombrepareja').attr('disabled', true);
    $('#domiciliopareja').attr('disabled', true);
    $('#domiciliopareja').attr('disabled', true);
    $('#ocupacionpareja').attr('disabled', true);
    $('#edadpareja').attr('disabled', true);
    $('#rdbPadreVive').attr('disabled', true);
    $('#rdbPadreFinado').attr('disabled', true);
    $('#rdbMadreVive').attr('disabled', true);
    $('#rdbMadreFinado').attr('disabled', true);
    $('#rdbParejaVive').attr('disabled', true);
    $('#rdbParejaFinado').attr('disabled', true);
    $('#btnGuardar').attr('disabled', true);

    //Eventos para la validacion de los campos de texto del padre
    $('#nombrepadre').keyup(function () {

        var text = $('#nombrepadre').val();

        if (text == "") {

            $('#domiciliopadre').attr('disabled', true);
            $('#ocupacionpadre').attr('disabled', true);
            $('#edadpadre').attr('disabled', true);
            $('#nombremadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#edadmadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);
            $('#rdbPadreVive').attr('disabled', true);
            $('#rdbPadreFinado').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#domiciliopadre').val("");
            $('#ocupacionpadre').val("");
            $('#edadpadre').val("");
            $('#nombremadre').val("");
            $('#domiciliomadre').val("");
            $('#ocupacionmadre').val("");
            $('#edadmadre').val("");
            $('#nombrepareja').val("");
            $('#domiciliopareja').val("");
            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");
            $('#rdbPadreVive').prop('checked', false);
            $('#rdbPadreFinado').prop('checked', false);

        } else
        {
            $('#rdbPadreVive').attr('disabled', false);
            $('#rdbPadreFinado').attr('disabled', false);
            
        }


    })

    $('#domiciliopadre').keyup(function () {


        var text = $('#domiciliopadre').val();

        if (text == "") {

            
            $('#ocupacionpadre').attr('disabled', true);
            $('#edadpadre').attr('disabled', true);
            $('#nombremadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#edadmadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

           
            $('#ocupacionpadre').val("");
            $('#edadpadre').val("");
            $('#nombremadre').val("");
            $('#domiciliomadre').val("");
            $('#ocupacionmadre').val("");
            $('#edadmadre').val("");
            $('#nombrepareja').val("");
            $('#domiciliopareja').val("");
            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");

        } else {
            $('#ocupacionpadre').attr('disabled', false);
        }


    })

    $('#ocupacionpadre').keyup(function () {


        var text = $('#ocupacionpadre').val();

        if (text == "") {


           
            $('#edadpadre').attr('disabled', true);
            $('#nombremadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#edadmadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);


           
            $('#edadpadre').val("");
            $('#nombremadre').val("");
            $('#domiciliomadre').val("");
            $('#ocupacionmadre').val("");
            $('#edadmadre').val("");
            $('#nombrepareja').val("");
            $('#domiciliopareja').val("");
            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");

        } else {
            $('#edadpadre').attr('disabled', false);
        }


    })

    $('#edadpadre').keyup(function () {


        var text = $('#edadpadre').val();

        if (text == "") {



           
            $('#nombremadre').attr('disabled', true);
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#edadmadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);



            
            $('#nombremadre').val("");
            $('#domiciliomadre').val("");
            $('#ocupacionmadre').val("");
            $('#edadmadre').val("");
            $('#nombrepareja').val("");
            $('#domiciliopareja').val("");
            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");

        } else {
            $('#nombremadre').attr('disabled', false);
        }


    })

    $('#rdbPadreFinado').change(function () {

    $('#nombremadre').attr('disabled', false);

    })

    $('#rdbPadreVive').change(function () {
        $('#nombremadre').attr('disabled', true);
    })

    //Eventos para la validacion de los campos de texto de la madre

    $('#nombremadre').keyup(function () {


        var text = $('#nombremadre').val();

        if (text == "") {

          
            $('#domiciliomadre').attr('disabled', true);
            $('#ocupacionmadre').attr('disabled', true);
            $('#edadmadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);
            $('#rdbMadreVive').attr('disabled', true);
            $('#rdbMadreFinado').attr('disabled', true);

           
            $('#domiciliomadre').val("");
            $('#ocupacionmadre').val("");
            $('#edadmadre').val("");
            $('#nombrepareja').val("");
            $('#domiciliopareja').val("");
            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");
            $('#rdbPadreVive').prop('checked', false);
            $('#rdbPadreFinado').prop('checked', false);

        } else {
            $('#rdbMadreVive').attr('disabled', false);
            $('#rdbMadreFinado').attr('disabled', false);
        }


    })

    $('#domiciliomadre').keyup(function () {


        var text = $('#domiciliomadre').val();

        if (text == "") {

            $('#ocupacionmadre').attr('disabled', true);
            $('#edadmadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);


            $('#ocupacionmadre').val("");
            $('#edadmadre').val("");
            $('#nombrepareja').val("");
            $('#domiciliopareja').val("");
            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");

        } else {
            $('#ocupacionmadre').attr('disabled', false);
        }


    })

    $('#ocupacionmadre').keyup(function () {


        var text = $('#ocupacionmadre').val();

        if (text == "") {

            $('#edadmadre').attr('disabled', true);
            $('#nombrepareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#edadmadre').val("");
            $('#nombrepareja').val("");
            $('#domiciliopareja').val("");
            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");

        } else {
            $('#edadmadre').attr('disabled', false);
        }


    })

    $('#edadmadre').keyup(function () {


        var text = $('#edadmadre').val();

        if (text == "") {

            
            $('#nombrepareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

         
            $('#nombrepareja').val("");
            $('#domiciliopareja').val("");
            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");

        } else {
            $('#nombrepareja').attr('disabled', false);
            $('#btnGuardar').attr('disabled', false);
        }


    })

    $('#rdbMadreFinado').change(function () {

        $('#nombrepareja').attr('disabled', false);
        $('#btnGuardar').attr('disabled', false);
    })

    $('#rdbMadreVive').change(function () {
        $('#nombrepareja').attr('disabled', true);
    })

    //Eventos para la validacion de los campos de texto de la pareja

    $('#nombrepareja').keyup(function () {


        var text = $('#nombrepareja').val();

        if (text == "") {
          
            $('#domiciliopareja').attr('disabled', true);
            $('#domiciliopareja').attr('disabled', true);
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);
            $('#rdbParejaVive').attr('disabled', true);
            $('#rdbParejaFinado').attr('disabled', true);
            

            $('#domiciliopareja').val("");
            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");
            $('#rdbParejaVive').prop('checked', false);
            $('#rdbParejaFinado').prop('checked', false);

        } else {

            $('#rdbParejaVive').attr('disabled', false);
            $('#rdbParejaFinado').attr('disabled', false);
            $('#btnGuardar').attr('disabled', false);
        }


    })

    $('#domiciliopareja').keyup(function () {


        var text = $('#domiciliopareja').val();

        if (text == "") {

           
            $('#ocupacionpareja').attr('disabled', true);
            $('#edadpareja').attr('disabled', true);

            $('#ocupacionpareja').val("");
            $('#edadpareja').val("");

        } else {
            $('#ocupacionpareja').attr('disabled', false);
            $('#btnGuardar').attr('disabled', false);
        }


    })

    $('#ocupacionpareja').keyup(function () {


        var text = $('#ocupacionpareja').val();

        if (text == "") {

            $('#edadpareja').attr('disabled', true);

            $('#edadpareja').val("");

        } else {
            $('#edadpareja').attr('disabled', false);
            $('#btnGuardar').attr('disabled', false);
        }


    })

    $('#edadpareja').keyup(function () {


        var text = $('#edadpareja').val();

        if (text == "") {

        } else {
            $('#btnGuardar').attr('disabled', false);
        }


    })

})