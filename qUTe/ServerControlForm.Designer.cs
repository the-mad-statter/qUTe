namespace qUTe
{
    partial class ServerControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerControlForm));
            this.label_teamid = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.comboBox_game = new System.Windows.Forms.ComboBox();
            this.textBox_teamid = new System.Windows.Forms.TextBox();
            this.label_game = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.label_serverstatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_teamid
            // 
            this.label_teamid.AutoSize = true;
            this.label_teamid.Location = new System.Drawing.Point(12, 15);
            this.label_teamid.Name = "label_teamid";
            this.label_teamid.Size = new System.Drawing.Size(51, 13);
            this.label_teamid.TabIndex = 0;
            this.label_teamid.Text = "Team ID:";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(15, 81);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Start Server";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // comboBox_game
            // 
            this.comboBox_game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_game.FormattingEnabled = true;
            this.comboBox_game.Items.AddRange(new object[] {
            "Basic Training - Practice",
            "Baseline Skill Assessment 1",
            "Baseline Skill Assessment 2",
            "Basic Training - Vehicles",
            "Basic Training - Onslaught",
            "Test Game 1 - Easy",
            "Test Game 1 - Medium",
            "Test Game 1 - Hard",
            "Test Game 2",
            "Test Game 3",
            "Test Game 4"});
            this.comboBox_game.Location = new System.Drawing.Point(69, 48);
            this.comboBox_game.MaxDropDownItems = 12;
            this.comboBox_game.Name = "comboBox_game";
            this.comboBox_game.Size = new System.Drawing.Size(175, 21);
            this.comboBox_game.TabIndex = 2;
            this.comboBox_game.SelectedIndexChanged += new System.EventHandler(this.comboBox_game_SelectedIndexChanged);
            // 
            // textBox_teamid
            // 
            this.textBox_teamid.AcceptsTab = true;
            this.textBox_teamid.Location = new System.Drawing.Point(69, 12);
            this.textBox_teamid.MaxLength = 3;
            this.textBox_teamid.Name = "textBox_teamid";
            this.textBox_teamid.Size = new System.Drawing.Size(25, 20);
            this.textBox_teamid.TabIndex = 1;
            // 
            // label_game
            // 
            this.label_game.AutoSize = true;
            this.label_game.Location = new System.Drawing.Point(12, 51);
            this.label_game.Name = "label_game";
            this.label_game.Size = new System.Drawing.Size(38, 13);
            this.label_game.TabIndex = 4;
            this.label_game.Text = "Game:";
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(169, 81);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 5;
            this.button_stop.Text = "Stop Server";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // label_serverstatus
            // 
            this.label_serverstatus.AutoSize = true;
            this.label_serverstatus.Location = new System.Drawing.Point(15, 116);
            this.label_serverstatus.Name = "label_serverstatus";
            this.label_serverstatus.Size = new System.Drawing.Size(35, 13);
            this.label_serverstatus.TabIndex = 6;
            this.label_serverstatus.Text = "label1";
            // 
            // ServerControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 141);
            this.Controls.Add(this.label_serverstatus);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.label_game);
            this.Controls.Add(this.textBox_teamid);
            this.Controls.Add(this.comboBox_game);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_teamid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerControlForm";
            this.Text = "qUTe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_teamid;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.ComboBox comboBox_game;
        private System.Windows.Forms.TextBox textBox_teamid;
        private System.Windows.Forms.Label label_game;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label_serverstatus;
    }
}

