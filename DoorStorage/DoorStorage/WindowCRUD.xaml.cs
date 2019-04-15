using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DoorStorage
{
    /// <summary>
    /// Interaction logic for WindowCRUD.xaml
    /// </summary>
    public partial class WindowCRUD : Window
    {

        public WindowCRUD()
        {
            InitializeComponent();
            NumberForm.Text = "0";
            NumberofDoorsForm.Text = "0";
            SidebarMoneyForm.Text = "0";
            MasterMoneyForm.Text = "0";
            InstallationMoney.Text = "0";
            DeliveryMoneyForm.Text = "0";
            RiseMoneyForm.Text = "0";

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
