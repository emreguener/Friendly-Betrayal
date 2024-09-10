namespace Friendly_Betrayal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmb_Box1 = new ComboBox();
            user1 = new Label();
            user2 = new Label();
            cmb_Box2 = new ComboBox();
            user3 = new Label();
            cmb_Box3 = new ComboBox();
            user4 = new Label();
            cmb_Box4 = new ComboBox();
            BetrayalCards1 = new ListBox();
            BetrayalCards2 = new ListBox();
            BetrayalCards3 = new ListBox();
            BetrayalCards4 = new ListBox();
            revealedCards = new ListBox();
            discardedCards = new ListBox();
            btn_deal = new Button();
            label1 = new Label();
            label2 = new Label();
            comboBox_Stake = new ComboBox();
            btn_Play = new Button();
            trn = new Label();
            rnk = new Label();
            SuspendLayout();
            // 
            // cmb_Box1
            // 
            cmb_Box1.FormattingEnabled = true;
            cmb_Box1.Location = new Point(28, 48);
            cmb_Box1.Name = "cmb_Box1";
            cmb_Box1.Size = new Size(121, 23);
            cmb_Box1.TabIndex = 0;
            // 
            // user1
            // 
            user1.AutoSize = true;
            user1.Location = new Point(28, 23);
            user1.Name = "user1";
            user1.Size = new Size(36, 15);
            user1.TabIndex = 1;
            user1.Text = "User1";
            // 
            // user2
            // 
            user2.AutoSize = true;
            user2.Location = new Point(170, 21);
            user2.Name = "user2";
            user2.Size = new Size(36, 15);
            user2.TabIndex = 3;
            user2.Text = "User2";
            // 
            // cmb_Box2
            // 
            cmb_Box2.FormattingEnabled = true;
            cmb_Box2.Location = new Point(170, 48);
            cmb_Box2.Name = "cmb_Box2";
            cmb_Box2.Size = new Size(121, 23);
            cmb_Box2.TabIndex = 2;
            // 
            // user3
            // 
            user3.AutoSize = true;
            user3.Location = new Point(312, 21);
            user3.Name = "user3";
            user3.Size = new Size(36, 15);
            user3.TabIndex = 5;
            user3.Text = "User3";
            // 
            // cmb_Box3
            // 
            cmb_Box3.FormattingEnabled = true;
            cmb_Box3.Location = new Point(312, 48);
            cmb_Box3.Name = "cmb_Box3";
            cmb_Box3.Size = new Size(121, 23);
            cmb_Box3.TabIndex = 4;
            // 
            // user4
            // 
            user4.AutoSize = true;
            user4.Location = new Point(455, 21);
            user4.Name = "user4";
            user4.Size = new Size(36, 15);
            user4.TabIndex = 7;
            user4.Text = "User4";
            // 
            // cmb_Box4
            // 
            cmb_Box4.FormattingEnabled = true;
            cmb_Box4.Location = new Point(455, 48);
            cmb_Box4.Name = "cmb_Box4";
            cmb_Box4.Size = new Size(121, 23);
            cmb_Box4.TabIndex = 6;
            // 
            // BetrayalCards1
            // 
            BetrayalCards1.FormattingEnabled = true;
            BetrayalCards1.ItemHeight = 15;
            BetrayalCards1.Location = new Point(28, 94);
            BetrayalCards1.Name = "BetrayalCards1";
            BetrayalCards1.Size = new Size(121, 154);
            BetrayalCards1.TabIndex = 8;
            // 
            // BetrayalCards2
            // 
            BetrayalCards2.FormattingEnabled = true;
            BetrayalCards2.ItemHeight = 15;
            BetrayalCards2.Location = new Point(170, 94);
            BetrayalCards2.Name = "BetrayalCards2";
            BetrayalCards2.Size = new Size(121, 154);
            BetrayalCards2.TabIndex = 9;
            // 
            // BetrayalCards3
            // 
            BetrayalCards3.FormattingEnabled = true;
            BetrayalCards3.ItemHeight = 15;
            BetrayalCards3.Location = new Point(312, 94);
            BetrayalCards3.Name = "BetrayalCards3";
            BetrayalCards3.Size = new Size(121, 154);
            BetrayalCards3.TabIndex = 10;
            // 
            // BetrayalCards4
            // 
            BetrayalCards4.FormattingEnabled = true;
            BetrayalCards4.ItemHeight = 15;
            BetrayalCards4.Location = new Point(455, 94);
            BetrayalCards4.Name = "BetrayalCards4";
            BetrayalCards4.Size = new Size(121, 154);
            BetrayalCards4.TabIndex = 11;
            // 
            // revealedCards
            // 
            revealedCards.FormattingEnabled = true;
            revealedCards.ItemHeight = 15;
            revealedCards.Location = new Point(638, 48);
            revealedCards.Name = "revealedCards";
            revealedCards.Size = new Size(120, 199);
            revealedCards.TabIndex = 12;
            // 
            // discardedCards
            // 
            discardedCards.FormattingEnabled = true;
            discardedCards.ItemHeight = 15;
            discardedCards.Location = new Point(170, 254);
            discardedCards.Name = "discardedCards";
            discardedCards.Size = new Size(374, 94);
            discardedCards.TabIndex = 13;
            // 
            // btn_deal
            // 
            btn_deal.Location = new Point(28, 403);
            btn_deal.Name = "btn_deal";
            btn_deal.Size = new Size(75, 23);
            btn_deal.TabIndex = 14;
            btn_deal.Text = "Deal";
            btn_deal.UseVisualStyleBackColor = true;
            btn_deal.Click += btn_deal_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 377);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 352);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 17;
            // 
            // comboBox_Stake
            // 
            comboBox_Stake.FormattingEnabled = true;
            comboBox_Stake.Items.AddRange(new object[] { "User1", "User2", "User3", "User4" });
            comboBox_Stake.Location = new Point(312, 377);
            comboBox_Stake.Margin = new Padding(3, 2, 3, 2);
            comboBox_Stake.Name = "comboBox_Stake";
            comboBox_Stake.Size = new Size(133, 23);
            comboBox_Stake.TabIndex = 18;
            // 
            // btn_Play
            // 
            btn_Play.Location = new Point(333, 404);
            btn_Play.Margin = new Padding(3, 2, 3, 2);
            btn_Play.Name = "btn_Play";
            btn_Play.Size = new Size(82, 22);
            btn_Play.TabIndex = 19;
            btn_Play.Text = "Play";
            btn_Play.UseVisualStyleBackColor = true;
            btn_Play.Click += btn_Play_Click;
            // 
            // trn
            // 
            trn.AutoSize = true;
            trn.Location = new Point(638, 21);
            trn.Name = "trn";
            trn.Size = new Size(37, 15);
            trn.TabIndex = 20;
            trn.Text = "Turn: ";
            // 
            // rnk
            // 
            rnk.AutoSize = true;
            rnk.Location = new Point(638, 282);
            rnk.Name = "rnk";
            rnk.Size = new Size(53, 15);
            rnk.TabIndex = 21;
            rnk.Text = "Ranking:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rnk);
            Controls.Add(trn);
            Controls.Add(btn_Play);
            Controls.Add(comboBox_Stake);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_deal);
            Controls.Add(discardedCards);
            Controls.Add(revealedCards);
            Controls.Add(BetrayalCards4);
            Controls.Add(BetrayalCards3);
            Controls.Add(BetrayalCards2);
            Controls.Add(BetrayalCards1);
            Controls.Add(user4);
            Controls.Add(cmb_Box4);
            Controls.Add(user3);
            Controls.Add(cmb_Box3);
            Controls.Add(user2);
            Controls.Add(cmb_Box2);
            Controls.Add(user1);
            Controls.Add(cmb_Box1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmb_Box1;
        private Label user1;
        private Label user2;
        private ComboBox cmb_Box2;
        private Label user3;
        private ComboBox cmb_Box3;
        private Label user4;
        private ComboBox cmb_Box4;
        private ListBox BetrayalCards1;
        private ListBox BetrayalCards2;
        private ListBox BetrayalCards3;
        private ListBox BetrayalCards4;
        private ListBox revealedCards;
        private ListBox discardedCards;
        private Button btn_deal;
        private Label label1;
        private Label label2;
        private ComboBox comboBox_Stake;
        private Button btn_Play;
        private Label trn;
        private Label rnk;
    }
}
