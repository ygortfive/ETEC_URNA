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
            btnExcluir.Enabled = false;
        }

        private void AtualizaGrid()
        {
            dgvEleicoes.DataSource = bll.AtualizarEleicao();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CadEleicao eleicao = new CadEleicao();
            eleicao.ShowDialog();
            AtualizaGrid();
        }

        private void formADM_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizaGrid();
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
                var message = MessageBox.Show("ID: " + grvId + "\n Data: " + grvData.Date + "\n Gostaria de alterar essa eleição?","Confirmação de alteração",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    bll.AlterarData(grvId, grvData);
                    MessageBox.Show("Data alterada com sucesso.", "Alteração de data", MessageBoxButtons.OK
                                    , MessageBoxIcon.Information);
                    AtualizaGrid();
                    limparDados();
                }
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
                var message = MessageBox.Show("ID: " + grvId + "\n Data: " + grvData.Date.ToString() + "\n Realmente deseja excluir essa eleição?", "Exclusão de eleição",
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

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            if (grvId == "" || grvData.Equals(""))
            {
                MessageBox.Show("Selecione uma eleição para ser encerrada", "Falha no encerramento da eleição",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var message = MessageBox.Show("ID: " + grvId + "\n Data: " + grvData.Date.ToString() + "\n Realmente deseja encerrar essa eleição?", "Exclusão de eleição",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (message == DialogResult.Yes)
                {
                    if (bll.EncerrarEleicao(bll.RetEleitores(), bll.RetVotos(), grvId))
                    {

                    }
                }
            }
        }
    }
}
