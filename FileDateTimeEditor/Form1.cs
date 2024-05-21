using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileDateTimeEditor.MyApplication;
using FileDateTimeEditor.Exceptions;

namespace FileDateTimeEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームが表示された直後の1回だけ実行する初期化処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            // 初期設定では更新日時だけ変更するようにする。
            // つまり、作成日時、アクセス日時を無効化する。
            this.checkBox_CreationTime.Checked = false;
            this.checkBox_LastWriteTime.Checked = true;
            this.checkBox_LastAccessTime.Checked = false;

            // テキストボックスをチェックボックスに合わせて無効化する。
            this.checkBox_CreationTime_CheckedChanged(this, e);
            this.checkBox_LastWriteTime_CheckedChanged(this, e);
            this.checkBox_LastAccessTime_CheckedChanged(this, e);
        }

        /// <summary>
        /// ドラッグされたときに実行する処理。
        /// </summary>
        /// <see cref="https://learn.microsoft.com/ja-jp/dotnet/desktop/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms?view=netframeworkdesktop-4.8"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        /// <summary>
        /// ファイルをドラッグアンドドロップされたときに実行する処理。
        /// </summary>
        /// <see cref="https://qiita.com/ANNEX_IBS/items/d9ffa76716330c0ce2b0"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                // DataFormats.FileDropを与えて、GetDataPresent()メソッドを呼び出す。
                var files = e.Data.GetData(DataFormats.FileDrop, false) as string[];

                if (files == null || files.Length < 1)
                {
                    // 想定外
                }
                else if (files.Length > 1)
                {
                    // 複数ファイルは受け付けない。
                    MessageBox.Show("複数ファイルを受け付けることはできません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // 単一ファイルの時はファイルパスを取得する。
                    var filePath = files.First();
                    this.SetFilePath(filePath);
                }
            }
        }

        /// <summary>
        /// ファイルを開くボタン押下時の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Title = "ファイルを選択してください",
                Filter = "すべてのファイル|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var filePath = ofd.FileName;
                this.SetFilePath(filePath);
            }
        }

        /// <summary>
        /// ファイルを開いたときの処理。
        /// </summary>
        /// <param name="filePath">入力ファイルパス</param>
        private void SetFilePath(string filePath)
        {
            // テキストボックスにファイルパスを入力。
            this.textBox_FilePath.Text = filePath;

            // ファイルが存在する場合は日時を入力。
            if (File.Exists(filePath) || Directory.Exists(filePath))
            {
                // パスがディレクトリか判定
                var isDirectory = File
                    .GetAttributes(filePath)
                    .HasFlag(FileAttributes.Directory);

                // ファイルまたはディレクトリの情報
                var fileDirInfo = isDirectory
                    ? new DirectoryInfo(filePath) as FileSystemInfo
                    : new FileInfo(filePath) as FileSystemInfo;

                // 作成日時、更新日時、最終アクセス日時を取得し、テキストボックスに入力
                this.textBox_CreationTime.Text = fileDirInfo.CreationTime.ToString();
                this.textBox_LastWriteTime.Text = fileDirInfo.LastWriteTime.ToString();
                this.textBox_LastAccessTime.Text = fileDirInfo.LastAccessTime.ToString();
            }
        }

        /// <summary>
        /// 作成日時のチェックボックス変化イベント。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_CreationTime_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_CreationTime.Enabled = this.checkBox_CreationTime.Checked;
        }

        /// <summary>
        /// 更新日時のチェックボックス変化イベント。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_LastWriteTime_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_LastWriteTime.Enabled = this.checkBox_LastWriteTime.Checked;
        }

        /// <summary>
        /// アクセス日時のチェックボックス変化イベント。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_LastAccessTime_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_LastAccessTime.Enabled = this.checkBox_LastAccessTime.Checked;
        }

        /// <summary>
        /// 変更ボタン押下時処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Change_Click(object sender, EventArgs e)
        {
            try
            {
                // フォームの情報をアプリに提供する。
                var app = new FileDateTime
                {
                    FilePath = textBox_FilePath.Text,
                    StringCreationTime = textBox_CreationTime.Text,
                    StringLastWriteTime = textBox_LastWriteTime.Text,
                    StringLastAccessTime = textBox_LastAccessTime.Text,
                    FlagToChangeCreationTime = checkBox_CreationTime.Checked,
                    FlagToChangeLastWriteTime = checkBox_LastWriteTime.Checked,
                    FlagToChangeLastAccessTime = checkBox_LastAccessTime.Checked
                };

                // アプリの処理を実行。
                app.ChangeFileDateTime();

                MessageBox.Show("日時を更新しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ErrorMessageException ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
