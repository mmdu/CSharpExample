namespace WindowsFormsHelloWorld
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
            this.sayhello = new System.Windows.Forms.TextBox();
            this.ShowHello = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sayhello
            // 
            this.sayhello.Location = new System.Drawing.Point(13, 3);
            this.sayhello.Name = "sayhello";
            this.sayhello.Size = new System.Drawing.Size(531, 20);
            this.sayhello.TabIndex = 0;
            // 
            // ShowHello
            // 
            this.ShowHello.Location = new System.Drawing.Point(13, 30);
            this.ShowHello.Name = "ShowHello";
            this.ShowHello.Size = new System.Drawing.Size(531, 23);
            this.ShowHello.TabIndex = 1;
            this.ShowHello.Text = "Click Me ";
            this.ShowHello.UseVisualStyleBackColor = true;
            this.ShowHello.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 249);
            this.Controls.Add(this.ShowHello);
            this.Controls.Add(this.sayhello);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sayhello;
        private System.Windows.Forms.Button ShowHello;
    }
}

