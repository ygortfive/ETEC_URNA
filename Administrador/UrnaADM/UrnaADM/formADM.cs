using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrnaADM.Code.BLL;

namespace UrnaADM
{
    public partial class formADM : Form
    {
        EleicaoBLL bll = new EleicaoBLL();
        string grvId;
        DateTime grvData;

        public formADM()
        {
            InitializeComponent();
        }

        private void AtualizaGrid()
        {
            dgvEleicoes.DataSource = bll.AtualizarEleicao();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CadEleicao eleicao = new CadEleicao();
            eleicao.Show();
        }

        private void formADM_Load(object sender, EventArgs e)
        {
            //AtualizaGrid();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            //AtualizarGrid();
        }

        private void dgvEleicoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grvId = dgvEleicoes.Rows[e.RowIndex].Cells[0].Value.ToString();
            grvData = DateTime.Parse(dgvEleicoes.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(grvId == "" || grvData.Equals(""))
            {
                MessageBox.Show("Selecione uma eleição para ser alterada", "Falha na alteração da data", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bll.AlterarData(grvId, grvData);
                MessageBox.Show("Data alterada com sucesso.", "Alteração de data", MessageBoxButtons.OK
                                , MessageBoxIcon.Information);
                AtualizaGrid();
                limparDados();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (grvId == "" || grvData.Equals(""))
            {
                MessageBox.Show("Selecione uma eleição para ser excluido", "Falha na exclusão da data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var message = MessageBox.Show("Realmente deseja excluir essa eleição?", "Exclusão de eleição",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(message == DialogResult.Yes)
                {
                    bll.ExcluirData(grvId);
                    MessageBox.Show("Eleição excluida com sucesso.");
                    AtualizaGrid();
                    limparDados();
                }
            }
        }

        private void limparDados()
        {
            grvId = null;            
        }
    }
}
