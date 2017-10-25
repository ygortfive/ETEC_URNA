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
                table = "";
                //comandoSQL = "INSERT INTO " + table + " (data) values (str_to_date(" + eleicao.Data.Date + ",'%m/%d/%Y'));";
                comandoSQL = "Insert into teste_data values ('" + eleicao.Data + "')";
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
                table = "";
                comandoSQL = "SELECT id, date_format(data,'%d/%m/%Y') as Data from " + table;
                dt = bd.RetDataTable(comandoSQL);
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

            return dt;
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
