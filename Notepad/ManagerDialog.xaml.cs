using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Notepad.Models;
using SimpleNotepad.Models;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for ManagerDialog.xaml
    /// </summary>
    public partial class ManagerDialog : Window
    {
        private npDBContext npContext;
        public ManagerDialog()
        {
            InitializeComponent();

            npContext = new npDBContext();

            var statuses = npContext.Statuses.ToList();

            foreach(Status s in statuses)
            {
                cboStatus.Items.Add(s);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if()
        }
    }
}
