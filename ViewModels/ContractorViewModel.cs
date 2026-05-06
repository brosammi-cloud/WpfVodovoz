using Microsoft.Extensions.DependencyInjection;
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
    public class ContractorViewModel : BaseViewModel
    {
        private readonly IRepository<Contractor> Repo;
        private readonly IServiceProvider Provider;
        private readonly ContractorService Service;
        public ObservableCollection<Contractor> Сontractors { get; set; }
        private Contractor SelectСontractor;

        public ContractorViewModel(IRepository<Contractor> repo,
                                    IServiceProvider provider,
                                   ContractorService service)
        {
            Repo = repo;
            Provider = provider; 
            Service = service;
            Title = "Контрагенты";

            Сontractors = new ObservableCollection<Contractor>(Repo.GetAll());
        }
        public Contractor SelectedСontractor
        {
            get => SelectСontractor;
            set
            {
                SelectСontractor = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand => new RelayCommand(OpenAddWindow);

        private void OpenAddWindow(object obj)
        {
            var window = Provider.GetRequiredService<ContractorCreateView>();

            if (window.DataContext is ContractorCreateViewModel vm)
            {
                vm.OnСontractorCreated = contractor =>
                {
                    Сontractors.Add(contractor);
                };
            }
            window.ShowDialog();
        }
        public ICommand DeleteCommand => new RelayCommand(DeleteEmpl);
        private void DeleteEmpl(object obj)
        {
            if (obj == null) return;
            var contractor = (Contractor)obj;

            var result = MessageBox.Show(
                $"Удалить контрагента {contractor.Name}?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            Service.DeleteСontractor(contractor);
            Сontractors.Remove(contractor);
        }
        public ICommand EditCommand => new RelayCommand(EditEmployee);
        private void EditEmployee(object obj)
        {
            if (obj == null)
                return;

            var contractor = (Contractor)obj;

            var window = Provider.GetRequiredService<ContractorCreateView>();

            if (window.DataContext is ContractorCreateViewModel vm)
            {

                vm.NewСontractor = contractor;

                vm.IsEditMode = true;
            }

            window.ShowDialog();

        }
    }
}
