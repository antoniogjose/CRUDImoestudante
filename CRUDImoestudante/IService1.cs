using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUDImoestudante
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        #region UTILIZADOR

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUsersData")]
        List<UtilizadorRespostaPedido> GetUsersData();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/SearchUserId/{id}")]
        UtilizadorRespostaPedido SearchUserId(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddUser")]
        bool AddUser(UtilizadorRespostaPedido utilizador);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/UpDatePais")]
        bool UpDatePais(List<PaisRespostaPedido> paizes);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUserType")]
        List<TipoUserRespostaPedido> GetUserType();

        /** [OperationContract]

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


    [DataContract]
    public class PaisRespostaPedido
    {
        string name;
        string code;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

    }


    [DataContract]
    public class TipoUserRespostaPedido
    {
        int id;
        string tipo;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

    }


    #region DATA ALOJAMENTO

    [DataContract]
    public class tipologiaRespostaPedido
    {
        int idTipologia;
        string descTipologia;

        [DataMember]
        public int IdTipologia
        {
            get { return idTipologia; }
            set { idTipologia = value; }
        }

        [DataMember]
        public string DescTipologia
        {
            get { return descTipologia; }
            set { descTipologia = value; }
        }

    }


    [DataContract]
    public class tipoAlojamentoRespostaPedido
    {
        int idTipoAlojamento;
        string descTipoAlojamento;

        [DataMember]
        public int IdTipoAlojamento
        {
            get { return idTipoAlojamento; }
            set { idTipoAlojamento = value; }
        }

        [DataMember]
        public string DescTipoAlojamento
        {
            get { return descTipoAlojamento; }
            set { descTipoAlojamento = value; }
        }

    }

    [DataContract]
    public class comodidadeRespostaPedido
    {
        int idComodidade;
        string descComodidade;

        [DataMember]
        public int IdComodidade
        {
            get { return idComodidade; }
            set { idComodidade = value; }
        }

        [DataMember]
        public string DescComodidade
        {
            get { return descComodidade; }
            set { descComodidade = value; }
        }

    }

    [DataContract]
    public class AlojamentoRespostaPedido
    {

        int idAlojamento;
        tipologiaRespostaPedido tipol;
        tipoAlojamentoRespostaPedido tipoAloj;
        MoradaRespostaPedido moradaAlojamento;
        int avaliacao;
        IList<comodidadeRespostaPedido> comod;

        [DataMember]
        public int IdAlojamento
        {
            get { return idAlojamento; }
            set { idAlojamento = value; }
        }

        [DataMember]
        public tipologiaRespostaPedido Tipol
        {
            get { return tipol; }
            set { tipol = value; }
        }

        [DataMember]
        public tipoAlojamentoRespostaPedido TipoAloj
        {
            get { return tipoAloj; }
            set { tipoAloj = value; }
        }

        [DataMember]
        public MoradaRespostaPedido MoradaAlojamento
        {
            get { return moradaAlojamento; }
            set { moradaAlojamento = value; }
        }

        [DataMember]
        public int Avaliacao
        {
            get { return avaliacao; }
            set { avaliacao = value; }
        }

        [DataMember]
        public IList<comodidadeRespostaPedido> comodidades
        {
            get { return comod; }
            set { comod = value; }
        }

    }


    [DataContract]
    public class ListaDeAlojamentosRespostaPedido
    {
        IList<AlojamentoRespostaPedido> dadosAlojamentos;

        [DataMember]
        public IList<AlojamentoRespostaPedido> DadosAlojamentos
        {
            get { return dadosAlojamentos; }
            set { dadosAlojamentos = value; }
        }

    }

    #endregion FIM

    #region DATA UTILIZADOR

    [DataContract]
    public class MoradaRespostaPedido
    {
        int idMorada;
        string rua;
        int numero;
        int andar;
        string descAndar;
        string pais;
        string cidade;
        int codPostal;

        [DataMember]
        public int IdMorada
        {
            get { return idMorada; }
            set { idMorada = value; }
        }

        [DataMember]
        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        [DataMember]
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        [DataMember]
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        [DataMember]
        public int Andar
        {
            get { return andar; }
            set { andar = value; }
        }

        [DataMember]
        public string DescAndar
        {
            get { return descAndar; }
            set { descAndar = value; }
        }

        [DataMember]
        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        [DataMember]
        public int CodPostal
        {
            get { return codPostal; }
            set { codPostal = value; }
        }

    }


    [DataContract]
    public class ContactoRespostaPedido
    {
        int idContacto;
        int nivel;
        string tipo;
        string valor;

        [DataMember]
        public int IdContacto
        {
            get { return idContacto; }
            set { idContacto = value; }
        }

        [DataMember]
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        [DataMember]
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        [DataMember]
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

    }


    [DataContract]
    public class UtilizadorRespostaPedido
    {
        int idUser;
        string nome;
        DateTime dataNascimento;
        string gen;
        MoradaRespostaPedido moradaUtilizador;

        string paisOrigem;
        string cursoUtilizador;
        string userName;
        string tipoUtilizador;
        IList<ContactoRespostaPedido> contactos;


        [DataMember]
        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }

        [DataMember]
        public string TipoUtilizador
        {
            get { return tipoUtilizador; }
            set { tipoUtilizador = value; }
        }

        [DataMember]
        public string Gen
        {
            get { return gen; }
            set { gen = value; }
        }

        [DataMember]
        public MoradaRespostaPedido MoradaUtilizador
        {
            get { return moradaUtilizador; }
            set { moradaUtilizador = value; }
        }

        [DataMember]
        public string PaisOrigen
        {
            get { return paisOrigem; }
            set { paisOrigem = value; }
        }

        [DataMember]
        public string CursoUtilizador
        {
            get { return cursoUtilizador; }
            set { cursoUtilizador = value; }
        }

        [DataMember]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        [DataMember]
        public IList<ContactoRespostaPedido> Contactos
        {
            get { return contactos; }
            set { contactos = value; }
        }

        [DataMember]
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }



    }


    [DataContract]
    public class ListaDeUtilizadoresRespostaPedido
    {
        IList<UtilizadorRespostaPedido> dadosUtilizadores;

        [DataMember]
        public IList<UtilizadorRespostaPedido> DadosUtilizadores
        {
            get { return dadosUtilizadores; }
            set { dadosUtilizadores = value; }
        }

    }

    #endregion FIM


}
