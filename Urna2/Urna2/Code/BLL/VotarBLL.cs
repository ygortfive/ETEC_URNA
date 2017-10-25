using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto3Camadas.Code.DAL;
using Urna2.Code.DTO;

namespace Urna2.Code.BLL
{
    class VotarBLL
    {
        AcessoBancoDados bd;
        string comando,table, url = null;

        public string RetCandidato(VotarDTO dto)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                table = "";
                comando = "Select foto from " + table + "where chapa = " + dto.Chapa + ";";
                url = bd.RetDataReader(comando).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro para localizar imagem do candidato" + ex.Message);
            }
            return url;
        }
    }
}
