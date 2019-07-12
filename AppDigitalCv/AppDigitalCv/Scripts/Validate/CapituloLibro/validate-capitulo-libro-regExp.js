$(document).ready(function () {

    $('#Autor').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ,. ]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#Titulo').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ. ]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#Editorial').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9. ]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#Edicion').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9. ]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#Tiraje').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[0-9]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Numeros', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#ISBN').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[0-9]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Numeros', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#TituloCapitulo').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ. ]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#Autores').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ,. ]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#PaginaInicio').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[0-9]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Numeros', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#PaginaFin').keypress(function (e) {

        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[0-9]+$");

        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Numeros', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })
})