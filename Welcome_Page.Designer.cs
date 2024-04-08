
namespace restaurant_automation
{
    partial class Welcome_Page
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
            this.admin_login = new System.Windows.Forms.Button();
            this.worker_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // admin_login
            // 
            this.admin_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.admin_login.BackgroundImage = global::restaurant_automation.Properties.Resources.system_administrator_female;
            this.admin_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.admin_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.admin_login.ForeColor = System.Drawing.Color.Transparent;
            this.admin_login.Location = new System.Drawing.Point(250, 108);
            this.admin_login.Name = "admin_login";
            this.admin_login.Size = new System.Drawing.Size(200, 125);
            this.admin_login.TabIndex = 2;
            this.admin_login.Text = "ADMIN LOGIN";
            this.admin_login.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.admin_login.UseVisualStyleBackColor = false;
            this.admin_login.Click += new System.EventHandler(this.admin_login_Click);
            // 
            // worker_login
            // 
            this.worker_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.worker_login.BackgroundImage = global::restaurant_automation.Properties.Resources.admin_settings_male;
            this.worker_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.worker_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.worker_login.ForeColor = System.Drawing.Color.Transparent;
            this.worker_login.Location = new System.Drawing.Point(570, 108);
            this.worker_login.Name = "worker_login";
            this.worker_login.Size = new System.Drawing.Size(200, 125);
            this.worker_login.TabIndex = 3;
            this.worker_login.Text = "WORKER LOGIN";
            this.worker_login.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.worker_login.UseVisualStyleBackColor = false;
            this.worker_login.Click += new System.EventHandler(this.worker_login_Click);
            // 
            // Welcome_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::restaurant_automation.Properties.Resources.pexels_elina_sazonova_1850600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.worker_login);
            this.Controls.Add(this.admin_login);
            this.Name = "Welcome_Page";
            this.Text = "App";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button admin_login;
        private System.Windows.Forms.Button worker_login;
    }
}