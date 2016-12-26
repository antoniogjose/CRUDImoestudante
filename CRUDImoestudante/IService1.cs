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

        [WebGet(UriTemplate = "/GetUsersData", ResponseFormat = WebMessageFormat.Json)]
        List<UtilizadorRespostaPedido> GetUsersData();

        [OperationContract]

        [WebGet(UriTemplate = "/SearchUserId/{id}", ResponseFormat = WebMessageFormat.Json)]
        UtilizadorRespostaPedido SearchUserId(string id);

        [OperationContract]

        [WebGet(UriTemplate = "/SearchUser", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool SearchUser(user utilizador);


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

        #endregion  end


    }


    #region DATA ALOJAMENTO

    [DataContract]
    public class AlojamentoRespostaPedido
    {

        int idAlojamento;
        tipologia tipol;
        tipoAlojamento tipoAloj;
        MoradaRespostaPedido moradaAlojamento;
        int avaliacao;
        IList<comodidade> comod;

        [DataMember]
        public int IdAlojamento
        {
            get { return idAlojamento; }
            set { idAlojamento = value; }
        }

        [DataMember]
        public tipologia Tipol
        {
            get { return tipol; }
            set { tipol = value; }
        }

        [DataMember]
        public tipoAlojamento TipoAloj
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
        public IList<comodidade> comodidades
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

        public int IdMorada
        {
            get { return idMorada; }
            set { idMorada = value; }
        }
        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public int Andar
        {
            get { return andar; }
            set { andar = value; }
        }

        public string DescAndar
        {
            get { return descAndar; }
            set { descAndar = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

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

        public int IdContacto
        {
            get { return idContacto; }
            set { idContacto = value; }
        }
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

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



        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }


        public string TipoUtilizador
        {
            get { return tipoUtilizador; }
            set { tipoUtilizador = value; }
        }

        public string Gen
        {
            get { return gen; }
            set { gen = value; }
        }

        public MoradaRespostaPedido MoradaUtilizador
        {
            get { return moradaUtilizador; }
            set { moradaUtilizador = value; }
        }

        public string PaisOrigen
        {
            get { return paisOrigem; }
            set { paisOrigem = value; }
        }

        public string CursoUtilizador
        {
            get { return cursoUtilizador; }
            set { cursoUtilizador = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public IList<contacto> Contactos
        {
            get { return contactos; }
            set { contactos = value; }
        }

        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

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
