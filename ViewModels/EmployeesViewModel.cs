using Microsoft.Extensions.DependencyInjection;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfVodovoz.Data.Servise;
using WpfVodovoz.Models;
using WpfVodovoz.Views;

namespace WpfVodovoz.ViewModels
{
    public class EmployeesViewModel : BaseViewModel
    {
        private readonly IRepository<Employee> Repo;
        private readonly IServiceProvider Provider;
        private readonly EmployeeService Service;

        public ObservableCollection<Employee> Employees { get; set; }
        private Employee SelectEmployee;

        public EmployeesViewModel(IRepository<Employee> repo,
                                  IServiceProvider provider,
                                   EmployeeService service)
        {
            Repo = repo;
            Provider = provider;
            Service = service;

            Title = "Сотрудники";

            Employees = new ObservableCollection<Employee>(Repo.GetAll());
        }
        public Employee SelectedEmployee
        {
            get => SelectEmployee;
            set
            {
                SelectEmployee = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand => new RelayCommand(OpenAddWindow);
        
        private void OpenAddWindow(object obj)
        {
            var window = Provider.GetRequiredService<EmployeeCreateView>();

            if (window.DataContext is EmployeeCreateViewModel vm)
            {
                vm.OnEmployeeCreated = employee =>
                {
                    Employees.Add(employee);
                };
            }
            window.ShowDialog();
        }
        public ICommand DeleteCommand => new RelayCommand(DeleteEmpl);
        private void DeleteEmpl(object emp)
        {
            if (emp == null) return;
            var employee = (Employee)emp;

            var result = MessageBox.Show(
                $"Удалить сотрудника {employee.FullName}?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            Service.DeleteEmployee(employee);
            Employees.Remove(employee);
        }
        public ICommand EditCommand => new RelayCommand(EditEmployee);
        private void EditEmployee(object obj)
        {
            if (obj == null)
                return;

            var employee = (Employee)obj;

            var window = Provider.GetRequiredService<EmployeeCreateView>();

            if (window.DataContext is EmployeeCreateViewModel vm)
            {

                vm.NewEmployee = employee;

                vm.IsEditMode = true;
            }

            window.ShowDialog();

        }
    }

}
