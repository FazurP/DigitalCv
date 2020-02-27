$(document).ready(function ()
{
    $('#Status').change(function ()
    {
        let data = $(this).val();

        if (data == 3) {

            let dataEstudio = $('#NivelEstudio').val();

            if (dataEstudio == 1 || dataEstudio == 2) {
                $('#Status').css('width', '30%').css('transition', '1s');
                $('#dteFechaInicio').css('width', '50%').css('transition', '1s').css('display', 'block');
                $('#lblDte').css('display', 'block');
            }         
        } else
        {
            $('#Status').css('width', '100%').css('transition', '2s');
            $('#dteFechaInicio').css('display', 'none');    
            $('#lblDte').css('display', 'none');
        }  

    });

    $('#NivelEstudio').change(function ()
    {

        let data = $(this).get(0).selectedIndex;
       
        if (data == 3 || data == 4) {
            $('#togglePNPC').hide();
            $('#toggleFF').hide();
            $('#strInstitucionAcredita').hide();

            $('#Status').css('width', '100%').css('transition', '2s');
            $('#dteFechaInicio').hide();
            $('#lblDte').hide();

            $('#divStatus').show();
            $('#Institucion').show();
            $('#lblAcredita').show();

        }
        else if (data == 5)
        {
            $('#togglePNPC').hide();
            $('#toggleFF').hide();
            $('#divStatus').hide();
            $('#Institucion').hide();
            $('#strInstitucionAcredita').hide();
            $('#lblAcredita').hide();
        } else if (data == 0) {
            
            $('#Status').css('width', '100%').css('transition', '2s');
            $('#dteFechaInicio').hide();
            $('#lblDte').hide();

            $('#togglePNPC').show();
            $('#toggleFF').show();
            $('#divStatus').show();
            $('#Institucion').show();
            $('#lblAcredita').show();
        }
        else
        {
            $('#togglePNPC').show();
            $('#toggleFF').show();
            $('#divStatus').show();
            $('#Institucion').show();
            $('#lblAcredita').show();
        }
    });
});