using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LowadiBot
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var langCode = LowadiBot.Properties.Settings.Default.LanguageCode;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);
        }
    }
}
