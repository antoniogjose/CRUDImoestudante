using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDImoestudante
{
    /**public class Alojamento
    {
        public int idAlojamento
        {
            get { return idAlojamento; }
            set { idAlojamento = value; }
        }
        public Tipologia tipologia
        {
            get { return tipologia; }
            set { tipologia = value; }
        }
        public TipoAlojamento tipoAlojamento
        {
            get { return tipoAlojamento; }
            set { tipoAlojamento = value; }
        }
        public Morada morada
        {
            get { return morada; }
            set { morada = value; }
        }

        public int avaliacao
        {
            get { return avaliacao; }
            set { avaliacao = value; }
        }


        public IList<Comodidade> Comodidades
        {
            get { return Comodidades; }
            set { Comodidades = value; }
        }
    }


    public class Aluguer
    {
        public int idAlojamento
        {
            get { return idAlojamento; }
            set { idAlojamento = value; }
        }
        public int idAluguer
        {
            get { return idAluguer; }
            set { idAluguer = value; }
        }
        public int idUserAgente
        {
            get { return idUserAgente; }
            set { idUserAgente = value; }
        }
        public int idUserSenhorio
        {
            get { return idUserSenhorio; }
            set { idUserSenhorio = value; }
        }

        public int idUserInquilino
        {
            get { return idUserInquilino; }
            set { idUserInquilino = value; }
        }

        public DateTime dataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        public DateTime dataFim
        {
            get { return dataFim; }
            set { dataFim = value; }
        }

        public double valorRenda
        {
            get { return valorRenda; }
            set { valorRenda = value; }
        }

    }

    public class AreaCurso
    {
        public int idArea
        {
            get { return idArea; }
            set { idArea = value; }
        }
        public int idCurso
        {
            get { return idCurso; }
            set { idCurso = value; }
        }
        public string nomeArea
        {
            get { return nomeArea; }
            set { nomeArea = value; }
        }

    }


    public class Comodidade
    {
        public int idComodidade
        {
            get { return idComodidade; }
            set { idComodidade = value; }
        }

        public string nomeComodidade
        {
            get { return nomeComodidade; }
            set { nomeComodidade = value; }
        }

    }


    public class Curso
    {
        public int idCurso
        {
            get { return idCurso; }
            set { idCurso = value; }
        }

        public int idInstituicao
        {
            get { return idInstituicao; }
            set { idInstituicao = value; }
        }

        public string nomeCurso
        {
            get { return nomeCurso; }
            set { nomeCurso = value; }
        }

    }


    public class Estado
    {
        public int idEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }

        public string nomeEstado
        {
            get { return nomeEstado; }
            set { nomeEstado = value; }
        }


    }

    public class Genero
    {
        public int idGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }

        public string nomeGenero
        {
            get { return nomeGenero; }
            set { nomeGenero = value; }
        }


    }


    public class Instituicao
    {
        public int idInstituicao
        {
            get { return idInstituicao; }
            set { idInstituicao = value; }
        }

        public Morada moradaInstituicao
        {
            get { return moradaInstituicao; }
            set { moradaInstituicao = value; }
        }

        public string nomeInstituicao
        {
            get { return nomeInstituicao; }
            set { nomeInstituicao = value; }
        }



    }


    public class Morada
    {
        public int idMorada
        {
            get { return idMorada; }
            set { idMorada = value; }
        }

        public int idPais
        {
            get { return idPais; }
            set { idPais = value; }
        }

        public string cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string rua
        {
            get { return rua; }
            set { rua = value; }
        }


        public int codigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }


        public string andar
        {
            get { return andar; }
            set { andar = value; }
        }

        public int numeroPorta
        {
            get { return numeroPorta; }
            set { numeroPorta = value; }
        }

    }


    public class Pais
    {
        public int idPais
        {
            get { return idPais; }
            set { idPais = value; }
        }

        public string nomePais
        {
            get { return nomePais; }
            set { nomePais = value; }
        }


    }



    public class TipoAlojamento
    {
        public int idTipoAlojamento
        {
            get { return idTipoAlojamento; }
            set { idTipoAlojamento = value; }
        }

        public string nomeTipoAlojamento
        {
            get { return nomeTipoAlojamento; }
            set { nomeTipoAlojamento = value; }
        }


    }

    public class Tipologia
    {
        public int idTipologia
        {
            get { return idTipologia; }
            set { idTipologia = value; }
        }

        public string nomeTipologia
        {
            get { return nomeTipologia; }
            set { nomeTipologia = value; }
        }


    }


    public class TipoUser
    {
        public int idTipoUser
        {
            get { return idTipoUser; }
            set { idTipoUser = value; }
        }

        public string nomeTipoUser
        {
            get { return nomeTipoUser; }
            set { nomeTipoUser = value; }
        }


    }



    public class User
    {
        public int idUser
        {
            get { return idUser; }
            set { idUser = value; }
        }


        public TipoUser tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Genero genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public Morada morada
        {
            get { return morada; }
            set { morada = value; }
        }

        public Pais pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public Curso curso
        {
            get { return curso; }
            set { curso = value; }
        }

        public string nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string contato
        {
            get { return contato; }
            set { contato = value; }
        }

        public DateTime dataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        public string login
        {
            get { return login; }
            set { login = value; }
        }

        public string password
        {
            get { return password; }
            set { password = value; }
        }

        public string nomeTipoUser
        {
            get { return nomeTipoUser; }
            set { nomeTipoUser = value; }
        }


    }




    public class ImoEstudante
    {
        public IList<Alojamento> alojamentos
        {
            get { return alojamentos; }
            set { alojamentos = value; }
        }


        public IList<Aluguer> alugueres
        {
            get { return alugueres; }
            set { alugueres = value; }
        }

        public IList<Comodidade> Comodidades
        {
            get { return Comodidades; }
            set { Comodidades = value; }
        }

        public IList<User> utilizadores
        {
            get { return utilizadores; }
            set { utilizadores = value; }
        }
    }**/
}