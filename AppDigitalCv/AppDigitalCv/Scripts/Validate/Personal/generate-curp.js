$(document).ready(function ()
{

    let curp = "";
    let ok = 0;
    let fVocal = "";
    let aPaterno = [20];
    let i = 0;

    $('#Paterno').keyup(function ()
    {
        if ($(this).val().length < 2) {
            curp = curp + $(this).val().substr(0, 1);
        }
        aPaterno[i] = $(this).val().substr(i, 1);
        i++;
        debugger;
        if (aPaterno[(i - 1)] == 'a' || aPaterno[(i - 1)] == 'e' || aPaterno[(i - 1)] == 'i' || aPaterno[(i - 1)] == 'o' || aPaterno[(i - 1)] == 'u' && ok == 0) {
            if (i > 1) {
                curp = curp + aPaterno[i];
                ok = 1;
            }
          
        }
    });

});