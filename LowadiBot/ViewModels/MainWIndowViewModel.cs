using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LowadiBot.Infrastructure.Commands;
using LowadiBot.ViewModels.Base;

namespace LowadiBot.ViewModels
{
    internal class MainWIndowViewModel : ViewModel
    {
        private string _title = "Howrse-Lowadi Bot";

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title {
            get => _title;
            set => Set(ref _title, value);
        }

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region FormWindowStateCommand
        public ICommand FormWindowStateMaximizedCommand { get; set; }

        private bool CanFormWindowStateMaximizedCommandExecute(object p) => true;

        private void OnFormWindowStateMaximizedCommandExecuted(object p)
        {
            Application.Current.MainWindow.WindowState ^= WindowState.Maximized;
            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        #endregion

        #region FormWindowsMinimizeCommand
        public ICommand FormWindowsMinimizedCommand { get; set; }

        private bool CanFormWindowsMinimizedCommandExecute(object parameter) => true;

        private void OnFormWindowsMinimizedCommandExecute(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }


        #endregion

        #region MenuCommand

        public ICommand MenuCommand { get; set; }

        private bool CanMenuCommandExecute(object parameter) => true;

        private void OnMenuCommandExecute(object parameter)
        {
            var position = Mouse.GetPosition(Application.Current.MainWindow);
            var point = new Point(position.X + Application.Current.MainWindow.Left, position.Y + Application.Current.MainWindow.Top);

            SystemCommands.ShowSystemMenu(Application.Current.MainWindow, point);
        }

        #endregion

        #region SelectLanguage
        public ICommand SelectLanguage { get; set; }

        private bool CanSelectLanguageExecute(object p) => true;

        private void OnSelectLanguageExecuted(object p)
        {
            if (MessageBox.Show("Приложение будет перезапущено", "Изменить язык", MessageBoxButton.OKCancel,
                MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                if (Properties.Settings.Default.LanguageCode == "ru-RU")
                    Properties.Settings.Default.LanguageCode = "en-US";
                else
                    Properties.Settings.Default.LanguageCode = "ru-RU";
                Properties.Settings.Default.Save();

                Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.LanguageCode);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.LanguageCode);

                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }
        #endregion


        public ICommand LoadedApplicationCommand { get; set; }

        private bool CanLoadedApplicationCommandExecute(object parameter) => true;

        private void OnLoadedApplicationCommandExecute(object parameter)
        {
            MessageBox.Show("dasd", "dasd", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }


        public MainWIndowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            FormWindowsMinimizedCommand = new LambdaCommand(OnFormWindowsMinimizedCommandExecute, CanFormWindowsMinimizedCommandExecute);
            FormWindowStateMaximizedCommand = new LambdaCommand(OnFormWindowStateMaximizedCommandExecuted, CanFormWindowStateMaximizedCommandExecute);
            LoadedApplicationCommand = new LambdaCommand(OnLoadedApplicationCommandExecute, CanLoadedApplicationCommandExecute);
            MenuCommand = new LambdaCommand(OnMenuCommandExecute, CanMenuCommandExecute);
            SelectLanguage = new LambdaCommand(OnSelectLanguageExecuted, CanSelectLanguageExecute);
        }
    }
}
