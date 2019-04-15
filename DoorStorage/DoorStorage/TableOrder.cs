using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoorStorage
{
   public class TableOrder : INotifyPropertyChanged
    {
        private string number;
        private string numberContract;

        private string dateofReceipt;
        private string doorSource;
        private int numberofDoors;
        private string customerAddress;
        private string customerPhone;
        private string master;
        private string installation;
        private string dateofDeparture;
        private double sidebarMoney;
        private double masterMoney;
        private double installationMoney;
        private double deliveryMoney;
        private double riseMoney;
        private int stageWork;
        private double total;


        public int Id { get; set; }

        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        public string NumberContract
        {
            get { return numberContract; }
            set
            {
                numberContract = value;
                OnPropertyChanged("NumberContract");
            }
        }

        public string DateofReceipt
        {
            get { return dateofReceipt; }
            set
            {
                dateofReceipt = value;
                OnPropertyChanged("DateofReceipt");
            }
        }
        public string DoorSource
        {
            get { return doorSource; }
            set
            {
                doorSource = value;
                OnPropertyChanged("DoorSource");
            }
        }
        public int NumberofDoors
        {
            get { return numberofDoors; }
            set
            {
                numberofDoors = value;
                OnPropertyChanged("NumberofDoors");
            }
        }
        public string CustomerAddress
        {
            get { return customerAddress; }
            set
            {
                customerAddress = value;
                OnPropertyChanged("CustomerAddress");
            }
        }
        public string CustomerPhone
        {
            get { return customerPhone; }
            set
            {
                customerPhone = value;
                OnPropertyChanged("CustomerPhone");
            }
        }
        public string Master
        {
            get { return master; }
            set
            {
                master = value;
                OnPropertyChanged("Master");
            }
        }
        public string Installation
        {
            get { return installation; }
            set
            {
                installation = value;
                OnPropertyChanged("Installation");
            }
        }
        public string DateofDeparture
        {
            get { return dateofDeparture; }
            set
            {
                dateofDeparture = value;
                OnPropertyChanged("DateofDeparture");
            }
        }
        public double SidebarMoney
        {
            get { return sidebarMoney; }
            set
            {
                sidebarMoney = value;
                OnPropertyChanged("SidebarMoney");
            }
        }
        public double MasterMoney
        {
            get { return masterMoney; }
            set
            {
                masterMoney = value;
                OnPropertyChanged("MasterMoney");
            }
        }
        public double InstallationMoney
        {
            get { return installationMoney; }
            set
            {
                installationMoney = value;
                OnPropertyChanged("InstallationMoney");
            }
        }
        public double DeliveryMoney
        {
            get { return deliveryMoney; }
            set
            {
                deliveryMoney = value;
                OnPropertyChanged("DeliveryMoney");
            }
        }
        public double RiseMoney
        {
            get { return riseMoney; }
            set
            {
                riseMoney = value;
                OnPropertyChanged("DeliveryMoney");
            }
        }
        public int StageWork
        {
            get { return stageWork; }
            set
            {
                stageWork = value;
                OnPropertyChanged("StageWork");
            }
        }
        public double Total
        {
            get { return total; }
            set
            {
                total = value;
                OnPropertyChanged("Total");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
