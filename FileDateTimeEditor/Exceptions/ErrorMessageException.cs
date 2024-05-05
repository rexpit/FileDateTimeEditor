using System;

namespace FileDateTimeEditor.Exceptions
{
    /// <summary>
    /// エラーメッセージ表示用例外クラス
    /// </summary>
    public class ErrorMessageException : Exception
    {
        public ErrorMessageException()
            : base()
        {
        }

        public ErrorMessageException(string message)
            : base(message)
        {
        }

        public ErrorMessageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
