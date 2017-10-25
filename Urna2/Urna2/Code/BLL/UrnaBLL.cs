using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto3Camadas.Code.DAL;
using MySql.Data.MySqlClient;
using System.Data;
using Urna2.Code.DTO;

namespace Urna2.Code.BLL
{//Classe com metodos da urna
    //pendente table
    class UrnaBLL
    {
        AcessoBancoDados bd;
        MySqlDataReader dr = null;
        string comando, table;

        public bool validarCPF(UrnaDTO cpf)
        {
            try
            {
                bd = new AcessoBancoDados();
                table = "";
                comando = "Select cpf from tb_eleitor where cpf = '" + cpf.Cpf + "';";
                dr = bd.RetDataReader(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar CPF: \n " + ex.Message );
            }

            return dr.Read();
        }

    }
}
