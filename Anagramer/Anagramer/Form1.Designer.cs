namespace Anagramer
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxAnagrams = new System.Windows.Forms.TextBox();
            this.textBoxMinWords = new System.Windows.Forms.TextBox();
            this.textBoxMinWordLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxWordToGetAnagramsOf = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "List All Single Word Anagrams";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxAnagrams
            // 
            this.textBoxAnagrams.Location = new System.Drawing.Point(12, 103);
            this.textBoxAnagrams.Multiline = true;
            this.textBoxAnagrams.Name = "textBoxAnagrams";
            this.textBoxAnagrams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAnagrams.Size = new System.Drawing.Size(459, 532);
            this.textBoxAnagrams.TabIndex = 1;
            // 
            // textBoxMinWords
            // 
            this.textBoxMinWords.Location = new System.Drawing.Point(93, 12);
            this.textBoxMinWords.Name = "textBoxMinWords";
            this.textBoxMinWords.Size = new System.Drawing.Size(56, 20);
            this.textBoxMinWords.TabIndex = 2;
            // 
            // textBoxMinWordLength
            // 
            this.textBoxMinWordLength.Location = new System.Drawing.Point(264, 12);
            this.textBoxMinWordLength.Name = "textBoxMinWordLength";
            this.textBoxMinWordLength.Size = new System.Drawing.Size(56, 20);
            this.textBoxMinWordLength.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min Anagrams";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Min Word Length";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "One Word Anagrams";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxWordToGetAnagramsOf
            // 
            this.textBoxWordToGetAnagramsOf.Location = new System.Drawing.Point(93, 52);
            this.textBoxWordToGetAnagramsOf.Name = "textBoxWordToGetAnagramsOf";
            this.textBoxWordToGetAnagramsOf.Size = new System.Drawing.Size(228, 20);
            this.textBoxWordToGetAnagramsOf.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Enter word(s)";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(402, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 34);
            this.button3.TabIndex = 9;
            this.button3.Text = "Multi-Word Anagrams";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 643);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxWordToGetAnagramsOf);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMinWordLength);
            this.Controls.Add(this.textBoxMinWords);
            this.Controls.Add(this.textBoxAnagrams);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxAnagrams;
        private System.Windows.Forms.TextBox textBoxMinWords;
        private System.Windows.Forms.TextBox textBoxMinWordLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxWordToGetAnagramsOf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
    }
}

