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
                throw new Exception("Erro para localizar imagem do candidato \n" + ex.Message);
            }
            return url;
        }

        public void confirmarVoto(UrnaDTO urnaDTO, VotarDTO votarDTO)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                table = "";
                comando = "Update " + table + "set votou = " + votarDTO.Chapa + "where cpf = '" + urnaDTO.Cpf + "';";
                bd.ExecutarComandoSQL(comando);                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro para confirmar seu voto. \n VOTO NÃO CONTABILIZADO \n" + ex.Message);
            }
        }
    }
}
