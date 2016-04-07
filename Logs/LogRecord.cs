using System;
using Minesweeper.Enum;

namespace Minesweeper.Logs
{
    public class LogRecord
    {
        public int LineId { get; set; }
        public DateTime UtcTimeStamp { get; set; }
        public int LogId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public MessageType MessageType { get; set; }
    }
}