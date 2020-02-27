$(document).ready(function () {

    $('#Enviar').click(function ()
    {
        let campos = [];

        let option = $('#NivelEstudio').get(0).selectedIndex;
        switch (option) {
            case 1:

                campos[0] = $('#NombreEstudioDoctorado').val();
                campos[1] = $('#Institucion').val();
                campos[2] = $('#Status').val();
                campos[3] = $('#FuenteFinanciamiento').val();
                campos[4] = $('input:radio[name=bitReconocimientePNPC]:checked').val();
                campos[5] = $('#Documento').val();
                
                if ($('#dteFechaInicio').get(0).style.display == "block") {
                    campos[6] = $('#dteFechaInicio').val();
                }
               
                for (let i = 0; i < campos.length; i++) {
                    if ($.isEmptyObject(campos[i]) || campos[i] == 0 ) {
                        toastr.warning('No Puedes Dejar Campos Vacios', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                        return false;
                    }
                }

                break;
            case 2:

                campos[0] = $('#NombreEstudioDoctorado').val();
                campos[1] = $('#Institucion').val();
                campos[2] = $('#Status').val();
                campos[3] = $('#FuenteFinanciamiento').val();
                campos[4] = $('input:radio[name=bitReconocimientePNPC]:checked').val();
                campos[5] = $('#Documento').val();

                if ($('#dteFechaInicio').get(0).style.display == "block") {
                    campos[6] = $('#dteFechaInicio').val();
                }

                for (let i = 0; i < campos.length; i++) {
                    if ($.isEmptyObject(campos[i]) || campos[i] == 0) {
                        toastr.warning('No Puedes Dejar Campos Vacios', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                        return false;
                    }
                }

                break;
            case 3:

                campos[0] = $('#NombreEstudioDoctorado').val();
                campos[1] = $('#Institucion').val();
                campos[2] = $('#Status').val();
                campos[3] = $('#Documento').val();

                for (let i = 0; i < campos.length; i++) {
                    if ($.isEmptyObject(campos[i]) || campos[i] == 0) {
                        toastr.warning('No Puedes Dejar Campos Vacios', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                        return false;
                    }
                }

                break;
            case 4:

                campos[0] = $('#NombreEstudioDoctorado').val();
                campos[1] = $('#Institucion').val();
                campos[2] = $('#Status').val();
                campos[3] = $('#Documento').val();

                for (let i = 0; i < campos.length; i++) {
                    if ($.isEmptyObject(campos[i]) || campos[i] == 0) {
                        toastr.warning('No Puedes Dejar Campos Vacios', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                        return false;
                    }
                }


                break;
            case 5:

                campos[0] = $('#NombreEstudioDoctorado').val();
                campos[1] = $('#Documento').val();

                for (let i = 0; i < campos.length; i++) {
                    if ($.isEmptyObject(campos[i]) || campos[i] == 0) {
                        toastr.warning('No Puedes Dejar Campos Vacios', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                        return false;
                    }
                }

                break;
            default:
                toastr.warning('Selecciona un Nivel Academico', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                return false;
                break;
        }
        
    });

});