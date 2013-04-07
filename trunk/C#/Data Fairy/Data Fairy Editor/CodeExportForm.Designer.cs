namespace Data_Fairy_Editor
{
    partial class CodeExportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.packageTextInput = new System.Windows.Forms.TextBox();
            this.commandButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.exportButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.outputDirectoryInput = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.templateComboBox = new System.Windows.Forms.ComboBox();
            this.reportBox = new System.Windows.Forms.TextBox();
            this.commandButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Language Template";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Package";
            // 
            // packageTextInput
            // 
            this.packageTextInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.packageTextInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packageTextInput.Location = new System.Drawing.Point(169, 51);
            this.packageTextInput.Name = "packageTextInput";
            this.packageTextInput.Size = new System.Drawing.Size(283, 26);
            this.packageTextInput.TabIndex = 3;
            // 
            // commandButtonsPanel
            // 
            this.commandButtonsPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.commandButtonsPanel.Controls.Add(this.exportButton);
            this.commandButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.commandButtonsPanel.Location = new System.Drawing.Point(0, 231);
            this.commandButtonsPanel.Name = "commandButtonsPanel";
            this.commandButtonsPanel.Size = new System.Drawing.Size(464, 50);
            this.commandButtonsPanel.TabIndex = 15;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(309, 5);
            this.exportButton.Margin = new System.Windows.Forms.Padding(5);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(150, 40);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Output Directory";
            // 
            // outputDirectoryInput
            // 
            this.outputDirectoryInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDirectoryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputDirectoryInput.Location = new System.Drawing.Point(169, 88);
            this.outputDirectoryInput.Name = "outputDirectoryInput";
            this.outputDirectoryInput.Size = new System.Drawing.Size(209, 26);
            this.outputDirectoryInput.TabIndex = 17;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(384, 89);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(68, 25);
            this.browseButton.TabIndex = 18;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // templateComboBox
            // 
            this.templateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.templateComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateComboBox.FormattingEnabled = true;
            this.templateComboBox.Location = new System.Drawing.Point(169, 12);
            this.templateComboBox.Name = "templateComboBox";
            this.templateComboBox.Size = new System.Drawing.Size(283, 28);
            this.templateComboBox.TabIndex = 0;
            // 
            // reportBox
            // 
            this.reportBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.reportBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBox.Location = new System.Drawing.Point(12, 125);
            this.reportBox.MinimumSize = new System.Drawing.Size(100, 50);
            this.reportBox.Multiline = true;
            this.reportBox.Name = "reportBox";
            this.reportBox.ReadOnly = true;
            this.reportBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reportBox.Size = new System.Drawing.Size(440, 95);
            this.reportBox.TabIndex = 19;
            this.reportBox.Text = "Output report";
            this.reportBox.WordWrap = false;
            // 
            // CodeExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.reportBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.outputDirectoryInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commandButtonsPanel);
            this.Controls.Add(this.packageTextInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.templateComboBox);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "CodeExportForm";
            this.Text = "Export Code";
            this.commandButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox packageTextInput;
        private System.Windows.Forms.FlowLayoutPanel commandButtonsPanel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputDirectoryInput;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.ComboBox templateComboBox;
        private System.Windows.Forms.TextBox reportBox;
    }
}