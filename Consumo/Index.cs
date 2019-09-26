using Consumo.ServiceControlProteina;
using HelloWordWebAplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumo
{
    public partial class Index : Form
    {
        private GrettingSoapClient gretting = new GrettingSoapClient();
        private User[] users;
        public Index()
        {
            InitializeComponent();
        }

   

        private void Index_Load(object sender, EventArgs e)
        {
            users = gretting.listuser();
            comboUser.DataSource = users;
            comboUser.DisplayMember = "Name";
            comboUser.ValueMember = "userId";

        }

        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (Txtname.Text !=String.Empty && Txtgoal.Text != String.Empty)
            {
                gretting.AddUser(Txtname.Text, int.Parse(Txtgoal.Text));
                users = gretting.listuser();
                comboUser.DataSource = users;
                MessageBox.Show("Usuario agregado correctamente");
            }
            else
            {
                MessageBox.Show("Campos Vacios");
            }
            
        }

        private void BtnSumar_Click(object sender, EventArgs e)
        {
            if (Txtmeta.Text !=  String.Empty)
            {
                var userID = users[comboUser.SelectedIndex].UserId;
                var newtotal = gretting.AddProtein(int.Parse(Txtmeta.Text), userID);
                users[comboUser.SelectedIndex].Total = newtotal;
                total.Text = newtotal.ToString();
                MessageBox.Show("Suma exitosa");

            }
            else
            {
                MessageBox.Show("Campos Vacios");
            }

        }

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = comboUser.SelectedIndex;
            total.Text = users[index].Total.ToString();
            meta.Text = users[index].Goal.ToString();

        }
    }
}
