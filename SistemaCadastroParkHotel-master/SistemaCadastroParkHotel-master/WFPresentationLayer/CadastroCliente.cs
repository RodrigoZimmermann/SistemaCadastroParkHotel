using BLL;
using Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPPresentationLayer
{
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }
        ClienteBLL bll = new ClienteBLL();

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente(Registro.NOVO_REGISTRO, txtNomeCliente.Text, mskCPFCliente.Text,
                txtRGCliente.Text, mskTelefoneCliente.Text, mskCelularCliente.Text, txtEmailCliente.Text, true);
            string resposta = bll.Inserir(cli);
           dataGridView1.DataSource = bll.LerTodos();
            MessageBox.Show(resposta);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que quer excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No)
            {
                return;
            }
            Cliente cli = new Cliente(int.Parse(txtID.Text), txtNomeCliente.Text, mskCPFCliente.Text,
                txtRGCliente.Text, mskTelefoneCliente.Text, mskCelularCliente.Text, txtEmailCliente.Text, true);
            string resposta = bll.Excluir(cli);
            dataGridView1.DataSource = bll.LerTodos();
            MessageBox.Show(resposta);

            MessageBox.Show("Excluido com sucesso!");
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.LerTodos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente(int.Parse(txtID.Text), txtNomeCliente.Text, mskCPFCliente.Text,
               txtRGCliente.Text, mskTelefoneCliente.Text, mskCelularCliente.Text, txtEmailCliente.Text, true);
            string resposta = bll.Atualizar(cli);
            dataGridView1.DataSource = bll.LerTodos();
            MessageBox.Show(resposta);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            string Nome = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            string CPF = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            string RG = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            string Telefone = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            string Celular = (string)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            string Email = (string)dataGridView1.Rows[e.RowIndex].Cells[6].Value;

            txtNomeCliente.Text = Nome;
            mskCPFCliente.Text = CPF;
            txtRGCliente.Text = RG;
            mskTelefoneCliente.Text = Telefone;
            mskCelularCliente.Text = Celular;
            txtEmailCliente.Text = Email;
            txtID.Text = ID.ToString();
        }
    }
}
