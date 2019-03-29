namespace Arrowgene.StepFile.Gui
{
    using Arrowgene.StepFile.Gui.Core;
    using Arrowgene.StepFile.Gui.Plugin;
    using Arrowgene.StepFile.Gui.Windows.Main;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;

    public class App : Application
    {
        private const string SETTINGS_FILE_NAME = "arrowgene_stepfile.settings";
        private const string LOG_FILE_NAME = "arrowgene_stepfile.log";

        public static Window Window => _mainWindow.Window;
        private static IMainWindow _mainWindow;
        private static MainController _controller;
        private static object _progressOwner;

        [STAThread]
        public static void Main()
        {
            SetLanguage(LanguageType.English);
            PluginRegistry.Instance.Load("./Plugin");
            _mainWindow = new MainWindow();
            _controller = new MainController(_mainWindow);
            App app = new App();
            app.Run(_mainWindow.Window);
        }

        public static void SetLanguage(LanguageType language)
        {
            string lang = "";
            switch (language)
            {
                case LanguageType.English:
                    lang = "en-US";
                    break;
                case LanguageType.Korean:
                    lang = "ko-KR";
                    break;
                default:
                    return;
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
        }

        public static void ResetProgress(object owner)
        {
            _mainWindow.ProgressBarText = "";
            _mainWindow.ProgressBarValue = 0;
            _progressOwner = null;
        }

        public static void UpdateProgress(object owner, int progress, string status = "")
        {
            if (_progressOwner == null || _progressOwner == owner)
            {
                _progressOwner = owner;
                _mainWindow.ProgressBarText = status;
                _mainWindow.ProgressBarValue = progress;
            }
        }

        public static string GetApplicationDir()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public static string GetApplicationFileName()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetFileName(path);
        }

        public static string CreateMD5(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        public static FileInfo CreateFileInfo(string path)
        {
            FileInfo info;
            try
            {
                info = new FileInfo(path);
            }
            catch (Exception)
            {
                info = null;
            }
            return info;
        }
        public static DirectoryInfo CreateDirectoryInfo(string path)
        {
            DirectoryInfo info;
            try
            {
                info = new DirectoryInfo(path);
            }
            catch (Exception)
            {
                info = null;
            }
            return info;
        }

        public static string GetConfigPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), SETTINGS_FILE_NAME);
        }

        public static string GetLogPath()
        {

            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), LOG_FILE_NAME);
        }

        public static void Dispatch(Action action)
        {
            if (_mainWindow.Window.Dispatcher.CheckAccess())
            {
                action.Invoke();
            }
            else
            {
                _mainWindow.Window.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
            }
        }

        public App()
        {

        }
    }
}
