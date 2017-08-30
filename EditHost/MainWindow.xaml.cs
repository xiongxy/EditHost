using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EditHost
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadHost();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            if (!EditHost(TextBox.Text)) return;
            ReadHost();
            MessageBox.Show("修改成功！");
        }

        private void BtnRestore_OnClick(object sender, RoutedEventArgs e)
        {
            const string text = @"# Copyright (c) 1993-2009 Microsoft Corp.
#
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
#
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# space.
#
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
#
# For example:
#
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host

# localhost name resolution is handled within DNS itself.
#	127.0.0.1       localhost
#	::1             localhost";
            if (!EditHost(text)) return;
            ReadHost();
            MessageBox.Show("修改成功！");
        }
        private void ReadHost()
        {
            var vvv = Environment.SystemDirectory;
            var vv = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string path = vv + "\\System32\\drivers\\etc\\hosts";
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            TextBox.Text = streamReader.ReadToEnd();
            fileStream.Close();
            streamReader.Close();
        }
        private bool EditHost(string str)
        {
            try
            {
                var vv = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                string path = vv + "\\System32\\drivers\\etc\\hosts";
                File.WriteAllText(path, str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
