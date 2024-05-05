using FileDateTimeEditor.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDateTimeEditor.MyApplication
{
    internal class FileDateTime
    {
        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; set; } = "";

        /// <summary>
        /// 作成日時文字列
        /// </summary>
        public string StringCreationTime { get; set; } = "";

        /// <summary>
        /// 更新日時文字列
        /// </summary>
        public string StringLastWriteTime { get; set; } = "";

        /// <summary>
        /// アクセス日時文字列
        /// </summary>
        public string StringLastAccessTime { get; set; } = "";

        /// <summary>
        /// 作成日時を変更するフラグ
        /// </summary>
        public bool FlagToChangeCreationTime { get; set; } = false;

        /// <summary>
        /// 更新日時を変更するフラグ
        /// </summary>
        public bool FlagToChangeLastWriteTime { get; set; } = false;

        /// <summary>
        /// アクセス日時を変更するフラグ
        /// </summary>
        public bool FlagToChangeLastAccessTime { get; set; } = false;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public FileDateTime()
        {
        }

        /// <summary>
        /// 指定のファイルについて各種日時を変更する。
        /// </summary>
        public void ChangeFileDateTime()
        {
            // エラーチェック
            CheckErrorForChangingFileDateTime();

            // パスがディレクトリか判定
            var isDirectory = File
                .GetAttributes(this.FilePath)
                .HasFlag(FileAttributes.Directory);

            // ファイル作成日時変更
            if (this.FlagToChangeCreationTime)
            {
                var dt = DateTime.Parse(this.StringCreationTime);

                // ファイルの時
                if (!isDirectory)
                {
                    File.SetCreationTime(this.FilePath, dt);
                }
                // ディレクトリの時
                else
                {
                    Directory.SetCreationTime(this.FilePath, dt);
                }
            }

            // ファイル更新日時変更
            if (this.FlagToChangeLastWriteTime)
            {
                var dt = DateTime.Parse(this.StringLastWriteTime);

                // ファイルの時
                if (!isDirectory)
                {
                    File.SetLastWriteTime(this.FilePath, dt);
                }
                // ディレクトリの時
                else
                {
                    Directory.SetLastWriteTime(this.FilePath, dt);
                }
            }

            // ファイルアクセス日時変更
            if (this.FlagToChangeLastAccessTime)
            {
                var dt = DateTime.Parse(this.StringLastAccessTime);

                // ファイルの時
                if (!isDirectory)
                {
                    File.SetLastAccessTime(this.FilePath, dt);
                }
                // ディレクトリの時
                else
                {
                    Directory.SetLastAccessTime(this.FilePath, dt);
                }
            }
        }

        /// <summary>
        /// エラーチェック。
        /// </summary>
        /// <exception cref="ErrorMessageException"></exception>
        private void CheckErrorForChangingFileDateTime()
        {
            if (string.IsNullOrEmpty(this.FilePath))
            {
                throw new ErrorMessageException("ファイルを指定してください。");
            }

            if (!File.Exists(this.FilePath)
                && !Directory.Exists(this.FilePath))
            {
                throw new ErrorMessageException("ファイルが見つかりません。");
            }

            if (!this.FlagToChangeCreationTime
                && !this.FlagToChangeLastWriteTime
                && !this.FlagToChangeLastAccessTime)
            {
                throw new ErrorMessageException("変更する項目にチェックしてください。");
            }

            if (this.FlagToChangeCreationTime
                && !DateTime.TryParse(this.StringCreationTime, out _))
            {
                throw new ErrorMessageException("作成日時のフォーマットが不正です。");
            }

            if (this.FlagToChangeLastWriteTime
                && !DateTime.TryParse(this.StringLastWriteTime, out _))
            {
                throw new ErrorMessageException("更新日時のフォーマットが不正です。");
            }

            if (this.FlagToChangeLastAccessTime
                && !DateTime.TryParse(this.StringLastAccessTime, out _))
            {
                throw new ErrorMessageException("アクセス日時のフォーマットが不正です。");
            }
        }
    }
}
