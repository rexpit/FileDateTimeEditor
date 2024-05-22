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
        /// �t�H�[�����\�����ꂽ�����1�񂾂����s���鏉���������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            // �����ݒ�ł͍X�V���������ύX����悤�ɂ���B
            // �܂�A�쐬�����A�A�N�Z�X�����𖳌�������B
            this.checkBox_CreationTime.Checked = false;
            this.checkBox_LastWriteTime.Checked = true;
            this.checkBox_LastAccessTime.Checked = false;

            // �e�L�X�g�{�b�N�X���`�F�b�N�{�b�N�X�ɍ��킹�Ė���������B
            this.checkBox_CreationTime_CheckedChanged(this, e);
            this.checkBox_LastWriteTime_CheckedChanged(this, e);
            this.checkBox_LastAccessTime_CheckedChanged(this, e);
        }

        /// <summary>
        /// �h���b�O���ꂽ�Ƃ��Ɏ��s���鏈���B
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
        /// �t�@�C�����h���b�O�A���h�h���b�v���ꂽ�Ƃ��Ɏ��s���鏈���B
        /// </summary>
        /// <see cref="https://qiita.com/ANNEX_IBS/items/d9ffa76716330c0ce2b0"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                // �h���b�O���h���b�v���ꂽ�t�@�C���p�X�ꗗ���擾�B
                var files = e.Data.GetData(DataFormats.FileDrop, false) as string[];

                if (files == null || files.Length < 1)
                {
                    // �z��O
                }
                else if (files.Length > 1)
                {
                    // �����t�@�C���͎󂯕t���Ȃ��B
                    MessageBox.Show("�����t�@�C�����󂯕t���邱�Ƃ͂ł��܂���", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // �P��t�@�C���̎��̓t�@�C���p�X���擾����B
                    var filePath = files.First();

                    // �e�L�X�g�{�b�N�X�Ƀt�@�C���p�X����́B
                    this.textBox_FilePath.Text = filePath;
                }
            }
        }

        /// <summary>
        /// �t�@�C�����J���{�^���������̏����B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            // ���łɃe�L�X�g�{�b�N�X�Ƀp�X�����͂���Ă����炻�̃t�H���_��\������B
            var oldPath = this.textBox_FilePath.Text;
            var initialDir = File.Exists(oldPath) ? Path.GetDirectoryName(oldPath)
                : Directory.Exists(oldPath) ? oldPath
                : null;

            var ofd = new OpenFileDialog
            {
                Title = "�t�@�C����I�����Ă�������",
                Filter = "���ׂẴt�@�C��|*.*",
                InitialDirectory = initialDir
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var filePath = ofd.FileName;

                // �e�L�X�g�{�b�N�X�Ƀt�@�C���p�X����́B
                this.textBox_FilePath.Text = filePath;
            }
        }

        /// <summary>
        /// �t�@�C���p�X�̃e�L�X�g�ύX���̏����B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_FilePath_TextChanged(object sender, EventArgs e)
        {
            this.SetFilePath(textBox_FilePath.Text);
        }

        /// <summary>
        /// �t�@�C�����J�����Ƃ��̏����B
        /// </summary>
        /// <param name="filePath">���̓t�@�C���p�X</param>
        private void SetFilePath(string filePath)
        {
            // �t�@�C�������݂���ꍇ�͓�������́B
            if (File.Exists(filePath) || Directory.Exists(filePath))
            {
                // �p�X���f�B���N�g��������
                var isDirectory = File
                    .GetAttributes(filePath)
                    .HasFlag(FileAttributes.Directory);

                // �t�@�C���܂��̓f�B���N�g���̏��
                FileSystemInfo fileDirInfo = isDirectory
                    ? new DirectoryInfo(filePath)
                    : new FileInfo(filePath);

                // �쐬�����A�X�V�����A�ŏI�A�N�Z�X�������擾���A�e�L�X�g�{�b�N�X�ɓ���
                this.textBox_CreationTime.Text = fileDirInfo.CreationTime.ToString();
                this.textBox_LastWriteTime.Text = fileDirInfo.LastWriteTime.ToString();
                this.textBox_LastAccessTime.Text = fileDirInfo.LastAccessTime.ToString();
            }
        }

        /// <summary>
        /// �쐬�����̃`�F�b�N�{�b�N�X�ω��C�x���g�B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_CreationTime_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_CreationTime.Enabled = this.checkBox_CreationTime.Checked;
        }

        /// <summary>
        /// �X�V�����̃`�F�b�N�{�b�N�X�ω��C�x���g�B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_LastWriteTime_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_LastWriteTime.Enabled = this.checkBox_LastWriteTime.Checked;
        }

        /// <summary>
        /// �A�N�Z�X�����̃`�F�b�N�{�b�N�X�ω��C�x���g�B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_LastAccessTime_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_LastAccessTime.Enabled = this.checkBox_LastAccessTime.Checked;
        }

        /// <summary>
        /// �ύX�{�^�������������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Change_Click(object sender, EventArgs e)
        {
            try
            {
                // �t�H�[���̏����A�v���ɒ񋟂���B
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

                // �A�v���̏��������s�B
                app.ChangeFileDateTime();

                MessageBox.Show("�������X�V���܂����B", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ErrorMessageException ex)
            {
                MessageBox.Show(ex.Message, "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
