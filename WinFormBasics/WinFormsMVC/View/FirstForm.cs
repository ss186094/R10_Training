namespace WinFormsMVC
{
    public partial class btnnext : Form
    {
        public btnnext()
        {
            InitializeComponent();
        }
        public UserInfo UserInfo { get; set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        

        private  void btnnext_Load(object sender, EventArgs e)
        {
            FirstName.Text = UserInfo.FirstName;    
            LastName.Text = UserInfo.LastName;
            Email.Text = UserInfo.Email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FirstName_TextChanged(object sender, EventArgs e)
        {
            UserInfo.FirstName = FirstName.Text;
            
            
        }

        private void LastName_TextChanged(object sender, EventArgs e)
        {
            UserInfo.LastName = LastName.Text;
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            UserInfo.Email = Email.Text;
        }
    }
}