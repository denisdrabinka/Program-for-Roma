using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace DoorStorage
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        Context db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;
        RelayCommand deleteAllCommand;
        RelayCommand sum;
        RelayCommand textChangedCommand;


        MainWindow main = (MainWindow)Application.Current.MainWindow;



        IEnumerable<TableOrder> order;
        IEnumerable<TableOrder> order1;
        IEnumerable<TableOrder> order2;
        IEnumerable<TableOrder> order3;
        IEnumerable<TableOrder> order4;
        IEnumerable<TableOrder> order5;


        public IEnumerable<TableOrder> Orders
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged("Orders");
            }
        }
        public IEnumerable<TableOrder> Orders1
        {
            get { return order1; }
            set
            {
                order1 = value;
                OnPropertyChanged("Orders1");
            }
        }
        public IEnumerable<TableOrder> Orders2
        {
            get { return order2; }
            set
            {
                order2 = value;
                OnPropertyChanged("Orders2");
            }
        }
        public IEnumerable<TableOrder> Orders3
        {
            get { return order3; }
            set
            {
                order3 = value;
                OnPropertyChanged("Orders3");
            }
        }
        public IEnumerable<TableOrder> Orders4
        {
            get { return order4; }
            set
            {
                order4 = value;
                OnPropertyChanged("Orders3");
            }
        }
        public IEnumerable<TableOrder> Orders5
        {
            get { return order5; }
            set
            {
                order5 = value;
                OnPropertyChanged("Orders3");
            }
        }


        public void LoadOrders()
        {
            db = new Context();
            db.TableOrders.Load();
            Orders = db.TableOrders.Local.ToBindingList().Where(p => p.Id != 0);
            Orders1 = db.TableOrders.Local.ToBindingList().Where(p => p.StageWork == 0);
            Orders2 = db.TableOrders.Local.ToBindingList().Where(p => p.StageWork == 1);
            Orders3 = db.TableOrders.Local.ToBindingList().Where(p => p.StageWork == 2);
        }


        public MainWindowViewModel()
        {
            db = new Context();
            db.TableOrders.Load();
            Orders = db.TableOrders.Local.ToBindingList().Where(p => p.Id != 0);
            Orders1 = db.TableOrders.Local.ToBindingList().Where(p => p.StageWork == 0);
            Orders2 = db.TableOrders.Local.ToBindingList().Where(p => p.StageWork == 1);
            Orders3 = db.TableOrders.Local.ToBindingList().Where(p => p.StageWork == 2);
            Orders4 = db.TableOrders.Local.ToBindingList().Where(p => p.Id != 0);

        }

        public RelayCommand TextChangedCommand
        {
            get
            {
                return textChangedCommand ??
                  (textChangedCommand = new RelayCommand((t) =>
                  {
                     
                          string filter = main.TextBox1.Text;

                          ICollectionView viewSource = CollectionViewSource.GetDefaultView(main.dataGridTable0.ItemsSource);
                          if (filter == "") viewSource.Filter = null;
                          else
                          {
                              viewSource.Filter = o =>
                              {
                                  TableOrder p = o as TableOrder;
                                  return p.CustomerAddress.ToString().Contains(filter);
                              };
                              main.dataGridTable0.ItemsSource = viewSource;
                          }

                          OnPropertyChanged("TextChangedCommand");

                  }));
            }
        }

        public RelayCommand Sum
        {
            get
            {
                return sum ??
                  (sum = new RelayCommand((selectedItem) =>
                  {
                          if (selectedItem == null) return;
                          // получаем выделенный объект
                          TableOrder order = selectedItem as TableOrder;

                          double sid = order.SidebarMoney;
                          double inst = order.InstallationMoney;
                          double del = order.DeliveryMoney;
                          double rise = order.RiseMoney;

                          double sum = sid + inst + del + rise;
                          double percent = sum * 0.05;

                          if (order.StageWork == 0)
                          {
                              main.Sum.Text = Convert.ToString(sum);
                              main.Percent.Text = Convert.ToString(percent);
                           }
                          if (order.StageWork == 1)
                          {
                              main.Sum2.Text = Convert.ToString(sum);
                              main.Percent2.Text = Convert.ToString(percent);
                          }
                          if (order.StageWork == 2)
                          {
                              main.Sum3.Text = Convert.ToString(sum);
                              main.Percent3.Text = Convert.ToString(percent);
                          }
                          main.Sum0.Text = Convert.ToString(sum);
                          main.Percent0.Text = Convert.ToString(percent);

                      OnPropertyChanged("Sum");


                  }));
            }
        }

        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      using (Context db = new Context())
                      {
                          
                          WindowCRUD crud = new WindowCRUD();
                          crud.ShowDialog();

                          if (crud.DialogResult == false)
                              return;

                          TableOrder order = new TableOrder();
                          
                          order.Number = crud.NumberForm.Text;
                          order.NumberContract = crud.NumberContractForm.Text;
                          order.DateofReceipt = crud.DateofReceiptForm.Text;
                          order.DoorSource = crud.Source.SelectionBoxItem.ToString();
                          order.NumberofDoors = Convert.ToInt32(crud.NumberofDoorsForm.Text);
                          order.CustomerAddress = crud.CustomerAddressForm.Text;
                          order.CustomerPhone = crud.CustomerPhoneForm.Text;
                          if ((bool)crud.Master1.IsChecked)
                          {
                              order.Master = crud.Master1.Content.ToString();
                          }
                          if ((bool)crud.Master2.IsChecked)
                          {
                              order.Master = crud.Master2.Content.ToString();
                          }
                          if ((bool)crud.Master3.IsChecked)
                          {
                              order.Master = crud.Master3.Content.ToString();
                          }
                          if ((bool)crud.Master4.IsChecked)
                          {
                              order.Master = crud.Master4.Content.ToString();
                          }

                          if ((bool)crud.WithInstallation.IsChecked)
                          {
                              order.Installation = "C монтажом";
                          }
                          if ((bool)crud.WithoutInstallation.IsChecked)
                          {
                              order.Installation = "Без монтажа";
                          }
                          order.DateofDeparture = crud.DateofDepartureForm.Text;
                          if ((bool)crud.StageWork0.IsChecked)
                          {
                              order.StageWork = 0;
                          }
                          if ((bool)crud.StageWork1.IsChecked)
                          {
                              order.StageWork = 1;
                          }
                          if ((bool)crud.StageWork2.IsChecked)
                          {
                              order.StageWork = 2;
                          }

                          order.MasterMoney = Convert.ToDouble(crud.MasterMoneyForm.Text);

                          double sidebarMoney = Convert.ToDouble(crud.SidebarMoneyForm.Text);
                          double installationMoney = Convert.ToDouble(crud.InstallationMoney.Text);
                          double deliveryMoney = Convert.ToDouble(crud.DeliveryMoneyForm.Text);
                          double riseMoney = Convert.ToDouble(crud.DeliveryMoneyForm.Text);

                          order.SidebarMoney = sidebarMoney;
                          order.InstallationMoney = installationMoney;
                          order.DeliveryMoney = deliveryMoney;
                          order.RiseMoney = riseMoney;

                          double total =  sidebarMoney + installationMoney + deliveryMoney + riseMoney;
                          order.Total = total == 0 ? 0 : total;

                          db.TableOrders.Add(order);
                          db.SaveChanges();

                          LoadOrders();

                      }
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      using (Context db = new Context())
                      {
                          
                          if (selectedItem == null) return;
                          // получаем выделенный объект
                          TableOrder order = selectedItem as TableOrder;

                          WindowCRUD crud = new WindowCRUD();

                          crud.NumberForm.Text = order.Number;
                          crud.NumberContractForm.Text = order.NumberContract;

                          crud.DateofReceiptForm.Text = order.DateofReceipt;

                          crud.Source.Text = order.DoorSource;
                          
                          crud.NumberofDoorsForm.Text = Convert.ToString(order.NumberofDoors);
                          crud.CustomerAddressForm.Text = order.CustomerAddress;
                          crud.CustomerPhoneForm.Text = order.CustomerPhone;

                          if (order.Master == crud.Master1.Content.ToString())
                          {
                              crud.Master1.IsChecked = true;
                          }
                          if (order.Master == crud.Master2.Content.ToString())
                          {
                              crud.Master2.IsChecked = true;
                          }
                          if (order.Master == crud.Master3.Content.ToString())
                          {
                              crud.Master3.IsChecked = true;
                          }
                          if (order.Master == crud.Master4.Content.ToString())
                          {
                              crud.Master4.IsChecked = true;
                          }


                          if (order.Installation == "C монтажом")
                          {
                              crud.WithInstallation.IsChecked = true;
                          }
                          if (order.Installation == "Без монтажа")
                          {
                              crud.WithoutInstallation.IsChecked = true;
                          }
                          crud.DateofDepartureForm.Text = order.DateofDeparture;

                          if (order.StageWork == 0)
                          {
                              crud.StageWork0.IsChecked = true;
                          }
                          if (order.StageWork == 1)
                          {
                              crud.StageWork1.IsChecked = true;
                          }
                          if (order.StageWork == 2)
                          {
                              crud.StageWork2.IsChecked = true;
                          }

                          crud.SidebarMoneyForm.Text = Convert.ToString(order.SidebarMoney);
                          crud.MasterMoneyForm.Text = Convert.ToString(order.MasterMoney);
                          crud.InstallationMoney.Text = Convert.ToString(order.InstallationMoney);
                          crud.DeliveryMoneyForm.Text = Convert.ToString(order.DeliveryMoney);
                          crud.RiseMoneyForm.Text = Convert.ToString(order.RiseMoney);

                          crud.ShowDialog();
                          if (crud.DialogResult == false)
                              return;

                          order.Number = crud.NumberForm.Text;
                          order.NumberContract = crud.NumberContractForm.Text;
                          order.DateofReceipt = crud.DateofReceiptForm.Text;
                          order.DoorSource = crud.Source.SelectionBoxItem.ToString();

                          order.NumberofDoors = Convert.ToInt32(crud.NumberofDoorsForm.Text);
                          order.CustomerAddress = crud.CustomerAddressForm.Text;
                          order.CustomerPhone = crud.CustomerPhoneForm.Text;
                          if ((bool)crud.Master1.IsChecked)
                          {
                              order.Master = crud.Master1.Content.ToString();
                          }
                          if ((bool)crud.Master2.IsChecked)
                          {
                              order.Master = crud.Master2.Content.ToString();
                          }
                          if ((bool)crud.Master3.IsChecked)
                          {
                              order.Master = crud.Master3.Content.ToString();
                          }
                          if ((bool)crud.Master4.IsChecked)
                          {
                              order.Master = crud.Master4.Content.ToString();
                          }

                          if ((bool)crud.WithInstallation.IsChecked)
                          {
                              order.Installation = "C монтажом";
                          }
                          if ((bool)crud.WithoutInstallation.IsChecked)
                          {
                              order.Installation = "Без монтажа";
                          }
                          order.DateofDeparture = crud.DateofDepartureForm.Text;
                          if ((bool)crud.StageWork0.IsChecked)
                          {
                              order.StageWork = 0;
                          }
                          if ((bool)crud.StageWork1.IsChecked)
                          {
                              order.StageWork = 1;
                          }
                          if ((bool)crud.StageWork2.IsChecked)
                          {
                              order.StageWork = 2;
                          }

                          order.MasterMoney = Convert.ToDouble(crud.MasterMoneyForm.Text);

                          double sidebarMoney = Convert.ToDouble(crud.SidebarMoneyForm.Text);
                          double installationMoney = Convert.ToDouble(crud.InstallationMoney.Text);
                          double deliveryMoney = Convert.ToDouble(crud.DeliveryMoneyForm.Text);
                          double riseMoney = Convert.ToDouble(crud.DeliveryMoneyForm.Text);

                          order.SidebarMoney = sidebarMoney;
                          order.InstallationMoney = installationMoney;
                          order.DeliveryMoney = deliveryMoney;
                          order.RiseMoney = riseMoney;

                          double total = sidebarMoney + installationMoney + deliveryMoney + riseMoney;
                          order.Total = total == 0 ? 0 : total;


                          db.Entry(order).State = EntityState.Modified;
                          db.SaveChanges();

                          LoadOrders();
                      }

                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      using (Context db = new Context())
                      {
                          if (selectedItem == null) return;
                          // получаем выделенный объект
                          TableOrder order = selectedItem as TableOrder;
                          int id = order.Id;
                          order = db.TableOrders.Find(id);
                          db.TableOrders.Remove(order);
                          db.SaveChanges();

                          db.TableOrders.Load();
                          LoadOrders();

                      }
                  }));
            }
        }

        public RelayCommand DeleteAllCommand
        {
            get
            {
                return deleteAllCommand ??
                  (deleteAllCommand = new RelayCommand((selectedItem) =>
                  {
                      using (Context db = new Context())
                      {

                          WindowCRUD_2 crud = new WindowCRUD_2();
                          crud.ShowDialog();

                          if (crud.DialogResult == false)
                              return;

                          string nameMagazin = crud.Magazin.SelectionBoxItem.ToString();
                          
                          string month = crud.Month.SelectionBoxItem.ToString();
                          string year = Convert.ToString(DateTime.Now.Year);
                          string filter = month + "." + year;
                          if(month == "")
                          {
                              MessageBox.Show("Вы не указали дату!!!");
                              return;
                          }

                          //Orders5 = db.TableOrders.Local.ToBindingList().Where(p => p.DateofReceipt == filter);

                          ICollectionView viewSource = CollectionViewSource.GetDefaultView(order4);
                          //if (filter == "") viewSource.Filter = null;
                          //else
                          //{
                              viewSource.Filter = o =>
                              {
                                  TableOrder p = o as TableOrder;
                                  return p.DateofReceipt.ToString().Contains(filter) && p.DoorSource.ToString().Contains(nameMagazin);

                              };

                          //}

                          foreach (TableOrder item in viewSource)
                          {
                              int id = item.Id;
                              TableOrder to = db.TableOrders.Find(id);
                              db.TableOrders.Remove(to);
                          }

                          db.SaveChanges();

                          db.TableOrders.Load();
                          LoadOrders();

                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// denis hddjjdjhdhdjhdjhdjjhd
        /// //dfidjdjdk
        /// djdkdkjd
    }
}

