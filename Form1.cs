using MyProjectAboutListView.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProjectAboutListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private short Counter=0;
        stTime Time;
        struct stTime
        {
            public byte TimerSeconds;
            public byte minute ;
            public byte houres;
        }
       


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void MakeInfoOfCardunVisible()
        {
            lbAgeCard.Visible = false;
            lbFirstNameCard.Visible = false;
            lbLastNameCard.Visible = false;
            lbIDCard.Visible = false;
            lbMajerCard.Visible = false;
            lbRegistrationCard.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MakeInfoOfCardunVisible();
            timer1.Enabled = true;

            DateTime Date = DateTime.Now;
            lbDate.Text = Date.ToString("dd/MM/yyyy");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || (!mbAge.MaskCompleted) || string.IsNullOrEmpty(txtMajer.Text) || string.IsNullOrEmpty(dtRegistration.Text))
            {

                MessageBox.Show("Please fill all Required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            Counter++;

            ListViewItem Item = new ListViewItem(Counter.ToString());

            if (rbMale.Checked)
                Item.ImageIndex = 1;
            else
                Item.ImageIndex= 0;





            Item.SubItems.Add(txtFirstName.Text);
            Item.SubItems.Add(txtLastName.Text);

            Item.SubItems.Add(mbAge.Text);
            Item.SubItems.Add(txtMajer.Text);

            Item.SubItems.Add(dtRegistration.Value.ToString("dd/MM/yyyy"));

            listView1.Items.Add(Item);
            lbStudentNumber.Text=Counter.ToString();
            CleanTxt();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count>0)
            {

                listView1.Items.Remove(listView1.SelectedItems[0]);
                Counter--;
                lbStudentNumber.Text = Counter.ToString();
                if(Counter == 0)
                {
                    MakeInfoOfCardunVisible();
                }

            }
        }
        void CleanTxt()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMajer.Text = "";
            mbAge.Text = "";
            txtFirstName.Focus();
        }
        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }
        void VisibleInfoInCreditCard()
        {

            lbFirstNameCard.Visible = true;
            lbMajerCard.Visible = true;
            lbIDCard.Visible = true;
            lbLastNameCard.Visible = true;
            lbRegistrationCard.Visible = true;
            lbAgeCard.Visible = true;
        }
        void ShowCreditCard(ListViewItem Item )
        {

            if (Item.ImageIndex > 0)
                pbCard.BackgroundImage = Resources.Boy;
            else
                pbCard.BackgroundImage = Resources.Girl;



                lbIDCard.Text = Item.SubItems[0].Text;
            lbFirstNameCard.Text = Item.SubItems[1].Text;
            lbLastNameCard.Text = Item.SubItems[2].Text;
            lbAgeCard.Text = Item.SubItems[3].Text;
            lbMajerCard.Text = Item.SubItems[4].Text;
            lbRegistrationCard.Text = Item.SubItems[5].Text;


        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            VisibleInfoInCreditCard();

            ShowCreditCard(listView1.SelectedItems[0]);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Tile;

        }

        void GetInfoStudentToEdit(ListViewItem SelectedSudent)
        {

            txtFirstName.Focus();
           
            txtFirstName.Text = SelectedSudent.SubItems[1].Text;
            txtLastName.Text = SelectedSudent.SubItems[2].Text;
            mbAge.Text = SelectedSudent.SubItems[3].Text;
            txtMajer.Text = SelectedSudent.SubItems[4].Text;
            dtRegistration.Text = SelectedSudent.SubItems[5].Text;

        }
        void EdetItemSelected()
        {

            ListViewItem SelectedItem = listView1.SelectedItems[0];
            if (rbMale.Checked)
                SelectedItem.ImageIndex = 1;
            else
                SelectedItem.ImageIndex = 0;


                SelectedItem.SubItems[1].Text = txtFirstName.Text;
            SelectedItem.SubItems[2].Text = txtLastName.Text;
            SelectedItem.SubItems[3].Text = mbAge.Text;
            SelectedItem.SubItems[4].Text = txtMajer.Text;
            SelectedItem.SubItems[5].Text = dtRegistration.Value.ToString("dd/MM/yyyy");
            ShowCreditCard(SelectedItem);

            CleanTxt();


        }
        private void btnEdit_Click(object sender, EventArgs e)
        {

            if(listView1.SelectedItems.Count>0)
            {
                if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || (!mbAge.MaskCompleted) || string.IsNullOrEmpty(txtMajer.Text) || string.IsNullOrEmpty(dtRegistration.Text))
                {
                    MessageBox.Show("Double Click on Item to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                else if (MessageBox.Show("Click Ok for perform the proscess.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {


                    EdetItemSelected();
                }
                else
                {
                    return;
                }

            }

            else
            {

                MessageBox.Show("Select Item to Edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetInfoStudentToEdit(listView1.SelectedItems[0]);

        }

        private void pbCard_Click(object sender, EventArgs e)
        {

        }

        private void lbStudentNumber_Click(object sender, EventArgs e)
        {
            
        }

        private void lbDate_Click(object sender, EventArgs e)
        {

        }
        void GetTime(ref byte Seconds)
        {

            if (Seconds > 59)
            {
                Time.minute++;
                Seconds = 0;
                
            }

            if (Time.minute > 59)
            {
                Time.minute = 0;
                Seconds = 0;
                Time.houres++;


            }
            if (Time.houres > 23)
            {
                Time.houres = 0;
                Time.minute = 0;
                Seconds = 0;

            }

            label2.Text = Time.houres.ToString("00:") + Time.minute.ToString("00:") + Seconds.ToString("00");

        }


        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbtime.Text = DateTime.Now.ToString("T");
            Time.TimerSeconds++;
            GetTime( ref Time.TimerSeconds);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
