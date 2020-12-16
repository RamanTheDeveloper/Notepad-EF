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
            if(cboStatus.SelectedItem != null && txtBox.Text != String.Empty)
            {
                var newTitle = new Models.Title
                {
                    Name = txtBox.Text,
                    StatusId = (cboStatus.SelectedItem as Models.Status).Id,
                    DueDate = datePicker.SelectedDate
                };

                npContext.Title.Add(newTitle);

                npContext.SaveChanges();
            }
            else
            {
                MessageBox.Show("Please make sure all data has been entered");
            }
        }
    }
}
