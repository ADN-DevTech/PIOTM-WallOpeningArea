namespace ADNPlugin.Revit.WallOpeningArea
{
    partial class SearchConfigForm
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
          this.btnOK = new System.Windows.Forms.Button();
          this.btnCancel = new System.Windows.Forms.Button();
          this.label1 = new System.Windows.Forms.Label();
          this.txtArea = new System.Windows.Forms.NumericUpDown();
          this.lblUnitName = new System.Windows.Forms.Label();
          this.btnAbout = new System.Windows.Forms.Button();
          ((System.ComponentModel.ISupportInitialize)(this.txtArea)).BeginInit();
          this.SuspendLayout();
          // 
          // btnOK
          // 
          this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.btnOK.Location = new System.Drawing.Point(190, 104);
          this.btnOK.Name = "btnOK";
          this.btnOK.Size = new System.Drawing.Size(75, 23);
          this.btnOK.TabIndex = 0;
          this.btnOK.Text = "OK";
          this.btnOK.UseVisualStyleBackColor = true;
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // btnCancel
          // 
          this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancel.Location = new System.Drawing.Point(271, 104);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(75, 23);
          this.btnCancel.TabIndex = 1;
          this.btnCancel.Text = "Cancel";
          this.btnCancel.UseVisualStyleBackColor = true;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(12, 28);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(175, 13);
          this.label1.TabIndex = 2;
          this.label1.Text = "Compute wall openings smaller than";
          // 
          // txtArea
          // 
          this.txtArea.DecimalPlaces = 2;
          this.txtArea.Location = new System.Drawing.Point(194, 24);
          this.txtArea.Name = "txtArea";
          this.txtArea.Size = new System.Drawing.Size(49, 20);
          this.txtArea.TabIndex = 3;
          // 
          // lblUnitName
          // 
          this.lblUnitName.AutoSize = true;
          this.lblUnitName.Location = new System.Drawing.Point(250, 28);
          this.lblUnitName.Name = "lblUnitName";
          this.lblUnitName.Size = new System.Drawing.Size(35, 13);
          this.lblUnitName.TabIndex = 4;
          this.lblUnitName.Text = "label2";
          // 
          // btnAbout
          // 
          this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
          this.btnAbout.Location = new System.Drawing.Point(13, 104);
          this.btnAbout.Name = "btnAbout";
          this.btnAbout.Size = new System.Drawing.Size(75, 23);
          this.btnAbout.TabIndex = 5;
          this.btnAbout.Text = "About";
          this.btnAbout.UseVisualStyleBackColor = true;
          this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
          // 
          // SearchConfigForm
          // 
          this.AcceptButton = this.btnOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this.btnCancel;
          this.ClientSize = new System.Drawing.Size(358, 139);
          this.Controls.Add(this.btnAbout);
          this.Controls.Add(this.lblUnitName);
          this.Controls.Add(this.txtArea);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.btnCancel);
          this.Controls.Add(this.btnOK);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "SearchConfigForm";
          this.ShowInTaskbar = false;
          this.Text = "Configure wall opening search";
          this.Load += new System.EventHandler(this.Config_Load);
          ((System.ComponentModel.ISupportInitialize)(this.txtArea)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtArea;
        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.Button btnAbout;
    }
}