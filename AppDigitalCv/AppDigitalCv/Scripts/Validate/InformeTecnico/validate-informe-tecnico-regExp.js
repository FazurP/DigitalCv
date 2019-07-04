$(document).ready(function () {

    $('#Autor').keypress(function (e) {
        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ,. ]+$");
        if (!regExp.test(data)) {
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            e.preventDefault();
        }
    })

    $('#NombreProyecto').keypress(function (e) {
        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ. ]+$");
        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#Alcance').keypress(function (e) {
        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ. ]+$");
        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#Institucion').keypress(function (e) {
        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ. ]+$");
        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#NumeroPaginas').keypress(function (e) {
        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[0-9]+$");
        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Numeros', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#Proposito').keypress(function (e) {
        let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ. ]+$");
        if (!regExp.test(data)) {
            e.preventDefault();
            toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })
})