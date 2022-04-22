using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str, str1, str2, str3, str4, str5;
            double BE1, BE2, BE3, BE4, BE5, BE6, DE1, DE2, DE3, SUM, SUM2;
            str = "";
            str2 = "";
            str3 = "";
            str4 = "";


            if (radioButton1.Checked == true)
            {
                str = "นาย" + textName.Text;
            }

            else
            {
                str = "นางสาว" + textName.Text;
            }

            str2 += date1.SelectedItem.ToString() + mouth1.SelectedItem.ToString() + year1.SelectedItem.ToString();
            str3 += textEmail.Text;
            str4 += textPhone.Text;

            str1 = "";
            str5 = "";
            if (B1.Checked == true)
            {
                str1 += "\r\n\nเอสเพรสโซ ราคา 50 บาท :";
                BE1 = 50;
            }
            else
            {
                BE1 = 0;
            }
            if (B2.Checked == true)
            {
                str1 += "\r\n\nอเมริกาโน่ ราคา 70 บาท :";
                BE2 = 70;
            }
            else
            {
                BE2 = 0;
            }
            if (B3.Checked == true)
            {
                str1 += "\r\n\nลาเต้ ราคา 65 บาท :";
                BE3 = 65;
            }
            else
            {
                BE3 = 0;
            }
            if (B4.Checked == true)
            {
                str1 += "\r\n\nคาปูชิโน่ ราคา 60 บาท :";
                BE4 = 60;
            }
            else
            {
                BE4 = 0;
            }
            if (B5.Checked == true)
            {
                str1 += "\r\n\nมอคค่า ราคา 65 บาท :";
                BE5 = 65;
            }
            else
            {
                BE5 = 0;
            }
            if (B6.Checked == true)
            {
                str1 += "\r\n\nโกโก้เย็น ราคา 50 บาท :";
                BE6 = 50;
            }
            else
            {
                BE6 = 0;
            }
            if (D1.Checked == true)
            {
                str1 += "\r\n\nวาฟเฟิล ราคา 35 บาท :";
                DE1 = 35;
            }
            else
            {
                DE1 = 0;
            }
            if (D2.Checked == true)
            {
                str1 += "\r\n\nครัวซอง ราคา 45 บาท :";
                DE2 = 45;
            }
            else
            {
                DE2 = 0;
            }
            if (D3.Checked == true)
            {
                str1 += "\r\n\nคุกกี้ ราคา 55 บาท :";
                DE3 = 55;
            }
            else
            {
                DE3 = 0;
            }

            textOrder.Text = str1;
            SUM = BE1 + BE2 + BE3 + BE4 + BE5 + BE6 + DE1 + DE2 + DE3;
            textSum.Text = (SUM + " บาท");
            str5 += textSum.Text;
            MessageBox.Show("บันทึกรายการทั้งหมด คิดเป็นเงิน" + textSum.Text, "HappyDay Caffe", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            SUM2 = int.Parse(textMoney.Text) - SUM;
            textChange.Text = SUM2.ToString();

            this.dataGridView1.Rows.Add(str, str2, str3, str4, str5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textName.Clear();
            date1.ResetText();
            mouth1.ResetText();
            year1.ResetText();
            textEmail.Clear();
            textPhone.Clear();
            dataGridView1.Rows.Clear();
            textOrder.Clear();
            textSum.Clear();
            textMoney.Clear();
            textChange.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            B1.Checked = false;
            B2.Checked = false;
            B3.Checked = false;
            B4.Checked = false;
            B5.Checked = false;
            B6.Checked = false;
            D1.Checked = false;
            D2.Checked = false;
            D3.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ขอบคุณที่ใช้บริการร้าน HappyDayCaffe ไว้พบกันใหม่โอกาสหน้าครับ", "HappyDay Caffe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | * .csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);
                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string DataRaw = readAllLine[i];
                    string[] DataSpited = DataRaw.Split(',');
                    this.dataGridView1.Rows.Add(DataSpited[0], DataSpited[1], DataSpited[2], DataSpited[3], DataSpited[4]);

                }
            }
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            string columnsHeader = "";
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                columnsHeader += dataGridView1.Columns[i].Name + ",";
            }
            sb.Append(columnsHeader + Environment.NewLine);

            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                if (!dgvRow.IsNewRow)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {

                        sb.Append(dgvRow.Cells[c].Value + ",");
                    }
                    sb.Append(Environment.NewLine);
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                {
                    sw.WriteLine(sb.ToString());
                }
            }
            MessageBox.Show("CSV file saved.");
        }
    }
}
