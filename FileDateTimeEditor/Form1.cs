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
            checkBox_CreationTime.Checked = false;
            checkBox_LastWriteTime.Checked = true;
            checkBox_LastAccessTime.Checked = false;

            // �e�L�X�g�{�b�N�X���`�F�b�N�{�b�N�X�ɍ��킹�Ė���������B
            textBox_CreationTime.Enabled = false;
            textBox_LastAccessTime.Enabled = false;
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
                // DataFormats.FileDrop��^���āAGetDataPresent()���\�b�h���Ăяo���B
                var files = e.Data.GetData(DataFormats.FileDrop, false) as string[];

                if (files == null || files.Length < 1)
                {
                    // �z��O
                    return;
                }
                else if (files.Length > 1)
                {
                    // �����t�@�C���͎󂯕t���Ȃ��B
                    return;
                }
                else
                {
                    // �P��t�@�C���̎��̓t�@�C���p�X���擾����B
                    var filePath = files[0];
                    SetFilePath(filePath);
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
            var ofd = new OpenFileDialog
            {
                Title = "�t�@�C����I�����Ă�������",
                Filter = "���ׂẴt�@�C��|*.*|�t�H���_|."
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var filePath = ofd.FileName;
                SetFilePath(filePath);
            }
        }

        /// <summary>
        /// �t�@�C�����J�����Ƃ��̏����B
        /// </summary>
        /// <param name="filePath">���̓t�@�C���p�X</param>
        private void SetFilePath(string filePath)
        {
            // �e�L�X�g�{�b�N�X�Ƀt�@�C���p�X����́B
            textBox_FilePath.Text = filePath;

            // �t�@�C�������݂���ꍇ�͓�������́B
            if (File.Exists(filePath))
            {
                var dt_creationTime = File.GetCreationTime(filePath);
                var dt_lastWriteTime = File.GetLastWriteTime(filePath);
                var dt_lastAccessTime = File.GetLastAccessTime(filePath);

                var str_creationTime = dt_creationTime.ToString();
                var str_lastWriteTime = dt_lastWriteTime.ToString();
                var str_lastAccessTime = dt_lastAccessTime.ToString();

                textBox_CreationTime.Text = str_creationTime.ToString();
                textBox_LastWriteTime.Text = str_lastWriteTime.ToString();
                textBox_LastAccessTime.Text = str_lastAccessTime.ToString();
            }
        }

        /// <summary>
        /// �쐬�����̃`�F�b�N�{�b�N�X�ω��C�x���g�B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_CreationTime_CheckedChanged(object sender, EventArgs e)
        {
            textBox_CreationTime.Enabled = checkBox_CreationTime.Checked;
        }

        /// <summary>
        /// �X�V�����̃`�F�b�N�{�b�N�X�ω��C�x���g�B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_LastWriteTime_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LastWriteTime.Enabled = checkBox_LastWriteTime.Checked;
        }

        /// <summary>
        /// �A�N�Z�X�����̃`�F�b�N�{�b�N�X�ω��C�x���g�B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_LastAccessTime_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LastAccessTime.Enabled = checkBox_LastAccessTime.Checked;
        }

        /// <summary>
        /// �ύX�{�^�������������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Change_Click(object sender, EventArgs e)
        {
            // �G���[�`�F�b�N
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
