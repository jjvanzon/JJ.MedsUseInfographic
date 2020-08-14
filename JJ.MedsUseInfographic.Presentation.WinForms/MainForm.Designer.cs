namespace JJ.MedsUseInfographic.Presentation.WinForms
{
    partial class MainForm
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
            this.diagramControl = new JJ.Framework.WinForms.Controls.DiagramControl();
            this.SuspendLayout();
            // 
            // diagramControl
            // 
            this.diagramControl.Diagram = null;
            this.diagramControl.Location = new System.Drawing.Point(13, 14);
            this.diagramControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.diagramControl.Name = "diagramControl";
            this.diagramControl.Size = new System.Drawing.Size(759, 392);
            this.diagramControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.diagramControl);
            this.Name = "MainForm";
            this.Text = "Meds Use Infographic";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.WinForms.Controls.DiagramControl diagramControl;
    }
}

