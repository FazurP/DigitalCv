using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class EncuestaSaludBusiness : IEncuestaSaludBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EncuestaSaludRepository encuestaSaludRepository;
        private readonly OpcionesRespuesta04Repository opcionesRespuesta04Repository;
        private readonly RhRepository rhRepository;
        private readonly GrupoSanguineoRepository grupoSanguineoRepository;
        private readonly PersonalRepository personalRepository;

        public EncuestaSaludBusiness(IUnitOfWork _unitOfWork) 
        {
            unitOfWork = _unitOfWork;
            encuestaSaludRepository = new EncuestaSaludRepository(unitOfWork);
            opcionesRespuesta04Repository = new OpcionesRespuesta04Repository(unitOfWork);
            rhRepository = new RhRepository(unitOfWork);
            grupoSanguineoRepository = new GrupoSanguineoRepository(unitOfWork);
            personalRepository = new PersonalRepository(unitOfWork);
        }

        public List<OpcionesRespuesta04DomainModel> GetAllOpcionesRespuesta04 ()
        {
            List<OpcionesRespuesta04DomainModel> opcionesRespuesta04DomainModels = new List<OpcionesRespuesta04DomainModel>();

            List<CatOpcionesRespuesta04> catOpcionesRespuesta04s = new List<CatOpcionesRespuesta04>();

            catOpcionesRespuesta04s = opcionesRespuesta04Repository.GetAll().ToList();

            foreach (CatOpcionesRespuesta04 item in catOpcionesRespuesta04s)
            {
                OpcionesRespuesta04DomainModel opcionesRespuesta04DomainModel = new OpcionesRespuesta04DomainModel();

                opcionesRespuesta04DomainModel.id = item.id;
                opcionesRespuesta04DomainModel.strValor = item.strValor;

                opcionesRespuesta04DomainModels.Add(opcionesRespuesta04DomainModel);
            }

            OpcionesRespuesta04DomainModel opcionesRespuesta04DomainModel1 = new OpcionesRespuesta04DomainModel();

            opcionesRespuesta04DomainModel1.id = 0;
            opcionesRespuesta04DomainModel1.strValor = "Seleccionar";

            opcionesRespuesta04DomainModels.Insert(0, opcionesRespuesta04DomainModel1);

            return opcionesRespuesta04DomainModels;
        }

        public List<RhDomainModel> GetAllRhs() 
        {
            List<RhDomainModel> rhDomainModels = new List<RhDomainModel>();
            List<CatRH> catRHs = new List<CatRH>();

            catRHs = rhRepository.GetAll().ToList();

            foreach (CatRH item in catRHs)
            {
                RhDomainModel rhDomainModel = new RhDomainModel();

                rhDomainModel.id = item.id;
                rhDomainModel.strValor = item.strValor;

                rhDomainModels.Add(rhDomainModel);
            }

            RhDomainModel rhDomainModel1 = new RhDomainModel();

            rhDomainModel1.id = 0;
            rhDomainModel1.strValor = "Seleccionar";

            rhDomainModels.Insert(0, rhDomainModel1);

            return rhDomainModels;
        }
        public List<GrupoSanguineoDomainModel> GetAllGruposSanguineos() 
        {
            List<GrupoSanguineoDomainModel> grupoSanguineoDomainModels = new List<GrupoSanguineoDomainModel>();

            List<CatGrupoSanguineo> catGrupoSanguineos = new List<CatGrupoSanguineo>();

            catGrupoSanguineos = grupoSanguineoRepository.GetAll().ToList();

            foreach (CatGrupoSanguineo item in catGrupoSanguineos)
            {
                GrupoSanguineoDomainModel grupoSanguineoDomainModel = new GrupoSanguineoDomainModel();

                grupoSanguineoDomainModel.id = item.id;
                grupoSanguineoDomainModel.strValor = item.strValor;

                grupoSanguineoDomainModels.Add(grupoSanguineoDomainModel);
            }

            GrupoSanguineoDomainModel grupoSanguineoDomainModel1 = new GrupoSanguineoDomainModel();

            grupoSanguineoDomainModel1.id = 0;
            grupoSanguineoDomainModel1.strValor = "Seleccionar";

            grupoSanguineoDomainModels.Insert(0, grupoSanguineoDomainModel1);

            return grupoSanguineoDomainModels;
        }

        public bool AddEncuesta(EncuestaDomainModel encuestaDomainModel) 
        {
            bool respuesta = false;

            try
            {
                TblEncuesta tblEncuesta = new TblEncuesta();
                tblPersonal tblPersonal = new tblPersonal();

                tblPersonal = personalRepository.GetAll().FirstOrDefault(p => p.idPersonal == encuestaDomainModel.idPersonal);

                if (tblPersonal.idEncuesta == null)
                {
                    tblEncuesta.CatRespuestas01 = new CatRespuestas01
                    {
                        strComidasDia = encuestaDomainModel.Respuestas01.strComidasDias
                    };
                    tblEncuesta.CatRespuestas02 = new CatRespuestas02
                    {
                        strHorasDuermeDia = encuestaDomainModel.Respuestas02.strHorasDuermeDia
                    };
                    tblEncuesta.CatRespuestas03 = new CatRespuestas03
                    {
                        bitFumador = encuestaDomainModel.Respuestas03.bitFumador,
                        CatFumador = new CatFumador
                        {
                            strCigarrillosDia = encuestaDomainModel.Respuestas03.Fumador.strCigarrillosDia,
                            strEdadComienzo = encuestaDomainModel.Respuestas03.Fumador.strEdadComienzo
                        }
                    };
                    tblEncuesta.CatRespuestas04 = new CatRespuestas04
                    {
                        idOpcion = encuestaDomainModel.Respuestas04.idOpcion
                    };
                    tblEncuesta.CatRespuestas05 = new CatRespuestas05
                    {
                        idGrupoSanguineo = encuestaDomainModel.Respuestas05.idGrupoSanguineo,
                        idRh = encuestaDomainModel.Respuestas05.idRh
                    };
                    tblEncuesta.CatRespuestas06 = new CatRespuestas06
                    {
                        bitAlergico = encuestaDomainModel.Respuestas06.bitAlergico,
                        CatAlergiaAlimento = new CatAlergiaAlimento
                        {
                            strAlimento = encuestaDomainModel.Respuestas06.AlergiaAlimento.strAlimento
                        },
                        CatAlergiaMedicamento = new CatAlergiaMedicamento
                        {
                            strMedicamento = encuestaDomainModel.Respuestas06.AlergiaMedicamento.strMedicamento
                        },
                        CatAlergiaSustancia = new CatAlergiaSustancia
                        {
                            strSustancia = encuestaDomainModel.Respuestas06.AlergiaSustancia.strSustancia
                        }
                    };
                    tblEncuesta.CatRespuestas07 = new CatRespuestas07
                    {
                        bitPadecido = encuestaDomainModel.Respuestas07.bitPadecido,
                        CatEnfermedadesExantemática = new CatEnfermedadesExantemática
                        {
                            Enfermedad_de_Manos__Pies__Boca = encuestaDomainModel.Respuestas07.EnfermedadesExantematica.EnfermedadManoPieBoca,
                            Escarlatina = encuestaDomainModel.Respuestas07.EnfermedadesExantematica.Escarlatina,
                            Exantema_Súbito = encuestaDomainModel.Respuestas07.EnfermedadesExantematica.ExantemaSubito,
                            Rubeola = encuestaDomainModel.Respuestas07.EnfermedadesExantematica.Rubeola,
                            Sarampión = encuestaDomainModel.Respuestas07.EnfermedadesExantematica.Sarampion,
                            Varicela = encuestaDomainModel.Respuestas07.EnfermedadesExantematica.Varicela
                        }
                    };
                    tblEncuesta.CatRespuestas08 = new CatRespuestas08
                    {
                        bitIntervencion = encuestaDomainModel.Respuestas08.bitIntervencion,
                        strIntervencion = encuestaDomainModel.Respuestas08.strIntervencion
                    };
                    tblEncuesta.CatRespuestas09 = new CatRespuestas09
                    {
                        bitLesion = encuestaDomainModel.Respuestas09.bitLesion,
                        CatLesionArticulaciones = new CatLesionArticulaciones
                        {
                            strLesion = encuestaDomainModel.Respuestas09.LesionArticulaciones.strLesion
                        },
                        CatLesionHuesos = new CatLesionHuesos
                        {
                            strLesion = encuestaDomainModel.Respuestas09.LesionHuesos.strLesion
                        },
                        CatLesionLigamentos = new CatLesionLigamentos
                        {
                            strLesion = encuestaDomainModel.Respuestas09.LesionLigamentos.strLesion
                        }
                    };
                    tblEncuesta.CatRespuestas10 = new CatRespuestas10
                    {
                        bitHospitalizado = encuestaDomainModel.Respuestas10.bitHospitalizado,
                        strCausa = encuestaDomainModel.Respuestas10.strCausa
                    };
                    tblEncuesta.CatRespuestas11 = new CatRespuestas11
                    {
                        bitRealizaActividadFisica = encuestaDomainModel.Respuestas11.bitRealizaActividadFisica,
                        CatActividadesFisicas = new CatActividadesFisicas
                        {
                            strTipo = encuestaDomainModel.Respuestas11.ActividadesFisicas.strTipo,
                            strFrecuencia = encuestaDomainModel.Respuestas11.ActividadesFisicas.strFrecuencia
                        }
                    };
                    tblEncuesta.CatRespuestas12 = new CatRespuestas12
                    {
                        bitPadece = encuestaDomainModel.Respuestas12.bitPadece,
                        CatEnfermades = new CatEnfermades
                        {
                            strEnfermedad = encuestaDomainModel.Respuestas12.Enfermedades.strEnfermedad
                        }

                    };
                    tblEncuesta.CatRespuestas13 = new CatRespuestas13
                    {
                        bitTratamiento = encuestaDomainModel.Respuestas13.bitTratamiento,
                        CatTratamiento = new CatTratamiento
                        {
                            strDosis = encuestaDomainModel.Respuestas13.Tratamiento.strDosis,
                            strTratamiento = encuestaDomainModel.Respuestas13.Tratamiento.strTratamiento
                        }
                    };
                    tblEncuesta.CatRespuestas14 = new CatRespuestas14
                    {
                        strUltimoPapanicolaou = encuestaDomainModel.Respuestas14.strUltimoPapanicolau
                    };
                    tblEncuesta.CatRespuestas15 = new CatRespuestas15
                    {
                        strFrecuenciaExploracionMamaria = encuestaDomainModel.Respuestas15.strFrecuenciaExploracionMamaria
                    };
                    tblEncuesta.CatRespuestas16 = new CatRespuestas16
                    {
                        strNumeroEnbarazos = encuestaDomainModel.Respuestas16.strNumeroEmbarazos
                    };
                    tblEncuesta.CatRespuestas17 = new CatRespuestas17
                    {
                        strUltimoPruebaAntigenoProstatico = encuestaDomainModel.Respuestas17.strUltimoPruebaAntigenoProstatico
                    };

                    encuestaSaludRepository.Insert(tblEncuesta);

                    tblPersonal.idEncuesta = tblEncuesta.id;

                    personalRepository.Update(tblPersonal);

                    respuesta = true;
                }

              

            }
            catch (Exception ex)
            {
                respuesta = false;
                string e = ex.Message;
            }

            return respuesta;
        }
    }
}
