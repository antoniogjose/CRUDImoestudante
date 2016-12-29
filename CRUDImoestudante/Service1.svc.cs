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



        public List<ContactoRespostaPedido> GetContactsData(int userId)
        {
            List<ContactoRespostaPedido> r = new List<ContactoRespostaPedido>();

            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                foreach (contacto dContact in db.contactoes)
                    r.Add(new ContactoRespostaPedido
                    {
                        IdContacto = dContact.idContacto,
                        Nivel = dContact.nivel,
                        Tipo = dContact.tipo,
                        Valor = dContact.valor                         

                    });

                return r;

            }

        }

        /// <summary>
        /// Função retorna a lista de utilizadores no formato de "saida"
        /// </summary>
        /// <param></param>
        /// <returns>r</returns>
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUsersData")]
        public List<UtilizadorRespostaPedido> GetUsersData()
        {
            List<UtilizadorRespostaPedido> r = new List<UtilizadorRespostaPedido>();

            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                foreach (user dUser in db.users)
                    r.Add(new UtilizadorRespostaPedido
                    {
                        IdUser = dUser.idUser,
                        Nome = dUser.nome,
                        DataNascimento = dUser.dataNascimento.Value,
                        Gen = dUser.genero.ToString(),
                        MoradaUtilizador = ConvertMoradaDBToMoradaRPData(dUser.idMorada),
                        PaisOrigen = string.Copy(db.pais.Single(x => x.idPais == dUser.idPais).nomePais),
                        CursoUtilizador = string.Copy(db.cursoes.Single(x => x.idCurso == dUser.idCurso).nomeCurso),
                        UserName = string.Copy(dUser.login),
                        TipoUtilizador = string.Copy(db.tipoUsers.Single(x => x.idTipo == dUser.idTipo).nomeTipo),
                        Contactos = GetContactsData(dUser.idUser)
                    });

                return r;

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
          //  if (SearchUser(userId)) // desativado para reduzir o numero de acessos à BD, em analise.
          // {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
                {
                    dUser = db.users.Where(x => x.idUser == userId).First();

                    r.IdUser = dUser.idUser;
                    r.Nome = dUser.nome;
                    r.DataNascimento = dUser.dataNascimento.Value;
                    r.Gen = dUser.genero.ToString();
                    r.MoradaUtilizador = ConvertMoradaDBToMoradaRPData(dUser.idMorada);
                    r.PaisOrigen = string.Copy(db.pais.Single(x => x.idPais == dUser.idPais).nomePais);
                    r.CursoUtilizador = string.Copy(db.cursoes.Single(x => x.idCurso == dUser.idCurso).nomeCurso);
                    r.UserName = string.Copy(dUser.login);
                    r.TipoUtilizador = string.Copy(db.tipoUsers.Single(x => x.idTipo == dUser.idTipo).nomeTipo);
                    r.Contactos = GetContactsData(dUser.idUser);

                }
          //  }

            return r;
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddUser")]
        public bool AddUser(UtilizadorRespostaPedido utilizador)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {
                    user dBuser = new user();
                    dBuser.nome = utilizador.Nome;
                    dBuser.dataNascimento = utilizador.DataNascimento;
                    dBuser.login = utilizador.UserName;
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


        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/UpDatePais")]
        public bool UpDatePais(List<PaisRespostaPedido> paizes)
        {
            using (ImoEstudanteEntities db = new ImoEstudanteEntities())
            {
                try
                {
                    foreach (PaisRespostaPedido pais in paizes)
                    {
                        pai dBpais = new pai();
                        dBpais.nomePais = pais.Name;
                        dBpais.code = pais.Code;

                        db.pais.Add(dBpais);
                        db.SaveChanges();
                    }
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

        /**
                [OperationContract]

                [WebGet(UriTemplate = "/SearchUser", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                bool SearchUser(user utilizador);**/

        /**
                [OperationContract]

                [WebGet(UriTemplate = "/AddUser", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                bool AddUser(user utilizador);

                #endregion  end

                #region CONTRACTO

                [OperationContract]
                [WebGet(UriTemplate = "/GetContractData", ResponseFormat = WebMessageFormat.Json)]
                List<aluguer> GetContractData();

                [OperationContract]
                [WebGet(UriTemplate = "/SearchContract", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                List<aluguer> SearchContract(aluguer aluguerData);

                [OperationContract]
                [WebGet(UriTemplate = "/SearchContractId/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                List<aluguer> SearchContractId(string id);

                [OperationContract]
                [WebGet(UriTemplate = "/Addcontract", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                List<aluguer> Addcontract(aluguer aluguerData);

                #endregion  end

                #region HABITACAO

                [OperationContract]
                [WebGet(UriTemplate = "/GetHouseData", ResponseFormat = WebMessageFormat.Json)]
                List<alojamento> GetHouseData();

                [OperationContract]
                [WebGet(UriTemplate = "/SearchHouse", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                List<alojamento> SearchHouse(alojamento aluguerData);

                [OperationContract]
                [WebGet(UriTemplate = "/SearchHouseId/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                List<alojamento> SearchHouseId(string id);

                [OperationContract]
                [WebGet(UriTemplate = "/AddHouse", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                List<aluguer> AddHouse(aluguer aluguerData);

                #endregion  end

                #region COMODIDADES

                [OperationContract]
                [WebGet(UriTemplate = "/GetComodData", ResponseFormat = WebMessageFormat.Json)]
                List<comodidade> GetComodData();

                [OperationContract]
                [WebGet(UriTemplate = "/GetComodDataAlojID/{id}", ResponseFormat = WebMessageFormat.Json)]
                List<comodidade> GetComodDataAlojID(string id);

                [OperationContract]
                [WebGet(UriTemplate = "/RemoveComod", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                bool RemoveComod(comodidade alojamentoData);

                [OperationContract]
                [WebGet(UriTemplate = "/AddComod", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
                bool AddComod(comodidade aluguerData);
            
            **/
        #endregion  end


    }
}
