namespace scholarship
{
    public partial class LandingForm : Form
    {
        public LandingForm()
        {
            InitializeComponent();
            Ui.ApplyGradient(pnlLeft);
            Ui.LoadLogo(picLogo);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Ui.Open(this, new RegisterForm());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Ui.Open(this, new LoginForm());
        }
    }
}