


using CRUDImoestudante.App_Db_Model;
/**
* Names : Antonio Gonçalves & Nelson Peixoto
* Email: A10851@alunos.ipca.pt & A11271@alunos.ipca.pt
* Date : 20-12-2016
* RESTFULL Web Service 2º Trabalho Prático
* Versao : 1.0
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUDImoestudante
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        #region UTILIZADOR


        List<ContactoRespostaPedido> ConvertContactDbToContactClient( List<contacto> contactos)
        {
            List<ContactoRespostaPedido> r = new List<ContactoRespostaPedido>();

            foreach (contacto dContact in contactos)

                r.Add(new ContactoRespostaPedido
                {
                    IdContacto = dContact.idContacto,
                    Nivel = dContact.nivel,
                    Tipo = dContact.tipo,
                    Valor = dContact.valor

                });

            return r;
        }


        List<contacto> ConvertContactClientToContactDb(List<ContactoRespostaPedido> contactos, int idClient)
        {
            List<contacto> r = new List<contacto>();

            foreach (ContactoRespostaPedido dContact in contactos)

                r.Add(new contacto
                {
                    idContacto = dContact.IdContacto,
                    nivel = dContact.Nivel,
                    tipo = dContact.Tipo,
                    valor = dContact.Valor,
                    idUser = idClient
                                       

                });

            return r;
        }


        bool AddMorada(MoradaRespostaPedido mUser, string Pais, out int idMorada)
        {
            idMorada = -1;

            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {
                    // id
                    morada dBMorada = new morada();
                    dBMorada.idMorada = db.moradas.Max(X => X.idMorada) + 1;
                    idMorada = dBMorada.idMorada;
                    // dados da morada
                    dBMorada.idPais = db.pais.Where(x=> x.nomePais == Pais).Single().idPais;
                    dBMorada.cidade = mUser.Cidade;
                    dBMorada.rua = mUser.Rua;
                    dBMorada.codigoPostal = mUser.CodPostal;
                    dBMorada.numero = mUser.Numero;
                    dBMorada.andar = mUser.Andar;
                    dBMorada.descAndar = mUser.DescAndar;
                    // guardar a morada
                    db.moradas.Add(dBMorada);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        public List<ContactoRespostaPedido> GetContactsData(int userId)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                return ConvertContactDbToContactClient(db.contactoes.Where(x => x.idUser == userId).ToList());
            }
        }





        /// <summary>
        /// Função que pequisa uma morada por ID e a converte para o tipo de MoradaRespostaPedido
        /// </summary>
        /// <param name="idUserMorada"></param>
        /// <returns>MoradaRespostaPedido</returns>
        public MoradaRespostaPedido ConvertMoradaDBToMoradaRPData(int idUserMorada)
        {
            MoradaRespostaPedido r = new MoradaRespostaPedido();
            morada aux = new morada();

            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                aux = db.moradas.Single(x => x.idMorada == idUserMorada);
                r.IdMorada = aux.idMorada;
                r.Rua = string.Copy(aux.rua);
                r.Numero = aux.numero.GetValueOrDefault();
                r.Andar = aux.andar.GetValueOrDefault();
                r.DescAndar = string.Copy(aux.descAndar); // esq, dto, frente , tras

                r.Pais = string.Copy(db.pais.Single(x => x.idPais == aux.idPais).nomePais);

                r.CodPostal = aux.codigoPostal;
                r.Cidade = string.Copy(aux.cidade);

                return r;
            }

        }





        /// <summary>
        /// Função retorna a lista de utilizadores no formato de "saida". Esta lista é para apresentação de tabela de users.
        /// </summary>
        /// <param></param>
        /// <returns>r</returns>
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUsersData")]
        public List<MultiUtilizadorRespostaPedido> GetUsersData()
        {
            List<MultiUtilizadorRespostaPedido> r = new List<MultiUtilizadorRespostaPedido>();

            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                foreach (user dUser in db.users)
                    r.Add(new MultiUtilizadorRespostaPedido
                    {
                        IdUser = dUser.idUser,
                        Nome = dUser.nome,
                        DataNascimento = dUser.dataNascimento.Value,
                        Gen = dUser.genero.ToString(),
                        //MoradaUtilizador = ConvertMoradaDBToMoradaRPData(dUser.idMorada),
                        PaisOrigen = db.pais.Single(x => x.idPais == dUser.idPais).nomePais,
                        CursoUtilizador = db.cursoes.Single(x => x.idCurso == dUser.idCurso).nomeCurso,
                        UserName = dUser.login,
                        TipoUtilizador = db.tipoUsers.Single(x => x.idTipo == dUser.idTipo).nomeTipo,
                        //Contactos = GetContactsData(dUser.idUser)
                    });

                return r;

            }

        }



        bool SearchUser(int userid)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                if (db.users.Where(x => x.idUser == userid).Count() > 0)
                    return true;
                else return false;
            }
        }


        /// <summary>
        /// Função que retorna um utilizador por ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/SearchUserId/{id}")]
        public UtilizadorRespostaPedido SearchUserId(string idUser)
        {
            UtilizadorRespostaPedido r = new UtilizadorRespostaPedido();
            user dUser = new user();
            int userId = 0;
            int.TryParse(idUser,out userId);
            if (SearchUser(userId))
           {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
                {
                    dUser = db.users.Where(x => x.idUser == userId).First();

                    r.IdUser = dUser.idUser;
                    r.Nome = dUser.nome;
                    r.DataNascimento = dUser.dataNascimento.Value;
                    r.Gen = dUser.genero.ToString();
                    r.MoradaUtilizador = ConvertMoradaDBToMoradaRPData(dUser.idMorada);
                    r.PaisOrigen = db.pais.Single(x => x.idPais == dUser.idPais).nomePais;
                    r.CursoUtilizador = db.cursoes.Single(x => x.idCurso == dUser.idCurso).nomeCurso;
                    r.UserName = dUser.login;
                    r.TipoUtilizador = db.tipoUsers.Single(x => x.idTipo == dUser.idTipo).nomeTipo;
                    r.Contactos = GetContactsData(dUser.idUser);

                }
            }

            return r;
        }



        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddUser")]
        public bool AddUser(UtilizadorRespostaPedido utilizador)
        {
            int idMorada = 0;

            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {
                    user dBuser = new user();
                    dBuser.idUser = db.users.Max(X => X.idUser)+1;
                    dBuser.nome = utilizador.Nome;
                    dBuser.dataNascimento = utilizador.DataNascimento;
                    dBuser.login = utilizador.UserName;

                    if (AddMorada(utilizador.MoradaUtilizador, utilizador.MoradaUtilizador.Pais, out idMorada)) dBuser.idMorada = idMorada;
                    else return false;

                    db.users.Add(dBuser);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }



        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUserType")]
        public List<TipoUserRespostaPedido> GetUserType()
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                return db.tipoUsers.Select(tip => new TipoUserRespostaPedido
                {
                    Id = tip.idTipo,
                    Tipo = tip.nomeTipo
                }).ToList();
            }
        }


        #endregion  end

        #region PAISES


        bool ExistePais(PaisRespostaPedido pais)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {
                    if (db.pais.Where(x => x.nomePais == pais.Name).Count() > 0)
                        return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
        }




        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/UpDatePais")]
        public bool UpDatePais(List<PaisRespostaPedido> paises)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {

                    foreach (PaisRespostaPedido pais in paises)
                    {
                        if (!ExistePais(pais))
                        {
                            List<pai> p = db.pais.ToList();
                            int i = p.Count;
                            pai dBpais = new pai();
                            dBpais.idPais = i++;
                            dBpais.nomePais = pais.Name;
                            dBpais.code = pais.Code;

                            db.pais.Add(dBpais);
                            db.SaveChanges();
                        }

                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }



        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetPaises")]
        public List<PaisRespostaPedido> GetPaises()
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                List<PaisRespostaPedido> r = new List<PaisRespostaPedido>();

                foreach (pai dpais in db.pais)
                    r.Add(new PaisRespostaPedido
                    {
                        Name = dpais.nomePais.TrimEnd(),
                        Code = dpais.code.TrimEnd()
                    });

                return r;


            }
        }


        #endregion end


        #region CONTRACTO

      
        [WebInvoke(Method = "GET", UriTemplate = "/GetContractData", ResponseFormat = WebMessageFormat.Json)]
        public List<aluguer> GetContractData()
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                List<aluguer> r = new List<aluguer>();

                foreach (aluguer daluguer in db.aluguers)
                    r.Add(new aluguer
                    {
                        idAluguer = daluguer.idAluguer,
                        idAlojamento = daluguer.idAlojamento,
                        idUserAgente = daluguer.idUserAgente,
                        idUserInquilino = daluguer.idUserInquilino,
                        idUserSenhorio = daluguer.idUserSenhorio,
                        dataInicio = daluguer.dataInicio,
                        dataFim = daluguer.dataFim,
                        valoRenda = daluguer.valoRenda
                    });

                return r;


            }
        }



        bool SearchContract(int aluguerId)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                if (db.aluguers.Where(x => x.idAluguer == aluguerId).Count() > 0)
                    return true;
                else return false;
            }
        }




        [WebInvoke(Method = "GET", UriTemplate = "/SearchContractId/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public aluguer SearchContractId(string id)
        {
            aluguer r = new aluguer();

            int contId = 0;
            int.TryParse(id, out contId);
            if (SearchContract(contId))
            {
                using (ImoEstudanteEntities db = new ImoEstudanteEntities())
                {
                    r = db.aluguers.Where(x => x.idAluguer == contId).First();
                }
            }

            return r;
        }


        [WebInvoke(Method = "POST", UriTemplate = "/Addcontract", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool Addcontract(aluguer aluguerData)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {
                    List<aluguer> p = db.aluguers.ToList();
                    int i = p.Count;
                    aluguer dbAluguer = new aluguer();
                    dbAluguer.idAluguer = i++;
                    dbAluguer.idAlojamento = aluguerData.idAlojamento;
                    dbAluguer.idUserAgente = aluguerData.idUserAgente;
                    dbAluguer.idUserInquilino = aluguerData.idUserInquilino;
                    dbAluguer.dataInicio = aluguerData.dataInicio;
                    dbAluguer.dataFim = aluguerData.dataFim;
                    dbAluguer.valoRenda = aluguerData.valoRenda;

                    db.aluguers.Add(dbAluguer);
                    db.SaveChanges();
                    

                     return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion  end

        #region HABITACAO


        [WebInvoke(Method = "GET", UriTemplate = "/GetHouseData", ResponseFormat = WebMessageFormat.Json)]
        public List<AlojamentoRespostaPedido> GetHouseData()
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                List<AlojamentoRespostaPedido> r = new List<AlojamentoRespostaPedido>();

                foreach (alojamento daluguer in db.alojamentoes)
                    r.Add(new AlojamentoRespostaPedido
                    {
                        /*
                                 int idAlojamento;
                                 tipologiaRespostaPedido tipol;
                                 tipoAlojamentoRespostaPedido tipoAloj;
                                 MoradaRespostaPedido moradaAlojamento;
                                 int avaliacao;
                                 IList<comodidadeRespostaPedido> comod;
                         
                         */
                    });

                return r;


            }
        }


        bool SearchHouse(int houeId)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                if (db.alojamentoes.Where(x => x.idAlojamento == houeId).Count() > 0)
                    return true;
                else return false;
            }
        }


     
        [WebInvoke(Method = "GET", UriTemplate = "/SearchHouseId/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public alojamento SearchHouseId(string id)
        {
            alojamento r = new alojamento();

            int houseId = 0;
            int.TryParse(id, out houseId);
            if (SearchContract(houseId))
            {
                using (ImoEstudanteEntities db = new ImoEstudanteEntities())
                {
                    r = db.alojamentoes.Where(x => x.idAlojamento == houseId).First();
                }
            }

            return r;
        }


        [WebInvoke(Method = "POST", UriTemplate = "/AddHouse", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool AddHouse(alojamento aluguerData)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {
                    List<alojamento> p = db.alojamentoes.ToList();
                    int i = p.Count;
                    alojamento dbAluguer = new alojamento();


                    db.alojamentoes.Add(dbAluguer);
                    db.SaveChanges();


                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion  end

        #region COMODIDADES



        /// <summary>
        /// Função que retorna a lista de comodidades defenidas na base de dados
        /// </summary>
        /// <returns></returns>
        [WebInvoke(Method = "GET", UriTemplate = "/GetComodData", ResponseFormat = WebMessageFormat.Json)]
        public List<comodidadeRespostaPedido> GetComodData()
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                List<comodidadeRespostaPedido> r = new List<comodidadeRespostaPedido>();

                foreach (comodidade daluguer in db.comodidades)
                    r.Add(new comodidadeRespostaPedido
                    {
                        IdComodidade = daluguer.idComodidade,//.ToString(),
                        DescComodidade = daluguer.nomeComodidade
                    });

                return r;


            }
        }


        /// <summary>
        /// Função que devolve uma lista de comodidades de um determinado alojamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List<comodidadeRespostaPedido></returns>
        [WebInvoke(Method = "GET", UriTemplate = "/GetComodDataAlojID/{id}", ResponseFormat = WebMessageFormat.Json)]
        public List<comodidadeRespostaPedido> GetComodDataAlojID(string id)
        {
            int alojamentoId = 0;
            int.TryParse(id, out alojamentoId);

                using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                List<comodidadeRespostaPedido> r = new List<comodidadeRespostaPedido>();

                foreach (comodidadesAlojamento daluguer in db.comodidadesAlojamentoes)
                    if (daluguer.idAlojamento == alojamentoId)
                    {
                        r.Add(new comodidadeRespostaPedido
                        {
                            IdComodidade = daluguer.idComodidade,//.ToString(),
                            DescComodidade = db.comodidades.Single(x=> x.idComodidade == daluguer.idComodidade).nomeComodidade
                        });
                    }

                return r;


            }
        }



        /// <summary>
        /// Função que remove uma determinada comodidade da base de dados
        /// </summary>
        /// <param name="comodidadeData"></param>
        /// <returns></returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "/RemoveComod", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool RemoveComod(comodidadeRespostaPedido comodidadeData)
        {
            if (comodidadeData != null)
            {
                //int comodId = 0;
                //int.TryParse(comodidadeData.IdComodidade, out comodId);
                int comodId = comodidadeData.IdComodidade;
                using (ImoEstudanteEntities db = new ImoEstudanteEntities())
                {
                    try
                    {
                        List<comodidade> p = db.comodidades.ToList();
                        comodidade dbComodidade = db.comodidades.Single(x => x.idComodidade == comodId);
                        if (dbComodidade.nomeComodidade.TrimEnd() == comodidadeData.DescComodidade)
                        {
                            db.comodidades.Remove(dbComodidade);
                            db.SaveChanges();
                            return true;
                        }

                        return false;
                    }
                    catch
                    {
                        return false;
                    }
                }
            } return false;
        }


        /// <summary>
        /// Função auxiliar que verifica se determinada comodidade existe na base de dados
        /// </summary>
        /// <param name="comod"></param>
        /// <returns>bool</returns>
        bool ExisteComodidade(comodidadeRespostaPedido comod)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {
                    if (db.comodidades.Where(x => x.nomeComodidade == comod.DescComodidade).Count() > 0)
                        return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// Função que adiciona uma Lista de comodidades, o ID é ignorado
        /// </summary>
        /// <param name="aluguerData"></param>
        /// <returns>bool</returns>
        [WebInvoke(Method = "POST", UriTemplate = "/AddComodList", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool AddComodList(List<comodidadeRespostaPedido> aluguerData)
        {
            int count = 0;
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {

                    foreach (comodidadeRespostaPedido c in aluguerData)
                    {
                        if (!ExisteComodidade(c))
                        {
                            List<comodidade> com = db.comodidades.ToList();
                            int i = com.Count;
                            count++;
                            comodidade dBcomodidade = new comodidade();
                            dBcomodidade.idComodidade = i++;
                            dBcomodidade.nomeComodidade = c.DescComodidade;

                            db.comodidades.Add(dBcomodidade);
                            db.SaveChanges();
                        }

                    }
                    if (count > 0) return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Metodo que adiciona uma comodidade, o ID é ignorado.
        /// </summary>
        /// <param name="comod"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", UriTemplate = "/AddComod", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public bool AddComod(comodidadeRespostaPedido comod)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {

                    if (!ExisteComodidade(comod))
                    {
                        List<comodidade> com = db.comodidades.ToList();
                        int i = com.Count;
                        comodidade dBcomodidade = new comodidade();
                        dBcomodidade.idComodidade = i++;
                        dBcomodidade.nomeComodidade = comod.DescComodidade;

                        db.comodidades.Add(dBcomodidade);
                        db.SaveChanges();
                        return true;
                    }

                    return false;

                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion  end



    }
}
