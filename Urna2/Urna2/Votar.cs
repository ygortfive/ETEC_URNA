using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Urna2.Code.DTO;
using Urna2.Code.BLL;
using Urna2.Code.DTO;
using Urna2;

namespace Urna2
{
    public partial class Votar : Form
    {        
        //Estrutura válida => x = int.Parse(lblNum1.Text + lblNum2.Text);
        VotarBLL votarBLL = new VotarBLL();
        VotarDTO votarDTO = new VotarDTO();
        //Instanciando Home UrnaDTO para pegar CPF de quem está votando
        Home Home = new Home();
        UrnaDTO urnaDTO = new UrnaDTO();

        public Votar()
        {
            InitializeComponent();
            //Inicia as labels null
            lblNum1.Text = "";
            lblNum2.Text = "";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            //Se não houver nada na label 1, preenche ela
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "1";
            }
                //Se houver, preenche a 2
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "1";
                //Tendo a segunda label preenchida, vamos fazer aparecer a imagem do candidato.
                atribuiChapa();             
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);                
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "2";
            }
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "2";
                atribuiChapa();
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);
            }
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "3";
            }
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "3";
                atribuiChapa();
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);
            }
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "4";
            }
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "4";
                atribuiChapa();
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);
            }
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "5";
            }
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "5";
                atribuiChapa();
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);
            }
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "6";
            }
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "6";
                atribuiChapa();
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);
            }
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "7";
            }
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "7";
                atribuiChapa();
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);
            }
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "8";
            }
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "8";
                atribuiChapa();
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);
            }
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "9";
            }
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "9";
                atribuiChapa();
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);
            }
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            if (lblNum1.Text == "")
            {
                lblNum1.Text = "0";
            }
            else if (lblNum2.Text == "")
            {
                lblNum2.Text = "0";
                atribuiChapa();
                pibCandidato.ImageLocation = votarBLL.RetCandidato(votarDTO);
            }
        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void btnBranco_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Objeto dto do form Home agora está nesse form.
            urnaDTO = Home.RetCPF();
            try
            {
                votarBLL.confirmarVoto(urnaDTO, votarDTO);
                var message = MessageBox.Show("Voto registrado com sucesso. /n Obrigado por votar!", "VOTO REGISTRADO", 
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (message == DialogResult.OK)
                {
                    limpaCampos();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro para confirmar seu voto, favor tentar novamente \n Messagem de erro:" + ex.Message, 
                                "Erro para realizar voto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpaCampos();
            }
        }

        //Método para atribuir valores a chapa
        private void atribuiChapa()
        {
            votarDTO.Chapa = lblNum1.Text + lblNum2.Text;
        }

        //Limpar dados do form
        private void limpaCampos()
        {
            lblNum1.Text = "";
            lblNum1.Text = "";
            //Imagem padrão
            pibCandidato.ImageLocation = "images/User_Icon.png";
        }
        
    }
}
