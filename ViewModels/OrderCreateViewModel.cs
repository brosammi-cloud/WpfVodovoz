using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfVodovoz.Data.Servise;
using WpfVodovoz.Models;

namespace WpfVodovoz.ViewModels
{
    public class OrderCreateViewModel : BaseViewModel
    {
        private readonly OrderService Service;
        private readonly ContractorService ContractorService;
        private readonly EmployeeService EmployeeService;
        public Order NewOrder { get; set; } = new Order();
        public bool IsEditMode { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Contractor> Contractors { get; set; }
        public OrderCreateViewModel(OrderService service, EmployeeService employeeService, ContractorService contractorService)
        {
            Service = service;
            EmployeeService = employeeService;
            ContractorService = contractorService;

            Employees = EmployeeService.GetAllEmployees().ToList();
            Contractors = ContractorService.GetAllСontractors().ToList();
        }
        public int SelectedEmployeeId { get; set; }
        public int SelectedContractorId { get; set; }

        public Action<Order> OnOrderCreated { get; set; }
        public ICommand SaveCommand => new RelayCommand(Save);
        public event Action CloseRequested;
        private void Save(object obj)
        {
            if (string.IsNullOrWhiteSpace(NewOrder.OrderNum))
            {
                MessageBox.Show("Наименование обязательно для заполнения");
                return;
            }
            NewOrder.Employee = Employees.First(x => x.EmployeeId == SelectedEmployeeId);
            NewOrder.Contractor = Contractors.First(x => x.СontractorId == SelectedContractorId);

            if (IsEditMode)
            {
                Service.UpdateOrder(NewOrder);
            }
            else
            {
                Service.AddOrder(NewOrder);
            }

            OnOrderCreated?.Invoke(NewOrder);
            CloseRequested?.Invoke();
        }
    }
}
