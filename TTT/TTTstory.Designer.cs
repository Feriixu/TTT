namespace TTT
{
    partial class TTTstory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TTTstory));
            this.btnWeiter_story = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWeiter_story
            // 
            this.btnWeiter_story.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWeiter_story.Font = new System.Drawing.Font("Matura MT Script Capitals", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeiter_story.Location = new System.Drawing.Point(740, 526);
            this.btnWeiter_story.Name = "btnWeiter_story";
            this.btnWeiter_story.Size = new System.Drawing.Size(95, 30);
            this.btnWeiter_story.TabIndex = 0;
            this.btnWeiter_story.Text = "Duell!";
            this.btnWeiter_story.UseVisualStyleBackColor = true;
            this.btnWeiter_story.Click += new System.EventHandler(this.btnWeiter_story_Click);
            // 
            // TTTstory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TTT.Properties.Resources.Zwischendingsda2mitOhren1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(846, 568);
            this.ControlBox = false;
            this.Controls.Add(this.btnWeiter_story);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TTTstory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Story";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWeiter_story;
    }
}