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

        public CadEleicao()
        {
            InitializeComponent();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            //dto.Data = DateTime.Parse(mTxtBox.Text);
            string str = mTxtBox.Text;
            dto.Data = DateTime.ParseExact(str, mTxtBox.Text, null);

            try
            {
                bll.criarEleicao(dto);

               
                MessageBox.Show("Eleição criada com sucesso, favor voltar ao menu principal para conferir.","Eleição criada", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
