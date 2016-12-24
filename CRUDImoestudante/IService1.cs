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
        List<user> GetUsersData();

        [OperationContract]

        [WebGet(UriTemplate = "/SearchUserId/{id}", ResponseFormat = WebMessageFormat.Json)]
        user SearchUserId(string id);

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
        morada moradaAlojamento;
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
        public morada MoradaAlojamento
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
    public class UtilizadorRespostaPedido
    {
        int idUser;
        string nome;
        DateTime dataNascimento;
        genero gen;
        morada moradaUtilizador;
        pai paisOrigem;
        curso cursoUtilizador;

        string userName;
        tipoUser tipoUtilizador;
        string contacto;



        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }


        public tipoUser TipoUtilizador
        {
            get { return tipoUtilizador; }
            set { tipoUtilizador = value; }
        }

        public genero Gen
        {
            get { return gen; }
            set { gen = value; }
        }

        public morada MoradaUtilizador
        {
            get { return moradaUtilizador; }
            set { moradaUtilizador = value; }
        }

        public pai PaisOrigen
        {
            get { return paisOrigem; }
            set { paisOrigem = value; }
        }

        public curso CursoUtilizador
        {
            get { return cursoUtilizador; }
            set { cursoUtilizador = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Contacto
        {
            get { return contacto; }
            set { contacto = value; }
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
