namespace POS_Admin.Views.Auth
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPassword = new POS_Admin.CustomControls.CustomPaddingTextBox();
            this.txtUserName = new POS_Admin.CustomControls.CustomPaddingTextBox();
            this.lblCloseText = new System.Windows.Forms.Label();
            this.lblLoginText = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BackgroundImage = global::POS_Admin.Properties.Resources.login;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.lblCloseText);
            this.panel1.Controls.Add(this.lblLoginText);
            this.panel1.Controls.Add(this.lblClose);
            this.panel1.Controls.Add(this.lblLogin);
            this.panel1.Location = new System.Drawing.Point(0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1345, 700);
            this.panel1.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.Location = new System.Drawing.Point(554, 380);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(342, 22);
            this.txtPassword.TabIndex = 20;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUserName.Location = new System.Drawing.Point(554, 304);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(342, 22);
            this.txtUserName.TabIndex = 19;
            // 
            // lblCloseText
            // 
            this.lblCloseText.AutoSize = true;
            this.lblCloseText.BackColor = System.Drawing.Color.Transparent;
            this.lblCloseText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblCloseText.ForeColor = System.Drawing.Color.White;
            this.lblCloseText.Location = new System.Drawing.Point(808, 454);
            this.lblCloseText.Name = "lblCloseText";
            this.lblCloseText.Size = new System.Drawing.Size(68, 25);
            this.lblCloseText.TabIndex = 18;
            this.lblCloseText.Text = "Close";
            this.lblCloseText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCloseText.Click += new System.EventHandler(this.lblClose_Click);
            this.lblCloseText.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            this.lblCloseText.MouseHover += new System.EventHandler(this.lblClose_MouseHover);
            // 
            // lblLoginText
            // 
            this.lblLoginText.AutoSize = true;
            this.lblLoginText.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblLoginText.ForeColor = System.Drawing.Color.White;
            this.lblLoginText.Location = new System.Drawing.Point(607, 454);
            this.lblLoginText.Name = "lblLoginText";
            this.lblLoginText.Size = new System.Drawing.Size(65, 25);
            this.lblLoginText.TabIndex = 16;
            this.lblLoginText.Text = "Login";
            this.lblLoginText.Click += new System.EventHandler(this.lblLogin_Click);
            this.lblLoginText.MouseLeave += new System.EventHandler(this.lblLogin_MouseLeave);
            this.lblLoginText.MouseHover += new System.EventHandler(this.lblLogin_MouseHover);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Location = new System.Drawing.Point(750, 445);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(148, 46);
            this.lblClose.TabIndex = 17;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            this.lblClose.MouseHover += new System.EventHandler(this.lblClose_MouseHover);
            // 
            // lblLogin
            // 
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Location = new System.Drawing.Point(554, 446);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(145, 38);
            this.lblLogin.TabIndex = 15;
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            this.lblLogin.MouseLeave += new System.EventHandler(this.lblLogin_MouseLeave);
            this.lblLogin.MouseHover += new System.EventHandler(this.lblLogin_MouseHover);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCloseText;
        private System.Windows.Forms.Label lblLoginText;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblLogin;
        private CustomControls.CustomPaddingTextBox txtPassword;
        private CustomControls.CustomPaddingTextBox txtUserName;
    }
}

