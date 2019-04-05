$(document).ready(function () {


    var p = $("#Pais").val();
    var e = $("#Estados").val();
    var m = $("#Municipios").val();
    var c = $("#IdColonia").val();
    $('#NInterior').attr("disabled", true);
    $('#NExterior').attr("disabled", true);
    $('#Calle').attr("disabled", true);
    $('#codigoPostal').attr("disabled", true);


    if (p == "0" || p == "") {
        $('#Enviar').attr("disabled", true);

    }

    $('#Pais').change(function () {

        var pp = $("#Pais").val();

        if (pp == "0" || pp == "") {
            $('#Enviar').attr("disabled", true);
        } else {
            toastr.success("Pais Seleccionado");
        }

    })
    $('#Estados').change(function () {

        var ee = $("#Estados").val();

        if (ee == "0" || ee == "") {
            $('#Enviar').attr("disabled", true);
        } else {
            toastr.success("Estado Seleccionado");
        }
    })
    $('#Municipios').change(function () {

        var mm = $("#Municipios").val();

        if (mm == "0" || mm == "") {
            $('#Enviar').attr("disabled", true);
        } else {
            toastr.success("Municipio Seleccionado");
        }
    })
    $('#IdColonia').change(function () {

        var cc = $("#IdColonia").val();

        if (cc == "0" || cc == "") {
            $('#Enviar').attr("disabled", true);
            $('#Calle').attr("disabled", true);
        } else {
            $('#Calle').attr("disabled", false);
            toastr.success("Municipio Seleccionado");
        }
    })

    $('#Calle').keyup(function () {

        var texto = $('#Calle').val();

        if (texto == "") {
            $('#Enviar').attr("disabled", true);
            $('#NInterior').attr("disabled", true);
            $('#NExterior').attr("disabled", true);

            $('#NInterior').val("");
            $('#NExterior').val("");
        } else {

            $('#NInterior').attr("disabled", false);

        }

    })

    $('#NInterior').keyup(function () {

        var texto = $('#NInterior').val();

        if (texto == "") {

            $('#Enviar').attr("disabled", true);

            $('#NExterior').attr("disabled", true);
            $('#NExterior').val("");

        } else {

            $('#NExterior').attr("disabled", false);

        }

    })

    $('#NExterior').keyup(function () {

        var texto = $('#NExterior').val();

        if (texto == "") {

            $('#Enviar').attr("disabled", true);

        } else {
            $('#Enviar').attr("disabled", false);

        }

    })

})