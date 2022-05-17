using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LowadiBot.ViewModels.Base;

namespace LowadiBot.ViewModels
{
    class  ProxyData
    {
        public string Proxy { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
    class Accout
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool SaveData { get; set; }
        public ProxyData Proxy { get; set; }
    }

    internal class LoginWindowViewModel : ViewModel
    {
        public ICollection<Accout> Accouts { get; private set; } = new ObservableCollection<Accout>() {
            new Accout() {Login = "Test 1", Password = "test 1", SaveData = false, Proxy = new ProxyData(){Proxy = "123.123.123", Port = 1233}},
            new Accout() {Login = "Test 2", Password = "test 2", SaveData = false},
            new Accout() {Login = "Test 3", Password = "test 3", SaveData = false, Proxy = new ProxyData(){Proxy = "123.123.123", Port = 1233}},
            new Accout() {Login = "Test 3", Password = "test 3", SaveData = false},
            new Accout() {Login = "Test 3", Password = "test 3", SaveData = false, Proxy = new ProxyData(){Proxy = "123.123.123", Port = 1233}},
            new Accout() {Login = "Test 3", Password = "test 3", SaveData = false},
            new Accout() {Login = "Test 4", Password = "test 4", SaveData = false, Proxy = new ProxyData(){Proxy = "123.123.123", Port = 1233}},
        };
    }
}
