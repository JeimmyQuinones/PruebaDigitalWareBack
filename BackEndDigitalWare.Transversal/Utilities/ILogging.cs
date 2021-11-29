using BackEndDigitalWare.Transversal.Models;
using System;
using System.Runtime.CompilerServices;

namespace BackEndDigitalWare.Transversal.Utilities
{
    public interface ILogging
    {
        void LogError(Exception exception, object SentParameters, string BusinessMessage,
           object UserData, [CallerFilePath] string nombreClass = null, [CallerMemberName] string nombreMethod = null);
        public void LogInformation(object SentParameters, object ResultParameters, string BusinessMessage,
          object UserData, [CallerFilePath] string nombreClass = null, [CallerMemberName] string nombreMethod = null);
        void LogFilter(Audit audit);

    }
}
