using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ResultForm : Form
    {
        public List<string> links;
        public List<string> titles;
        public List<LinkLabel> linkLabels;

        public ResultForm()
        {
            InitializeComponent();
            link1.Hide();
            link2.Hide();
            link3.Hide();
            link4.Hide();
            link5.Hide();
            link6.Hide();
            link7.Hide();
            link8.Hide();
            link9.Hide();
            link10.Hide();

            linkLabels.Add(link1);
            linkLabels.Add(link2);
            linkLabels.Add(link3);
            linkLabels.Add(link4);
            linkLabels.Add(link5);
            linkLabels.Add(link6);
            linkLabels.Add(link7);
            linkLabels.Add(link8);
            linkLabels.Add(link9);
            linkLabels.Add(link10);
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            int i=-1;
            foreach(var item in titles)
            {
                i++;
                linkLabels[i].Text = item;
                linkLabels[i].Show();
            }

            foreach (var item in links)
                links.Add(item);
        }

        private void link1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(0);   
        }

        private void link2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(1);
        }

        private void link3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(2);
        }

        private void link4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(3);
        }

        private void link5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(4);
        }

        private void link6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(5);
        }

        private void link7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(6);
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(7);
        }

        private void link9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(8);
        }

        private void link10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink(9);
        }

        void openLink(int index)
        {
            System.Diagnostics.Process.Start(links[index]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
