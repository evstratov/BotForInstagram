namespace InstagramBot
{
    partial class InstagramBotForm
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
            this.login_txt = new System.Windows.Forms.TextBox();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.login_lbl = new System.Windows.Forms.Label();
            this.password_lbl = new System.Windows.Forms.Label();
            this.login_btn = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.ListBox();
            this.chk_boxLike = new System.Windows.Forms.CheckBox();
            this.chk_boxComment = new System.Windows.Forms.CheckBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.lb_ToDo = new System.Windows.Forms.Label();
            this.actoinsCount_txt = new System.Windows.Forms.TextBox();
            this.lb_actionsCount = new System.Windows.Forms.Label();
            this.lb_unfollow = new System.Windows.Forms.Label();
            this.btn_unfollow = new System.Windows.Forms.Button();
            this.chk_follow = new System.Windows.Forms.CheckBox();
            this.pictureBoxInst = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInst)).BeginInit();
            this.SuspendLayout();
            // 
            // login_txt
            // 
            this.login_txt.Location = new System.Drawing.Point(67, 29);
            this.login_txt.Name = "login_txt";
            this.login_txt.Size = new System.Drawing.Size(100, 20);
            this.login_txt.TabIndex = 0;
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(67, 56);
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '*';
            this.password_txt.Size = new System.Drawing.Size(100, 20);
            this.password_txt.TabIndex = 1;
            // 
            // login_lbl
            // 
            this.login_lbl.AutoSize = true;
            this.login_lbl.Location = new System.Drawing.Point(13, 29);
            this.login_lbl.Name = "login_lbl";
            this.login_lbl.Size = new System.Drawing.Size(36, 13);
            this.login_lbl.TabIndex = 2;
            this.login_lbl.Text = "Login:";
            // 
            // password_lbl
            // 
            this.password_lbl.AutoSize = true;
            this.password_lbl.Location = new System.Drawing.Point(10, 62);
            this.password_lbl.Name = "password_lbl";
            this.password_lbl.Size = new System.Drawing.Size(56, 13);
            this.password_lbl.TabIndex = 3;
            this.password_lbl.Text = "Password:";
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(67, 83);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(75, 23);
            this.login_btn.TabIndex = 4;
            this.login_btn.Text = "Log In";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // logBox
            // 
            this.logBox.FormattingEnabled = true;
            this.logBox.Location = new System.Drawing.Point(193, 29);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(307, 82);
            this.logBox.TabIndex = 5;
            // 
            // chk_boxLike
            // 
            this.chk_boxLike.AutoSize = true;
            this.chk_boxLike.Checked = true;
            this.chk_boxLike.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_boxLike.Location = new System.Drawing.Point(55, 208);
            this.chk_boxLike.Name = "chk_boxLike";
            this.chk_boxLike.Size = new System.Drawing.Size(82, 17);
            this.chk_boxLike.TabIndex = 6;
            this.chk_boxLike.Text = "Like Photos";
            this.chk_boxLike.UseVisualStyleBackColor = true;
            // 
            // chk_boxComment
            // 
            this.chk_boxComment.AutoSize = true;
            this.chk_boxComment.Checked = true;
            this.chk_boxComment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_boxComment.Location = new System.Drawing.Point(55, 232);
            this.chk_boxComment.Name = "chk_boxComment";
            this.chk_boxComment.Size = new System.Drawing.Size(99, 17);
            this.chk_boxComment.TabIndex = 7;
            this.chk_boxComment.Text = "Comment Posts";
            this.chk_boxComment.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Enabled = false;
            this.btn_start.Location = new System.Drawing.Point(55, 274);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 8;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lb_ToDo
            // 
            this.lb_ToDo.AutoSize = true;
            this.lb_ToDo.Location = new System.Drawing.Point(55, 189);
            this.lb_ToDo.Name = "lb_ToDo";
            this.lb_ToDo.Size = new System.Drawing.Size(103, 13);
            this.lb_ToDo.TabIndex = 9;
            this.lb_ToDo.Text = "Choose your actions";
            // 
            // actoinsCount_txt
            // 
            this.actoinsCount_txt.Location = new System.Drawing.Point(170, 153);
            this.actoinsCount_txt.Name = "actoinsCount_txt";
            this.actoinsCount_txt.Size = new System.Drawing.Size(41, 20);
            this.actoinsCount_txt.TabIndex = 11;
            this.actoinsCount_txt.Text = "20";
            // 
            // lb_actionsCount
            // 
            this.lb_actionsCount.AutoSize = true;
            this.lb_actionsCount.Location = new System.Drawing.Point(12, 156);
            this.lb_actionsCount.Name = "lb_actionsCount";
            this.lb_actionsCount.Size = new System.Drawing.Size(155, 13);
            this.lb_actionsCount.TabIndex = 12;
            this.lb_actionsCount.Text = "Number of actions per hashtag:";
            // 
            // lb_unfollow
            // 
            this.lb_unfollow.AutoSize = true;
            this.lb_unfollow.Location = new System.Drawing.Point(258, 153);
            this.lb_unfollow.Name = "lb_unfollow";
            this.lb_unfollow.Size = new System.Drawing.Size(242, 13);
            this.lb_unfollow.TabIndex = 13;
            this.lb_unfollow.Text = "Unsubscribe from everyone in the file: Unfollow.txt";
            // 
            // btn_unfollow
            // 
            this.btn_unfollow.Enabled = false;
            this.btn_unfollow.Location = new System.Drawing.Point(261, 170);
            this.btn_unfollow.Name = "btn_unfollow";
            this.btn_unfollow.Size = new System.Drawing.Size(75, 23);
            this.btn_unfollow.TabIndex = 14;
            this.btn_unfollow.Text = "Unfollow";
            this.btn_unfollow.UseVisualStyleBackColor = true;
            this.btn_unfollow.Click += new System.EventHandler(this.btn_unfollow_Click);
            // 
            // chk_follow
            // 
            this.chk_follow.AutoSize = true;
            this.chk_follow.Checked = true;
            this.chk_follow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_follow.Location = new System.Drawing.Point(55, 256);
            this.chk_follow.Name = "chk_follow";
            this.chk_follow.Size = new System.Drawing.Size(56, 17);
            this.chk_follow.TabIndex = 15;
            this.chk_follow.Text = "Follow";
            this.chk_follow.UseVisualStyleBackColor = true;
            // 
            // pictureBoxInst
            // 
            this.pictureBoxInst.Location = new System.Drawing.Point(236, 208);
            this.pictureBoxInst.Name = "pictureBoxInst";
            this.pictureBoxInst.Size = new System.Drawing.Size(320, 320);
            this.pictureBoxInst.TabIndex = 16;
            this.pictureBoxInst.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 303);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(218, 23);
            this.progressBar.TabIndex = 17;
            // 
            // InstagramBotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(586, 548);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBoxInst);
            this.Controls.Add(this.chk_follow);
            this.Controls.Add(this.btn_unfollow);
            this.Controls.Add(this.lb_unfollow);
            this.Controls.Add(this.lb_actionsCount);
            this.Controls.Add(this.actoinsCount_txt);
            this.Controls.Add(this.lb_ToDo);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.chk_boxComment);
            this.Controls.Add(this.chk_boxLike);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.password_lbl);
            this.Controls.Add(this.login_lbl);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.login_txt);
            this.Name = "InstagramBotForm";
            this.Text = "InstagramBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstagramBotForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox login_txt;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Label login_lbl;
        private System.Windows.Forms.Label password_lbl;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.CheckBox chk_boxLike;
        private System.Windows.Forms.CheckBox chk_boxComment;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lb_ToDo;
        private System.Windows.Forms.TextBox actoinsCount_txt;
        private System.Windows.Forms.Label lb_actionsCount;
        private System.Windows.Forms.Label lb_unfollow;
        private System.Windows.Forms.Button btn_unfollow;
        private System.Windows.Forms.CheckBox chk_follow;
        private System.Windows.Forms.PictureBox pictureBoxInst;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

