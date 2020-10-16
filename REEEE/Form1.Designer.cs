namespace REEEE {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.playerTurn = new System.Windows.Forms.Label();
            this.new_game = new System.Windows.Forms.Button();
            this.help_button = new System.Windows.Forms.Button();
            this.blue_discs = new System.Windows.Forms.Label();
            this.red_discs = new System.Windows.Forms.Label();
            this.num_blue = new System.Windows.Forms.Label();
            this.num_red = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(254, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 481);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // playerTurn
            // 
            this.playerTurn.AutoSize = true;
            this.playerTurn.Location = new System.Drawing.Point(49, 42);
            this.playerTurn.Name = "playerTurn";
            this.playerTurn.Size = new System.Drawing.Size(68, 17);
            this.playerTurn.TabIndex = 1;
            this.playerTurn.Text = "Start spel";
            // 
            // new_game
            // 
            this.new_game.Location = new System.Drawing.Point(32, 92);
            this.new_game.Name = "new_game";
            this.new_game.Size = new System.Drawing.Size(105, 29);
            this.new_game.TabIndex = 2;
            this.new_game.Text = "Nieuw Spel";
            this.new_game.UseVisualStyleBackColor = true;
            this.new_game.Click += new System.EventHandler(this.new_game_Click);
            // 
            // help_button
            // 
            this.help_button.Location = new System.Drawing.Point(32, 148);
            this.help_button.Name = "help_button";
            this.help_button.Size = new System.Drawing.Size(105, 29);
            this.help_button.TabIndex = 3;
            this.help_button.Text = "Help";
            this.help_button.UseVisualStyleBackColor = true;
            this.help_button.Click += new System.EventHandler(this.help_button_Click);
            // 
            // blue_discs
            // 
            this.blue_discs.AutoSize = true;
            this.blue_discs.Location = new System.Drawing.Point(32, 231);
            this.blue_discs.Name = "blue_discs";
            this.blue_discs.Size = new System.Drawing.Size(96, 17);
            this.blue_discs.TabIndex = 4;
            this.blue_discs.Text = "Blauw stenen:";
            // 
            // red_discs
            // 
            this.red_discs.AutoSize = true;
            this.red_discs.Location = new System.Drawing.Point(32, 271);
            this.red_discs.Name = "red_discs";
            this.red_discs.Size = new System.Drawing.Size(93, 17);
            this.red_discs.TabIndex = 5;
            this.red_discs.Text = "Rood stenen:";
            // 
            // num_blue
            // 
            this.num_blue.AutoSize = true;
            this.num_blue.Location = new System.Drawing.Point(145, 231);
            this.num_blue.Name = "num_blue";
            this.num_blue.Size = new System.Drawing.Size(16, 17);
            this.num_blue.TabIndex = 6;
            this.num_blue.Text = "0";
            // 
            // num_red
            // 
            this.num_red.AutoSize = true;
            this.num_red.Location = new System.Drawing.Point(145, 271);
            this.num_red.Name = "num_red";
            this.num_red.Size = new System.Drawing.Size(16, 17);
            this.num_red.TabIndex = 7;
            this.num_red.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 505);
            this.Controls.Add(this.num_red);
            this.Controls.Add(this.num_blue);
            this.Controls.Add(this.red_discs);
            this.Controls.Add(this.blue_discs);
            this.Controls.Add(this.help_button);
            this.Controls.Add(this.new_game);
            this.Controls.Add(this.playerTurn);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label playerTurn;
        private System.Windows.Forms.Button new_game;
        private System.Windows.Forms.Button help_button;
        private System.Windows.Forms.Label blue_discs;
        private System.Windows.Forms.Label red_discs;
        private System.Windows.Forms.Label num_blue;
        private System.Windows.Forms.Label num_red;
    }
}

