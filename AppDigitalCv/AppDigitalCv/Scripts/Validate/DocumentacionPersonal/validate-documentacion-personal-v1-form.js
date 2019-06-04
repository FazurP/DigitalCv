$(document).ready(function () {

    $('#btnSubmit').prop('disabled', true);

    $('#txtVigenciaLicenciaManejo').prop('disabled', true);
    $('#txtVigenciaPasaporte').prop('disabled', true);
    $('#txtVigenciaVisaUsa').prop('disabled', true);
    $('#txtVigenciaVisaCanada').prop('disabled', true);
    $('#txtVigenciaSeguridadSocial').prop('disabled', true);
    $('#txtVigenciaProfEstatal').prop('disabled', true);
    $('#DocumentoFile').prop('disabled', true);
    $('#inputUploadPasaporte').prop('disabled', true);
    $('#inputUploadVisaUsa').prop('disabled', true);
    $('#inputUploadVisaCanada').prop('disabled', true);
    $('#inputUploadSeguridadSocial').prop('disabled', true);
    $('#inputUploadProfEstatal').prop('disabled', true);
    $('#inputUploadCartillaMilitar').prop('disabled', true);

    //Evento en cascada anidada para licencia
    $('#txtNoLicenciaManejo').keyup(function () {

        var numero = $('#txtNoLicenciaManejo').val();

        if (numero == null || numero == "" || numero == '') {
            $('#txtVigenciaLicenciaManejo').prop('disabled', true);
            $('#DocumentoFile').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#txtVigenciaLicenciaManejo').val('');
            $('#DocumentoFile').val('');
        } else {
            $('#txtVigenciaLicenciaManejo').prop('disabled', false);

            //Evento Anidado para su vigencia correspondiente
            $('#txtVigenciaLicenciaManejo').change(function () {

                var vigencia = $('#txtVigenciaLicenciaManejo').val();

                if (vigencia == null || vigencia == "" || vigencia == '') {
                    $('#DocumentoFile').prop('disabled', true);
                    $('#btnSubmit').prop('disabled', true);

                    $('#DocumentoFile').val('');
                } else {
                    $('#DocumentoFile').prop('disabled', false);
                    //Evento Anidado para su documento correspondiente
                    $('#DocumentoFile').change(function () {

                        var documento = $('#DocumentoFile').val();

                        if (documento == null || documento == "" || documento == '') {
                            $('#btnSubmit').prop('disabled', true);
                        } else {
                            $('#btnSubmit').prop('disabled', false);
                        }

                    })
                }
            })

        }

    })
    //Evento en cascada anidada para pasaporte
    $('#txtNoPasaporte').keyup(function () {

        var numero = $('#txtNoPasaporte').val();

        if (numero == null || numero == "" || numero == '') {
            $('#txtVigenciaPasaporte').prop('disabled', true);
            $('#inputUploadPasaporte').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#txtVigenciaPasaporte').val('');
            $('#inputUploadPasaporte').val('');
        } else {
            $('#txtVigenciaPasaporte').prop('disabled', false);

            //Evento anidado para su pasaporte correspondiente
            $('#txtVigenciaPasaporte').change(function () {

                var vigencia = $('#txtVigenciaPasaporte').val();

                if (vigencia == null || vigencia == "" || vigencia == '') {
                    $('#inputUploadPasaporte').prop('disabled', true);
                    $('#btnSubmit').prop('disabled', true);

                    $('#inputUploadPasaporte').val('');
                } else {
                    $('#inputUploadPasaporte').prop('disabled', false);

                    //Evento anidado para su documento correspondiente
                    $('#inputUploadPasaporte').change(function () {

                        var documento = $('#inputUploadPasaporte').val();

                        if (documento == null || documento == "" || documento == '') {
                            $('#btnSubmit').prop('disabled', true);
                        } else {
                            $('#btnSubmit').prop('disabled', false);
                        }

                    })
                }

            })
        }

    })
    //Evento en cascada anidada para visa USA
    $('#txtNumeroVisaUsa').keyup(function () {

        var numero = $('#txtNumeroVisaUsa').val();

        if (numero == null || numero == "" || numero == '') {
            $('#txtVigenciaVisaUsa').prop('disabled', true);
            $('#inputUploadVisaUsa').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#txtVigenciaVisaUsa').val('');
            $('#inputUploadVisaUsa').val('');
        } else {
            $('#txtVigenciaVisaUsa').prop('disabled', false);

            //Evento anidado para su vigencia correspondiente
            $('#txtVigenciaVisaUsa').change(function () {

                var vigencia = $('#txtVigenciaVisaUsa').val();

                if (vigencia == null || vigencia == "" || vigencia == '') {
                    $('#inputUploadVisaUsa').prop('disabled', true);
                    $('#btnSubmit').prop('disabled', true);

                    $('#inputUploadVisaUsa').val('');
                } else {
                    $('#inputUploadVisaUsa').prop('disabled', false);

                    //Evento anidado para su documento correspondiente
                    $('#inputUploadVisaUsa').change(function () {

                        var documento = $('#inputUploadVisaUsa').val();

                        if (documento == null || documento == "" || documento == '') {
                            $('#btnSubmit').prop('disabled', true);
                        } else {
                            $('#btnSubmit').prop('disabled', false);
                        }

                    })
                }

            })
        }

    })
    //Evento en cascada anidada para visa Canada
    $('#txtNumeroVisaCanada').keyup(function () {

        var numero = $('#txtNumeroVisaCanada').val();

        if (numero == null || numero == "" || numero == '') {
            $('#txtVigenciaVisaCanada').prop('disabled', true);
            $('#inputUploadVisaCanada').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#txtVigenciaVisaCanada').val('');
            $('#inputUploadVisaCanada').val('');
        } else {
            $('#txtVigenciaVisaCanada').prop('disabled', false);

            //Evento anidado para su vigencia correspondiente
            $('#txtVigenciaVisaCanada').change(function () {

                var vigencia = $('#txtVigenciaVisaCanada').val();

                if (vigencia == null || vigencia == "" || vigencia == '') {
                    $('#inputUploadVisaCanada').prop('disabled', true);
                    $('#btnSubmit').prop('disabled', true);

                    $('#inputUploadVisaCanada').val('');
                } else {
                    $('#inputUploadVisaCanada').prop('disabled', false);

                    //Evento anidado para su documento correspondiente}
                    $('#inputUploadVisaCanada').change(function () {

                        var documento = $('#inputUploadVisaCanada').val();

                        if (documento == null || documento == "" || documento == '') {
                            $('#btnSubmit').prop('disabled', true);
                        } else {
                            $('#btnSubmit').prop('disabled', false);
                        }
                    })
                }

            })
        }

    })
    //Evento en cascada anidada para seguridad social
    $('#txtNumeroSeguridadSocial').keyup(function () {

        var numero = $('#txtNumeroSeguridadSocial').val();

        if (numero == null || numero == "" || numero == '') {
            $('#txtVigenciaSeguridadSocial').prop('disabled', true);
            $('#inputUploadSeguridadSocial').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#txtVigenciaSeguridadSocial').val('');
            $('#inputUploadSeguridadSocial').val('');
        } else {
            $('#txtVigenciaSeguridadSocial').prop('disabled', false);

            //Evento anidado para su vigencia correspondiente
            $('#txtVigenciaSeguridadSocial').change(function () {

                var vigencia = $('#txtVigenciaSeguridadSocial').val();

                if (vigencia == null || vigencia == "" || vigencia == '') {
                    $('#inputUploadSeguridadSocial').prop('disabled', true);
                    $('#btnSubmit').prop('disabled', true);

                    ('#inputUploadSeguridadSocial').val('');
                } else {
                    $('#inputUploadSeguridadSocial').prop('disabled', false);

                    //Evento anidado para su documento correspondinte
                    $('#inputUploadSeguridadSocial').change(function () {

                        var documento = $('#inputUploadSeguridadSocial').val();

                        if (documento == null || documento == "" || documento == '') {
                            $('#btnSubmit').prop('disabled', true);
                        } else {
                            $('#btnSubmit').prop('disabled', false);
                        }

                    })
                }
            })
        }

    })
    //Evento en cascada anidada para registro estatal
    $('#txtRegistroEstatal').keyup(function () {

        var numero = $('#txtRegistroEstatal').val();

        if (numero == null || numero == "" || numero == '') {
            $('#txtVigenciaProfEstatal').prop('disabled', true);
            $('#inputUploadProfEstatal').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#txtVigenciaProfEstatal').val('');
            $('#inputUploadProfEstatal').val('');
        } else {
            $('#txtVigenciaProfEstatal').prop('disabled', false);

            //Evento anidado para su vigencia correespondiente
            $('#txtVigenciaProfEstatal').change(function () {

                var vigencia = $('#txtVigenciaProfEstatal').val();

                if (vigencia == null || vigencia == "" || vigencia == '') {
                    $('#inputUploadProfEstatal').prop('disabled', true);
                    $('#btnSubmit').prop('disabled', true);

                    $('#inputUploadProfEstatal').val('');
                } else {
                    $('#inputUploadProfEstatal').prop('disabled', false);

                    //Evento anidado para su documento correspondite
                    $('#inputUploadProfEstatal').change(function () {

                        var documento = $('#inputUploadProfEstatal').val();

                        if (documento == null || documento == "" || documento == '') {
                            $('#btnSubmit').prop('disabled', true);
                        } else {
                            $('#btnSubmit').prop('disabled', true);
                        }

                    })
                }

            })
        }

    })
    //Evento en cascada anidada para cartilla militar
    $('#txtNumeroCartillaMilitar').keyup(function () {

        var numero = $('#txtNumeroCartillaMilitar').val();

        if (numero == null || numero == "" || numero == '') {
            $('#inputUploadCartillaMilitar').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#inputUploadCartillaMilitar').val('');
        } else {
            $('#inputUploadCartillaMilitar').prop('disabled', false);

            //Evento anidado para su documento correspondiente
            $('#inputUploadCartillaMilitar').change(function () {

                var documento = $('#inputUploadCartillaMilitar').val();

                if (documento == null || documento == "" || documento == '') {
                    $('#btnSubmit').prop('disabled', true);
                } else {
                    $('#btnSubmit').prop('disabled', false);
                }

            })
        }

    })

    //FIN DE LOS EVENTOS EN CASCADA ANIDADOS

    $('#inputUploadIfe').change(function () {

        var documento = $('#inputUploadIfe').val();

        if (documento == null || documento == "" || documento == '') {
            $('#btnSubmit').prop('disabled', true);
        } else {
            $('#btnSubmit').prop('disabled', false);
        }

    })
    $('#inputUploadComprobanteDomicilio').change(function () {

        var documento = $('#inputUploadComprobanteDomicilio').val();

        if (documento == null || documento == "" || documento == '') {
            $('#btnSubmit').prop('disabled', true);
        } else {
            $('#btnSubmit').prop('disabled', false);
        }
    })
    $('#inputUploadSolicitudEmpleo').change(function () {

        var documento = $('#inputUploadSolicitudEmpleo').val();

        if (documento == null || documento == "" || documento == '') {
            $('#btnSubmit').prop('disabled', true);
        } else {
            $('#btnSubmit').prop('disabled', false);
        }

    })
})