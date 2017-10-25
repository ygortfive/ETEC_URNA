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

namespace Urna2
{
    public partial class Home : Form
    {
        Urna urna = new Urna();
        UrnaDTO dto = new UrnaDTO();
        UrnaBLL bll = new UrnaBLL();

        public Home()
        {
            InitializeComponent();
        }

        private void btnEntrarUrna_Click(object sender, EventArgs e)
        {
            dto.Cpf = txtCPF.Text;
            if (!bll.validarCPF(dto))
            {
                MessageBox.Show("CPF não encontrado. Favor verificar o número inserio");
                txtCPF.Focus();
            }
            else
            {
                txtCPF.Clear();
                urna.ShowDialog();
            }
        }

        public UrnaDTO RetCPF()
        {
            return dto;
        }



        
    }
}
