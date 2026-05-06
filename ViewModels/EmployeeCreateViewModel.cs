using Mysqlx.Connection;
using System;
using System.Collections.Generic;
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
    public class EmployeeCreateViewModel : BaseViewModel
    {
        private readonly EmployeeService Service;
        public Employee NewEmployee { get; set; } = new Employee();
        public bool IsEditMode { get; set; }

        public EmployeeCreateViewModel(EmployeeService service)
        {
            Service = service;
        }
        public Array Positions { get; } = Enum.GetValues(typeof(EmployeePosition));
        public Action<Employee> OnEmployeeCreated { get; set; }
        public ICommand SaveCommand => new RelayCommand(Save);
        public event Action CloseRequested;
        private void Save(object obj)
        {
            if (string.IsNullOrWhiteSpace(NewEmployee.FullName))
            {
                MessageBox.Show("ФИО обязательно для заполнения");
                return;
            }

            if (IsEditMode)
            {
                Service.UpdateEmployee(NewEmployee);
            }
            else
            {
                Service.AddEmployee(NewEmployee);
            }
            
            OnEmployeeCreated?.Invoke(NewEmployee);
            CloseRequested?.Invoke();
        }
    }
}
