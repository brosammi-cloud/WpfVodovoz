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
    public class OrderViewModel : BaseViewModel
    {
        private readonly IRepository<Order> Repo;
        private readonly IServiceProvider Provider;
        private readonly OrderService Service;

        public ObservableCollection<Order> Orders { get; set; }
        private Order SelectOrders;

        public OrderViewModel(IRepository<Order> repo,
                                  IServiceProvider provider,
                                   OrderService service)
        {
            Repo = repo;
            Provider = provider;
            Service = service;

            Title = "Заказы";

            Orders = new ObservableCollection<Order>(Repo.GetAll());
        }
        public Order SelectedOrder
        {
            get => SelectOrders;
            set
            {
                SelectOrders = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand => new RelayCommand(OpenAddWindow);

        private void OpenAddWindow(object obj)
        {
            var window = Provider.GetRequiredService<OrderCreateView>();

            if (window.DataContext is OrderCreateViewModel vm)
            {
                vm.OnOrderCreated = order =>
                {
                    Orders.Add(order);
                };
            }
            window.ShowDialog();
        }
        public ICommand DeleteCommand => new RelayCommand(DeleteEmpl);
        private void DeleteEmpl(object obj)
        {
            if (obj == null) return;
            var order = (Order)obj;

            var result = MessageBox.Show(
                $"Удалить заказ {order.OrderId}?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            Service.DeleteOrder(order);
            Orders.Remove(order);
        }
        public ICommand EditCommand => new RelayCommand(EditOrder);
        private void EditOrder(object obj)
        {
            if (obj == null)
                return;

            var order = (Order)obj;

            var window = Provider.GetRequiredService<OrderCreateView>();

            if (window.DataContext is OrderCreateViewModel vm)
            {
                vm.NewOrder = order;

                vm.IsEditMode = true;
            }

            window.ShowDialog();
        }
    }
}
