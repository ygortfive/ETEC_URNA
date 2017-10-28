using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaADM.Code.DTO;
using Projeto3Camadas.Code.DAL;
using System.Data;

namespace UrnaADM.Code.BLL
{
    class EleicaoBLL
    {
        private AcessoBancoDados bd;
        private string comandoSQL;
        private string table;

        //Método para criar uma eleição no banco de dados
        public void criarEleicao(EleicaoDTO eleicao)
        {
            try
            {                
                bd = new AcessoBancoDados();
                bd.Conectar();
                comandoSQL = "Insert into Eleicao (data_eleicao) values ('" + eleicao.Data.Year + eleicao.Data.Month + eleicao.Data.Day + "')";
                bd.ExecutarComandoSQL(comandoSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bd = null;
                table = null;
                comandoSQL = null;
            }

        }

        //Preencher grid com data das eleições
        public DataTable AtualizarEleicao()
        {
            DataTable dt = new DataTable();
            try
            {
                //Necessário preencher com a tabela
                bd = new AcessoBancoDados();
                bd.Conectar();
                table = "Eleicao";
                comandoSQL = "SELECT id_eleicao as ID, date_format(data_eleicao,'%d/%m/%Y') as Data from " + table;
                dt = bd.RetDataTable(comandoSQL);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bd = null;
                comandoSQL = null;
                table = null;
            }

        }

        //Atualizar data da eleição
        public void AlterarData(string id, DateTime newData)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                table = "";
                comandoSQL = "UPDATE " + table + " SET data = str_to_date(" + newData.Date + ",'%m/%d/%Y') where id = " + id;
                bd.ExecutarComandoSQL(comandoSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bd = null;
                table = null;
                comandoSQL = null;
            }
        }

        public void ExcluirData(string id)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                table = "";
                comandoSQL = "DELETE FROM " + table + "where id = " + id;
                bd.ExecutarComandoSQL(comandoSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar excluir o cliente: " + ex.Message);
            }
            finally
            {
                comandoSQL = null;
                bd = null;
            }
        }          
              
            
    }
}
