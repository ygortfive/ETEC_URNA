using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaADM.Code.DTO;
using Projeto3Camadas.Code.DAL;
using System.Data;
using MySql.Data.MySqlClient;

namespace UrnaADM.Code.BLL
{
    class EleicaoBLL
    {
        private AcessoBancoDados bd;
        private string comandoSQL;
        private string table;
        private int eleitores, votos;

        //Método para criar uma eleição no banco de dados
        public void criarEleicao(EleicaoDTO eleicao)
        {
            try
            {                
                bd = new AcessoBancoDados();
                bd.Conectar();
                comandoSQL = "Insert into Eleicao (data_eleicao,eleicao_valida) values ('" + eleicao.Data.Year + eleicao.Data.Month + eleicao.Data.Day + "', true)";
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
                comandoSQL = "SELECT id_eleicao as ID, date_format(data_eleicao,'%d/%m/%Y') as Data from " + table + "where eleicao_valida = true;";
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
                table = "Eleicao";
                comandoSQL = "UPDATE " + table + " SET data = " + newData.Year + newData.Month + newData.Day + " where id = " + id;
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
                table = "Eleicao";
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

        public int RetEleitores()
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                comandoSQL = "select count(id_eleitor) as eleitores from eleitor;";

                return Convert.ToInt32(bd.RetDataReader(comandoSQL));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar calcular eleitores: \n " + ex.Message);
            }
            finally
            {
                comandoSQL = null;
                bd = null;
            }
        }

        public int RetVotos()
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                comandoSQL = "select count(votou) from Eleitor_Eleicao;";

                return Convert.ToInt32(bd.RetDataReader(comandoSQL));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar calcular votos: \n " + ex.Message);
            }
            finally
            {
                comandoSQL = null;
                bd = null;
            }
        }

        public bool EncerrarEleicao(int eleitores, int votos, string id)
        {
            int votosValidos;
            votosValidos = (eleitores / 2) + 1;
            if (votos > votosValidos)
            {
                try
                {
                    bd = new AcessoBancoDados();
                    bd.Conectar();
                    comandoSQL = "update eleicao set eleicao_valida = false where id = " + id + ";";
                    bd.ExecutarComandoSQL(comandoSQL);

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar encerrar eleição: \n " + ex.Message);
                }
            }
            else
            {
                return false;
            }            
        }
    }
}
