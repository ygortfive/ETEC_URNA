using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrnaADM.Code.DTO;
using UrnaADM.Code.BLL;

namespace UrnaADM
{
    public partial class CadEleicao : Form
    {
        EleicaoBLL bll = new EleicaoBLL();
        EleicaoDTO dto = new EleicaoDTO();
        DateTime dataAtual = DateTime.Now;

        public CadEleicao()
        {
            InitializeComponent();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {                
                DateTime dt = Convert.ToDateTime(mTxtBox.Text);
                if (dt.Date > dataAtual.Date)
                {
                    dto.Data = dt;
                    bll.criarEleicao(dto);
                    MessageBox.Show("Eleição criada com sucesso, favor voltar ao menu principal para conferir.", "Eleição criada",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose(); 
                }
                else
                {
                    MessageBox.Show("Data não permitida, favor corrigir", "DATA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar criar uma nova eleição: \n" + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mTxtBox.Clear();
            mTxtBox.Focus();
        }

    }
}
