using System;
using System.Collections.ObjectModel;
using System.Linq;
using WpfVodovoz.Models;

namespace WpfVodovoz.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<BaseViewModel> Tabs { get; set; }
        public BaseViewModel SelectedTab { get; set; }
        public MainViewModel(EmployeesViewModel employeesVM,
                            ContractorViewModel contractorVM,
                            OrderViewModel  orderVM)
        {
            Tabs = new ObservableCollection<BaseViewModel>
            {
                employeesVM,
                contractorVM,
                orderVM
            };

            SelectedTab = Tabs.FirstOrDefault();
        }
    }
}
