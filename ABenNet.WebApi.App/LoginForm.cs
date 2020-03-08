using ABenNet.WebApi.App.DefaultAPIServiceImpl;
using ABenNet.WebApi.App.IDefaultAPIService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABenNet.WebApi.App
{
    public partial class LoginForm : Form
    {
        private static readonly ILoginDefaultApiService loginDefaultApiService = new LoginDefaultApiService();

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var loginResponseType = loginDefaultApiService.VerifyUserLogin(uid: this.txtUserName.Text,
                                                                                                                    pwd: this.txtPwd.Text);
                if (loginResponseType.RequestStatus == 100)
                {
                    MessageBox.Show(loginResponseType.Msg);
                }
                else
                {
                    MessageBox.Show(loginResponseType.Msg);
                    this.txtUserName.Text = this.txtPwd.Text = "";
                    this.txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoginByLoginByFromBody_Click(object sender, EventArgs e)
        {
            try
            {
                var loginResponseType = loginDefaultApiService.VerifyUserLoginByFromBody(uid: this.txtUserName.Text,
                                                                                                                                      pwd: this.txtPwd.Text);
                if (loginResponseType.RequestStatus == 100)
                {
                    MessageBox.Show(loginResponseType.Msg);
                }
                else
                {
                    MessageBox.Show(loginResponseType.Msg);
                    this.txtUserName.Text = this.txtPwd.Text = "";
                    this.txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
