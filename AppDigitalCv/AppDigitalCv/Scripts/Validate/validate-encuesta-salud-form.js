$(document).ready(function () {

    $('#cigarrillosDia').prop('disabled', true)
    $('#edadFumador').prop('disabled', true)

    $('#medicamento').prop('disabled', true)
    $('#sustancia').prop('disabled', true)
    $('#alimento').prop('disabled', true)

    $('#varicela').prop('disabled', true)
    $('#rubeola').prop('disabled', true)
    $('#sarempeon').prop('disabled', true)
    $('#escarlatina').prop('disabled', true)
    $('#exantema').prop('disabled', true)
    $('#manos').prop('disabled', true)

    $('#intervencion').prop('disabled', true)

    $('#huesos').prop('disabled', true)
    $('#ligamentos').prop('disabled', true)
    $('#articulaciones').prop('disabled', true)

    $('#causa').prop('disabled', true)

    $('#tipo').prop('disabled', true)
    $('#frecuencia').prop('disabled', true)

    $('#enfermedades').prop('disabled', true)

    $('#tratamiento').prop('disabled', true)
    $('#dosis').prop('disabled', true)

    //////////////////////////Eventos//////////////////////////////

    $('#fumadorSi').on('ifChecked', function () {
        $('#cigarrillosDia').prop('disabled', false)
        $('#edadFumador').prop('disabled', false)
        toastr.info("Complete los Siguientes Campos", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    })
    $('#fumadorNo').on('ifChecked', function () {
        $('#cigarrillosDia').prop('disabled', true)
        $('#edadFumador').prop('disabled', true)
    })

    $('#alergicoNo').on('ifChecked', function () {
        $('#medicamento').prop('disabled', true)
        $('#sustancia').prop('disabled', true)
        $('#alimento').prop('disabled', true)
    });
    $('#alergicoSi').on('ifChecked', function () {
        $('#medicamento').prop('disabled', false)
        $('#sustancia').prop('disabled', false)
        $('#alimento').prop('disabled', false)
        toastr.info("Complete los Siguientes Campos", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    });

    $('#padecidoSi').on('ifChecked', function () {
        $('#varicela').prop('disabled', false)
        $('#rubeola').prop('disabled', false)
        $('#sarempeon').prop('disabled', false)
        $('#escarlatina').prop('disabled', false)
        $('#exantema').prop('disabled', false)
        $('#manos').prop('disabled', false)
        toastr.info("Complete los Siguientes Campos", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    });
    $('#padecidoNo').on('ifChecked', function () {
        $('#varicela').prop('disabled', true)
        $('#rubeola').prop('disabled', true)
        $('#sarempeon').prop('disabled', true)
        $('#escarlatina').prop('disabled', true)
        $('#exantema').prop('disabled', true)
        $('#manos').prop('disabled', true)
    });

    $('#intervencionSi').on('ifChecked', function () {
        $('#intervencion').prop('disabled', false)
        toastr.info("Complete los Siguientes Campos", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    });
    $('#intervencionNo').on('ifChecked', function () {
        $('#intervencion').prop('disabled', true)
    });

    $('#lesionSi').on('ifChecked', function () {
        $('#huesos').prop('disabled', false)
        $('#ligamentos').prop('disabled', false)
        $('#articulaciones').prop('disabled', false)
        toastr.info("Complete los Siguientes Campos", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    });
    $('#lesionNo').on('ifChecked', function () {
        $('#huesos').prop('disabled', true)
        $('#ligamentos').prop('disabled', true)
        $('#articulaciones').prop('disabled', true)
    });

    $('#hopitalizadoSi').on('ifChecked', function () {
        $('#causa').prop('disabled', false)
        toastr.info("Complete los Siguientes Campos", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    });
    $('#hospitalizadoNo').on('ifChecked', function () {
        $('#causa').prop('disabled', true)
    });

    $('#deporteSi').on('ifChecked', function () {
        $('#tipo').prop('disabled', false)
        $('#frecuencia').prop('disabled', false)
        toastr.info("Complete los Siguientes Campos", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    });
    $('#deporteNo').on('ifChecked', function () {
        $('#tipo').prop('disabled', true)
        $('#frecuencia').prop('disabled', true)
    });

    $('#padeceSi').on('ifChecked', function () {
        $('#enfermedades').prop('disabled', false)
        toastr.info("Complete los Siguientes Campos", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    });
    $('#padeceNo').on('ifChecked', function () {
        $('#enfermedades').prop('disabled', true)
    });

    $('#tratamientoSi').on('ifChecked', function () {
        $('#tratamiento').prop('disabled', false)
        $('#dosis').prop('disabled', false)
        toastr.info("Complete los Siguientes Campos", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    });
    $('#tratamientoNo').on('ifChecked', function () {
        $('#tratamiento').prop('disabled', true)
        $('#dosis').prop('disabled', true)
    });
});