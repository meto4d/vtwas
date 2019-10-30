namespace vtwas
{
    partial class vtwas
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.URLlabel = new System.Windows.Forms.Label();
            this.URLtextBox = new System.Windows.Forms.TextBox();
            this.Tokenlabel = new System.Windows.Forms.Label();
            this.TokenKeytextBox = new System.Windows.Forms.TextBox();
            this.TokenKeylabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TokenPasstextBox = new System.Windows.Forms.TextBox();
            this.TokenShowCheckBox = new System.Windows.Forms.CheckBox();
            this.TokenShowToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paramlabel = new System.Windows.Forms.Label();
            this.AddListButton = new System.Windows.Forms.Button();
            this.RemoveListButton = new System.Windows.Forms.Button();
            this.CharCodeComboBox = new System.Windows.Forms.ComboBox();
            this.CharCodeLabel = new System.Windows.Forms.Label();
            this.ClipboardEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.TestRunButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SettingSaveButton = new System.Windows.Forms.Button();
            this.ClipEventCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // URLlabel
            // 
            this.URLlabel.AutoSize = true;
            this.URLlabel.Location = new System.Drawing.Point(13, 13);
            this.URLlabel.Name = "URLlabel";
            this.URLlabel.Size = new System.Drawing.Size(27, 12);
            this.URLlabel.TabIndex = 0;
            this.URLlabel.Text = "URL";
            // 
            // URLtextBox
            // 
            this.URLtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URLtextBox.Location = new System.Drawing.Point(46, 10);
            this.URLtextBox.Name = "URLtextBox";
            this.URLtextBox.Size = new System.Drawing.Size(400, 19);
            this.URLtextBox.TabIndex = 1;
            // 
            // Tokenlabel
            // 
            this.Tokenlabel.AutoSize = true;
            this.Tokenlabel.Location = new System.Drawing.Point(4, 39);
            this.Tokenlabel.Name = "Tokenlabel";
            this.Tokenlabel.Size = new System.Drawing.Size(36, 12);
            this.Tokenlabel.TabIndex = 2;
            this.Tokenlabel.Text = "Token";
            // 
            // TokenKeytextBox
            // 
            this.TokenKeytextBox.Location = new System.Drawing.Point(76, 35);
            this.TokenKeytextBox.Name = "TokenKeytextBox";
            this.TokenKeytextBox.PasswordChar = '*';
            this.TokenKeytextBox.Size = new System.Drawing.Size(120, 19);
            this.TokenKeytextBox.TabIndex = 3;
            // 
            // TokenKeylabel
            // 
            this.TokenKeylabel.AutoSize = true;
            this.TokenKeylabel.Location = new System.Drawing.Point(46, 39);
            this.TokenKeylabel.Name = "TokenKeylabel";
            this.TokenKeylabel.Size = new System.Drawing.Size(24, 12);
            this.TokenKeylabel.TabIndex = 4;
            this.TokenKeylabel.Text = "Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Password";
            // 
            // TokenPasstextBox
            // 
            this.TokenPasstextBox.Location = new System.Drawing.Point(262, 35);
            this.TokenPasstextBox.Name = "TokenPasstextBox";
            this.TokenPasstextBox.PasswordChar = '*';
            this.TokenPasstextBox.Size = new System.Drawing.Size(120, 19);
            this.TokenPasstextBox.TabIndex = 6;
            // 
            // TokenShowCheckBox
            // 
            this.TokenShowCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.TokenShowCheckBox.Location = new System.Drawing.Point(396, 35);
            this.TokenShowCheckBox.Name = "TokenShowCheckBox";
            this.TokenShowCheckBox.Size = new System.Drawing.Size(50, 22);
            this.TokenShowCheckBox.TabIndex = 7;
            this.TokenShowCheckBox.Text = "表示";
            this.TokenShowCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TokenShowToolTip.SetToolTip(this.TokenShowCheckBox, "TokenのKeyとPasswordのどちらも表示します");
            this.TokenShowCheckBox.UseVisualStyleBackColor = true;
            this.TokenShowCheckBox.CheckedChanged += new System.EventHandler(this.TokenShowCheckBox_CheckedChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView.Location = new System.Drawing.Point(46, 89);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.Size = new System.Drawing.Size(400, 83);
            this.dataGridView.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "パラメータ";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "テキスト";
            this.Column2.Name = "Column2";
            this.Column2.Width = 400;
            // 
            // Paramlabel
            // 
            this.Paramlabel.AutoSize = true;
            this.Paramlabel.Location = new System.Drawing.Point(3, 65);
            this.Paramlabel.Name = "Paramlabel";
            this.Paramlabel.Size = new System.Drawing.Size(37, 12);
            this.Paramlabel.TabIndex = 9;
            this.Paramlabel.Text = "Param";
            // 
            // AddListButton
            // 
            this.AddListButton.Location = new System.Drawing.Point(241, 60);
            this.AddListButton.Name = "AddListButton";
            this.AddListButton.Size = new System.Drawing.Size(65, 23);
            this.AddListButton.TabIndex = 10;
            this.AddListButton.Text = "行の追加";
            this.AddListButton.UseVisualStyleBackColor = true;
            this.AddListButton.Click += new System.EventHandler(this.AddListButton_Click);
            // 
            // RemoveListButton
            // 
            this.RemoveListButton.Location = new System.Drawing.Point(312, 60);
            this.RemoveListButton.Name = "RemoveListButton";
            this.RemoveListButton.Size = new System.Drawing.Size(64, 23);
            this.RemoveListButton.TabIndex = 11;
            this.RemoveListButton.Text = "行の削除";
            this.RemoveListButton.UseVisualStyleBackColor = true;
            this.RemoveListButton.Click += new System.EventHandler(this.RemoveListButton_Click);
            // 
            // CharCodeComboBox
            // 
            this.CharCodeComboBox.FormattingEnabled = true;
            this.CharCodeComboBox.Items.AddRange(new object[] {
            "UTF-8",
            "ShiftJIS",
            "EUC-JP"});
            this.CharCodeComboBox.Location = new System.Drawing.Point(106, 62);
            this.CharCodeComboBox.Name = "CharCodeComboBox";
            this.CharCodeComboBox.Size = new System.Drawing.Size(120, 20);
            this.CharCodeComboBox.TabIndex = 12;
            // 
            // CharCodeLabel
            // 
            this.CharCodeLabel.AutoSize = true;
            this.CharCodeLabel.Location = new System.Drawing.Point(44, 65);
            this.CharCodeLabel.Name = "CharCodeLabel";
            this.CharCodeLabel.Size = new System.Drawing.Size(56, 12);
            this.CharCodeLabel.TabIndex = 13;
            this.CharCodeLabel.Text = "文字コード";
            // 
            // ClipboardEnableCheckBox
            // 
            this.ClipboardEnableCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClipboardEnableCheckBox.AutoSize = true;
            this.ClipboardEnableCheckBox.Location = new System.Drawing.Point(46, 178);
            this.ClipboardEnableCheckBox.Name = "ClipboardEnableCheckBox";
            this.ClipboardEnableCheckBox.Size = new System.Drawing.Size(217, 16);
            this.ClipboardEnableCheckBox.TabIndex = 14;
            this.ClipboardEnableCheckBox.Text = "クリップボードからの置換(\\c)を有効にする";
            this.ClipboardEnableCheckBox.UseVisualStyleBackColor = true;
            this.ClipboardEnableCheckBox.CheckedChanged += new System.EventHandler(this.ClipboardEnableCheckBox_CheckedChanged);
            // 
            // TestRunButton
            // 
            this.TestRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TestRunButton.Location = new System.Drawing.Point(396, 174);
            this.TestRunButton.Name = "TestRunButton";
            this.TestRunButton.Size = new System.Drawing.Size(50, 23);
            this.TestRunButton.TabIndex = 15;
            this.TestRunButton.Text = "再生";
            this.TestRunButton.UseVisualStyleBackColor = true;
            this.TestRunButton.Click += new System.EventHandler(this.TestRunButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLabel.Location = new System.Drawing.Point(6, 174);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(34, 23);
            this.StatusLabel.TabIndex = 16;
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingSaveButton
            // 
            this.SettingSaveButton.Location = new System.Drawing.Point(382, 60);
            this.SettingSaveButton.Name = "SettingSaveButton";
            this.SettingSaveButton.Size = new System.Drawing.Size(64, 23);
            this.SettingSaveButton.TabIndex = 17;
            this.SettingSaveButton.Text = "設定保存";
            this.SettingSaveButton.UseVisualStyleBackColor = true;
            this.SettingSaveButton.Click += new System.EventHandler(this.SettingSaveButton_Click);
            // 
            // ClipEventCheckBox
            // 
            this.ClipEventCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ClipEventCheckBox.AutoSize = true;
            this.ClipEventCheckBox.Location = new System.Drawing.Point(281, 174);
            this.ClipEventCheckBox.Name = "ClipEventCheckBox";
            this.ClipEventCheckBox.Size = new System.Drawing.Size(109, 22);
            this.ClipEventCheckBox.TabIndex = 18;
            this.ClipEventCheckBox.Text = "クリップボードの監視";
            this.ClipEventCheckBox.UseVisualStyleBackColor = true;
            this.ClipEventCheckBox.CheckedChanged += new System.EventHandler(this.ClipEventCheckBox_CheckedChanged);
            // 
            // vtwas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 201);
            this.Controls.Add(this.ClipEventCheckBox);
            this.Controls.Add(this.SettingSaveButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.TestRunButton);
            this.Controls.Add(this.ClipboardEnableCheckBox);
            this.Controls.Add(this.CharCodeLabel);
            this.Controls.Add(this.CharCodeComboBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.RemoveListButton);
            this.Controls.Add(this.AddListButton);
            this.Controls.Add(this.Paramlabel);
            this.Controls.Add(this.TokenShowCheckBox);
            this.Controls.Add(this.TokenPasstextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TokenKeylabel);
            this.Controls.Add(this.TokenKeytextBox);
            this.Controls.Add(this.Tokenlabel);
            this.Controls.Add(this.URLtextBox);
            this.Controls.Add(this.URLlabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(470, 10000);
            this.MinimumSize = new System.Drawing.Size(470, 240);
            this.Name = "vtwas";
            this.Text = "vtwas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.vtwas_Closing);
            this.Load += new System.EventHandler(this.vtwas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label URLlabel;
        private System.Windows.Forms.TextBox URLtextBox;
        private System.Windows.Forms.Label Tokenlabel;
        private System.Windows.Forms.TextBox TokenKeytextBox;
        private System.Windows.Forms.Label TokenKeylabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TokenPasstextBox;
        private System.Windows.Forms.CheckBox TokenShowCheckBox;
        private System.Windows.Forms.ToolTip TokenShowToolTip;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label Paramlabel;
        private System.Windows.Forms.Button AddListButton;
        private System.Windows.Forms.Button RemoveListButton;
        private System.Windows.Forms.ComboBox CharCodeComboBox;
        private System.Windows.Forms.Label CharCodeLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.CheckBox ClipboardEnableCheckBox;
        private System.Windows.Forms.Button TestRunButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button SettingSaveButton;
        private System.Windows.Forms.CheckBox ClipEventCheckBox;
    }
}

