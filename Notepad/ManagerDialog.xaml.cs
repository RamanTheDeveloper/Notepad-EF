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
using System.Windows.Forms;
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
            refreshData();
        }

        private void refreshData()
        {
            BindingSource bi = new BindingSource();
            var query = from t in npContext.Title
                        orderby t.DueDate
                        select new { t.Id, TitleName = t.Name, StatusName = t.Status.Name, t.DueDate };
            bi.DataSource = query.ToList();

            listView.ItemsSource = bi;


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
                refreshData();
            }
            else
            {
                System.Windows.MessageBox.Show("Please make sure all data has been entered");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //var t = npContext.Title.Find(listView.SelectedItem);
        }
    }
}
