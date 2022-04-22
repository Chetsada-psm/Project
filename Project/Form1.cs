namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("แล้วพบกันใหม่โอกาสหน้าที่ร้าน HappyDay Caffe ครับ", "HappyDay Caffe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}