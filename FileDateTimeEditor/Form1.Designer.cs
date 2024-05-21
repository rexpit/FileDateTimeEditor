namespace FileDateTimeEditor
{
    partial class Form1
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
            label1 = new System.Windows.Forms.Label();
            textBox_FilePath = new System.Windows.Forms.TextBox();
            button_OpenFile = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            checkBox_CreationTime = new System.Windows.Forms.CheckBox();
            textBox_CreationTime = new System.Windows.Forms.TextBox();
            checkBox_LastWriteTime = new System.Windows.Forms.CheckBox();
            textBox_LastWriteTime = new System.Windows.Forms.TextBox();
            checkBox_LastAccessTime = new System.Windows.Forms.CheckBox();
            textBox_LastAccessTime = new System.Windows.Forms.TextBox();
            button_Change = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "ファイル:";
            // 
            // textBox_FilePath
            // 
            textBox_FilePath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_FilePath.Location = new System.Drawing.Point(62, 12);
            textBox_FilePath.Name = "textBox_FilePath";
            textBox_FilePath.Size = new System.Drawing.Size(236, 23);
            textBox_FilePath.TabIndex = 1;
            // 
            // button_OpenFile
            // 
            button_OpenFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_OpenFile.Location = new System.Drawing.Point(304, 12);
            button_OpenFile.Name = "button_OpenFile";
            button_OpenFile.Size = new System.Drawing.Size(75, 23);
            button_OpenFile.TabIndex = 2;
            button_OpenFile.Text = "開く";
            button_OpenFile.UseVisualStyleBackColor = true;
            button_OpenFile.Click += button_OpenFile_Click;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label2.Location = new System.Drawing.Point(12, 49);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(367, 2);
            label2.TabIndex = 3;
            // 
            // checkBox_CreationTime
            // 
            checkBox_CreationTime.AutoSize = true;
            checkBox_CreationTime.Location = new System.Drawing.Point(12, 63);
            checkBox_CreationTime.Name = "checkBox_CreationTime";
            checkBox_CreationTime.Size = new System.Drawing.Size(74, 19);
            checkBox_CreationTime.TabIndex = 4;
            checkBox_CreationTime.Text = "作成日時";
            checkBox_CreationTime.UseVisualStyleBackColor = true;
            checkBox_CreationTime.CheckedChanged += checkBox_CreationTime_CheckedChanged;
            // 
            // textBox_CreationTime
            // 
            textBox_CreationTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_CreationTime.Location = new System.Drawing.Point(106, 63);
            textBox_CreationTime.Name = "textBox_CreationTime";
            textBox_CreationTime.Size = new System.Drawing.Size(273, 23);
            textBox_CreationTime.TabIndex = 5;
            // 
            // checkBox_LastWriteTime
            // 
            checkBox_LastWriteTime.AutoSize = true;
            checkBox_LastWriteTime.Location = new System.Drawing.Point(12, 94);
            checkBox_LastWriteTime.Name = "checkBox_LastWriteTime";
            checkBox_LastWriteTime.Size = new System.Drawing.Size(74, 19);
            checkBox_LastWriteTime.TabIndex = 6;
            checkBox_LastWriteTime.Text = "更新日時";
            checkBox_LastWriteTime.UseVisualStyleBackColor = true;
            checkBox_LastWriteTime.CheckedChanged += checkBox_LastWriteTime_CheckedChanged;
            // 
            // textBox_LastWriteTime
            // 
            textBox_LastWriteTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_LastWriteTime.Location = new System.Drawing.Point(106, 92);
            textBox_LastWriteTime.Name = "textBox_LastWriteTime";
            textBox_LastWriteTime.Size = new System.Drawing.Size(273, 23);
            textBox_LastWriteTime.TabIndex = 7;
            // 
            // checkBox_LastAccessTime
            // 
            checkBox_LastAccessTime.AutoSize = true;
            checkBox_LastAccessTime.Location = new System.Drawing.Point(12, 123);
            checkBox_LastAccessTime.Name = "checkBox_LastAccessTime";
            checkBox_LastAccessTime.Size = new System.Drawing.Size(87, 19);
            checkBox_LastAccessTime.TabIndex = 8;
            checkBox_LastAccessTime.Text = "アクセス日時";
            checkBox_LastAccessTime.UseVisualStyleBackColor = true;
            checkBox_LastAccessTime.CheckedChanged += checkBox_LastAccessTime_CheckedChanged;
            // 
            // textBox_LastAccessTime
            // 
            textBox_LastAccessTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_LastAccessTime.Location = new System.Drawing.Point(106, 122);
            textBox_LastAccessTime.Name = "textBox_LastAccessTime";
            textBox_LastAccessTime.Size = new System.Drawing.Size(273, 23);
            textBox_LastAccessTime.TabIndex = 9;
            // 
            // button_Change
            // 
            button_Change.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button_Change.Location = new System.Drawing.Point(304, 171);
            button_Change.Name = "button_Change";
            button_Change.Size = new System.Drawing.Size(75, 23);
            button_Change.TabIndex = 10;
            button_Change.Text = "変更";
            button_Change.UseVisualStyleBackColor = true;
            button_Change.Click += button_Change_Click;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(391, 206);
            Controls.Add(button_Change);
            Controls.Add(textBox_LastAccessTime);
            Controls.Add(checkBox_LastAccessTime);
            Controls.Add(textBox_LastWriteTime);
            Controls.Add(checkBox_LastWriteTime);
            Controls.Add(textBox_CreationTime);
            Controls.Add(checkBox_CreationTime);
            Controls.Add(label2);
            Controls.Add(button_OpenFile);
            Controls.Add(textBox_FilePath);
            Controls.Add(label1);
            MinimumSize = new System.Drawing.Size(400, 245);
            Name = "Form1";
            Text = "ファイル日時変更";
            Shown += Form1_Shown;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_FilePath;
        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_CreationTime;
        private System.Windows.Forms.TextBox textBox_CreationTime;
        private System.Windows.Forms.CheckBox checkBox_LastWriteTime;
        private System.Windows.Forms.TextBox textBox_LastWriteTime;
        private System.Windows.Forms.CheckBox checkBox_LastAccessTime;
        private System.Windows.Forms.TextBox textBox_LastAccessTime;
        private System.Windows.Forms.Button button_Change;
    }
}
