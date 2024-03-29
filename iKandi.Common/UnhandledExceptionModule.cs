using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Security;

namespace iKandi.Common
{
    public class UnhandledExceptionModule : IHttpModule
    {

        static int _unhandledExceptionCount = 0;

        static string _sourceName = null;
        static object _initLock = new object();
        static bool _initialized = false;

        public void Init(HttpApplication app)
        {

            // Do this one time for each AppDomain.
            if (!_initialized)
            {
                lock (_initLock)
                {
                    if (!_initialized)
                    {

                        string webenginePath = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "webengine.dll");
                        ////Comment for local
                        //if (!File.Exists(webenginePath))
                        //{
                        //    throw new Exception(String.Format(CultureInfo.InvariantCulture,
                        //                                      "Failed to locate webengine.dll at '{0}'.  This module requires .NET Framework 2.0.",
                        //                                      webenginePath));
                        //}

                        //FileVersionInfo ver = FileVersionInfo.GetVersionInfo(webenginePath);
                        //_sourceName = string.Format(CultureInfo.InvariantCulture, "ASP.NET {0}.{1}.{2}.0",
                        //                            ver.FileMajorPart, ver.FileMinorPart, ver.FileBuildPart);

                        //if (!CheckIfEventLogSourceExists(_sourceName))
                        //{
                        //    throw new Exception(String.Format(CultureInfo.InvariantCulture,
                        //                                      "There is no EventLog source named '{0}'. This module requires .NET Framework 2.0.",
                        //                                      _sourceName));
                        //}
                        ////end
                        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

                        _initialized = true;
                    }
                }
            }
        }

        private bool CheckIfEventLogSourceExists(string Source)
        {
            try
            {
                return EventLog.SourceExists(Source);
            }
            catch (SecurityException ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //Vista goes here if log doesn't exists!
                return false;
            }
        }

        public void Dispose()
        {
        }

        void OnUnhandledException(object o, UnhandledExceptionEventArgs e)
        {

            try
            {
                // Let this occur one time for each AppDomain.
                if (Interlocked.Exchange(ref _unhandledExceptionCount, 1) != 0)
                    return;

                StringBuilder message = new StringBuilder("\r\n\r\nUnhandledException logged by UnhandledExceptionModule.dll:\r\n\r\nappId=");

                string appId = (string)AppDomain.CurrentDomain.GetData(".appId");
                if (appId != null)
                {
                    message.Append(appId);
                }


                Exception currentException = null;
                for (currentException = (Exception)e.ExceptionObject; currentException != null; currentException = currentException.InnerException)
                {
                    message.AppendFormat("\r\n\r\ntype={0}\r\n\r\nmessage={1}\r\n\r\nstack=\r\n{2}\r\n\r\n",
                                         currentException.GetType().FullName,
                                         currentException.Message,
                                         currentException.StackTrace);
                }

                EventLog Log = new EventLog();
                Log.Source = _sourceName;
                Log.WriteEntry(message.ToString(), EventLogEntryType.Error);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //eat it
            }
        }

    }
}