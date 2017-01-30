using System.Text;
namespace FFXIVBanlist
{
    partial class BanlistWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConsoleOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConsoleOutput
            // 
            this.ConsoleOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConsoleOutput.Location = new System.Drawing.Point(4, 30);
            this.ConsoleOutput.Name = "ConsoleOutput";
            this.ConsoleOutput.Size = new System.Drawing.Size(451, 113);
            this.ConsoleOutput.TabIndex = 0;
            this.ConsoleOutput.Text = "This is the multiline console output";
            // 
            // BanlistWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConsoleOutput);
            this.Name = "BanlistWindow";
            this.Size = new System.Drawing.Size(458, 143);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ConsoleOutput;

        private StringBuilder sb = new StringBuilder();

        public void AppendLine(string line)
        {
            sb.AppendLine(line);
            ConsoleOutput.Text = sb.ToString();
        }
    }
}
