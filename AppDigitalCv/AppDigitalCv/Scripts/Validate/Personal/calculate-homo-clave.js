$(document).ready(function () {
    var size;
    var letter;
    var homo="";
    var word="";

    $('#Rfc').on('keyup', function () {

        letter = $('#Rfc').val();

        var mayus = letter.toUpperCase();
        $('#Rfc').val(mayus);

        size = size + letter;

        if ($('#Rfc').val().length == 13) {
            homo = size.substr(size.length - 3, size.length + 3);
            word = homo.toUpperCase();
            $('#Homoclave').val(word);
            $('#Semblanza').attr('disabled', false);

        } else if ($('#Rfc').val().length < 13) {
            $('#Homoclave').val("");
            $('#Semblanza').attr('disabled', true);

        } else if ($('#Rfc').val().length == 14) {
            homo = size.substr(size.length - 3, size.length + 3);
            word = homo.toUpperCase();
            $('#Homoclave').val(word);
            $('#Semblanza').attr('disabled', false);
        }

    })
});