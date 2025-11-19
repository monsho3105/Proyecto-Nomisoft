namespace Proyecto_Nomisoft
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnMinimzar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimzar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(113)))), ((int)(((byte)(129)))));
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtUser.Location = new System.Drawing.Point(1426, 342);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(346, 40);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "USUARIO";
            this.txtUser.TextChanged += new System.EventHandler(this.TxtUser_TextChanged);
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            this.txtUser.MouseEnter += new System.EventHandler(this.txtUser_MouseEnter);
            this.txtUser.MouseLeave += new System.EventHandler(this.txtUser_MouseLeave);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(113)))), ((int)(((byte)(129)))));
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtPass.Location = new System.Drawing.Point(1426, 421);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPass.Multiline = true;
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(346, 42);
            this.txtPass.TabIndex = 2;
            this.txtPass.Text = "CONTRASEÑA";
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged_1);
            this.txtPass.Enter += new System.EventHandler(this.txtPass_Enter);
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            this.txtPass.Leave += new System.EventHandler(this.txtUser_Leave);
            // 
            // btnAcceder
            // 
            this.btnAcceder.BackColor = System.Drawing.Color.Transparent;
            this.btnAcceder.FlatAppearance.BorderSize = 0;
            this.btnAcceder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAcceder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAcceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceder.Font = new System.Drawing.Font("MV Boli", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceder.ForeColor = System.Drawing.Color.Transparent;
            this.btnAcceder.Location = new System.Drawing.Point(1415, 515);
            this.btnAcceder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(335, 60);
            this.btnAcceder.TabIndex = 3;
            this.btnAcceder.UseVisualStyleBackColor = false;
            this.btnAcceder.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.Location = new System.Drawing.Point(531, 398);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 16);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnMinimzar
            // 
            this.btnMinimzar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimzar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimzar.Image")));
            this.btnMinimzar.Location = new System.Drawing.Point(1824, 43);
            this.btnMinimzar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMinimzar.Name = "btnMinimzar";
            this.btnMinimzar.Size = new System.Drawing.Size(44, 40);
            this.btnMinimzar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimzar.TabIndex = 6;
            this.btnMinimzar.TabStop = false;
            this.btnMinimzar.Click += new System.EventHandler(this.btnMinimzar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1874, 43);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(41, 40);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1927, 586);
            this.Controls.Add(this.btnMinimzar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnAcceder);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimzar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMinimzar;
    }
}

