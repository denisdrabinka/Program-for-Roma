using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
using PagedList;
using System.Data;
using System.Collections;
using System.Reflection;
using System.IO;

namespace DoorStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }



        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    PrintDG print = new PrintDG();

        //    print.printDG(dataGridTableDoc, "Title");

        //    //System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
        //    //if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
        //    //{
        //    //    Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
        //    //    //sizing of the element.
        //    //    dataGridTableDoc.Measure(pageSize);
        //    //    dataGridTableDoc.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
        //    //    Printdlg.PrintVisual(dataGridTableDoc, Title);
        //    //}

        //}

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(Properties.Resources.s_EN_Question_Print, "Print", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
            
                try
                {
                    var border = VisualTreeHelper.GetChild(dataGridTableDoc, 0) as Decorator;
                    if (border != null)
                    {
                        var scrollViewer = border.Child as ScrollViewer;
                        if (scrollViewer != null)
                        {
                            scrollViewer.ScrollToTop();
                            scrollViewer.ScrollToLeftEnd();
                        }
                    }

                    Title = "_initialTitle" + " - " + Properties.Resources.s_EN_Info_Printing;

                    var myPrinter = new UIPrinter { Title = Title, Content = dataGridTableDoc };
                    int nbrOfPages = myPrinter.Print();

                    Title = "_initialTitle" + " - " + Properties.Resources.s_EN_Info_PrintingDone + ( " " + nbrOfPages + " Pages");
                }
                catch (Exception ex)
                {
                    Title = "_initialTitle" + " - " + ex.Message;
                }

            }
        }
    }
}
