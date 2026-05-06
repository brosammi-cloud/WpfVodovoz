using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfVodovoz.Data.Servise;
using WpfVodovoz.Enums;
using WpfVodovoz.Models;

namespace WpfVodovoz.ViewModels
{
    public class ContractorCreateViewModel : BaseViewModel
    {
        private readonly ContractorService Service;
        private readonly EmployeeService EmployeeService;
        public Contractor NewСontractor { get; set; } = new Contractor();
        public bool IsEditMode { get; set; }
        public List<Employee> Employees { get; set; }
        public ContractorCreateViewModel(ContractorService service, EmployeeService employeeService)
        {
            Service = service;
            EmployeeService = employeeService;

            Employees = EmployeeService.GetAllEmployees().ToList();
        }
        public int SelectedEmployeeId { get; set; }

        public Action<Contractor> OnСontractorCreated { get; set; }
        public ICommand SaveCommand => new RelayCommand(Save);
        public event Action CloseRequested;
        private void Save(object obj)
        {
            if (string.IsNullOrWhiteSpace(NewСontractor.Name))
            {
                MessageBox.Show("Наименование обязательно для заполнения");
                return;
            }
            NewСontractor.Responsible = Employees
                                                .First(x => x.EmployeeId == SelectedEmployeeId);

            if (IsEditMode)
            {
                Service.UpdateСontractor(NewСontractor);
            }
            else
            {
                Service.AddСontractor(NewСontractor);
            }

            OnСontractorCreated?.Invoke(NewСontractor);
            CloseRequested?.Invoke();
        }
    }
}
