namespace FileDateTimeEditor
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
            label1 = new Label();
            textBox_FilePath = new TextBox();
            button_OpenFile = new Button();
            label2 = new Label();
            checkBox_CreationTime = new CheckBox();
            textBox_CreationTime = new TextBox();
            checkBox_LastWriteTime = new CheckBox();
            textBox_LastWriteTime = new TextBox();
            checkBox_LastAccessTime = new CheckBox();
            textBox_LastAccessTime = new TextBox();
            button_Change = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "ファイル:";
            // 
            // textBox_FilePath
            // 
            textBox_FilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_FilePath.Location = new Point(62, 12);
            textBox_FilePath.Name = "textBox_FilePath";
            textBox_FilePath.Size = new Size(236, 23);
            textBox_FilePath.TabIndex = 1;
            textBox_FilePath.TextChanged += textBox_FilePath_TextChanged;
            // 
            // button_OpenFile
            // 
            button_OpenFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_OpenFile.Location = new Point(304, 12);
            button_OpenFile.Name = "button_OpenFile";
            button_OpenFile.Size = new Size(75, 23);
            button_OpenFile.TabIndex = 2;
            button_OpenFile.Text = "開く";
            button_OpenFile.UseVisualStyleBackColor = true;
            button_OpenFile.Click += button_OpenFile_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(367, 2);
            label2.TabIndex = 3;
            // 
            // checkBox_CreationTime
            // 
            checkBox_CreationTime.AutoSize = true;
            checkBox_CreationTime.Location = new Point(12, 63);
            checkBox_CreationTime.Name = "checkBox_CreationTime";
            checkBox_CreationTime.Size = new Size(74, 19);
            checkBox_CreationTime.TabIndex = 4;
            checkBox_CreationTime.Text = "作成日時";
            checkBox_CreationTime.UseVisualStyleBackColor = true;
            checkBox_CreationTime.CheckedChanged += checkBox_CreationTime_CheckedChanged;
            // 
            // textBox_CreationTime
            // 
            textBox_CreationTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_CreationTime.Location = new Point(106, 63);
            textBox_CreationTime.Name = "textBox_CreationTime";
            textBox_CreationTime.Size = new Size(273, 23);
            textBox_CreationTime.TabIndex = 5;
            // 
            // checkBox_LastWriteTime
            // 
            checkBox_LastWriteTime.AutoSize = true;
            checkBox_LastWriteTime.Location = new Point(12, 94);
            checkBox_LastWriteTime.Name = "checkBox_LastWriteTime";
            checkBox_LastWriteTime.Size = new Size(74, 19);
            checkBox_LastWriteTime.TabIndex = 6;
            checkBox_LastWriteTime.Text = "更新日時";
            checkBox_LastWriteTime.UseVisualStyleBackColor = true;
            checkBox_LastWriteTime.CheckedChanged += checkBox_LastWriteTime_CheckedChanged;
            // 
            // textBox_LastWriteTime
            // 
            textBox_LastWriteTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_LastWriteTime.Location = new Point(106, 92);
            textBox_LastWriteTime.Name = "textBox_LastWriteTime";
            textBox_LastWriteTime.Size = new Size(273, 23);
            textBox_LastWriteTime.TabIndex = 7;
            // 
            // checkBox_LastAccessTime
            // 
            checkBox_LastAccessTime.AutoSize = true;
            checkBox_LastAccessTime.Location = new Point(12, 123);
            checkBox_LastAccessTime.Name = "checkBox_LastAccessTime";
            checkBox_LastAccessTime.Size = new Size(87, 19);
            checkBox_LastAccessTime.TabIndex = 8;
            checkBox_LastAccessTime.Text = "アクセス日時";
            checkBox_LastAccessTime.UseVisualStyleBackColor = true;
            checkBox_LastAccessTime.CheckedChanged += checkBox_LastAccessTime_CheckedChanged;
            // 
            // textBox_LastAccessTime
            // 
            textBox_LastAccessTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_LastAccessTime.Location = new Point(106, 122);
            textBox_LastAccessTime.Name = "textBox_LastAccessTime";
            textBox_LastAccessTime.Size = new Size(273, 23);
            textBox_LastAccessTime.TabIndex = 9;
            // 
            // button_Change
            // 
            button_Change.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Change.Location = new Point(304, 171);
            button_Change.Name = "button_Change";
            button_Change.Size = new Size(75, 23);
            button_Change.TabIndex = 10;
            button_Change.Text = "変更";
            button_Change.UseVisualStyleBackColor = true;
            button_Change.Click += button_Change_Click;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 206);
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
            MinimumSize = new Size(400, 245);
            Name = "Form1";
            Text = "ファイル日時変更";
            Shown += Form1_Shown;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_FilePath;
        private Button button_OpenFile;
        private Label label2;
        private CheckBox checkBox_CreationTime;
        private TextBox textBox_CreationTime;
        private CheckBox checkBox_LastWriteTime;
        private TextBox textBox_LastWriteTime;
        private CheckBox checkBox_LastAccessTime;
        private TextBox textBox_LastAccessTime;
        private Button button_Change;
    }
}
