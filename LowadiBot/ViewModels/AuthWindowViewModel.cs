using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LowadiBot.ViewModels.Base;

namespace LowadiBot.ViewModels
{
    internal class AuthWindowViewModel : ViewModel
    {
        private bool _proxy { get; set; } = false;
        public bool Proxy {
            get => _proxy;
            set {
                _proxy = value;
                ProxyV = value == true ? Visibility.Visible : Visibility.Collapsed;
                OnPropertyChanged();
            }
        }

        private Visibility _proxyV { get; set; } = Visibility.Collapsed;
        public Visibility ProxyV {
            get => _proxyV;
            set {
                _proxyV = value;
                OnPropertyChanged();
            }
        }
    }
}
