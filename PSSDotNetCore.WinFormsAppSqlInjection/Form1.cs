using PSSDotNetCore.Shared;

namespace PSSDotNetCore.WinFormsAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperService;
        public Form1()
        {            
            InitializeComponent();
            _dapperService = new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string query = $"select * from tbl_user where Email = '{txtUserName.Text.Trim()}' and Password = '{txtPassword.Text.Trim()}'";
            string query = $"select * from tbl_user where Email = @Email and Password = @Password";

            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
            {
                Email =  txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim()
            });
            if (model is null)
            {
                MessageBox.Show("User doesn't exist.");
                return;
            }
            MessageBox.Show("Is Admin : " + model.Email);
        }
    }

    public class UserModel
    {
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
