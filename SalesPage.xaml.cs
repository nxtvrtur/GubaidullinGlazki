using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GubaidullinGlazki
{
    public partial class SalesPage : Page
    {
        private readonly Agent currentAgent = new Agent();
        
        public SalesPage(Agent agent)
        {
            InitializeComponent();
            currentAgent = agent;
            var currentSales = Gubaidullin_GlazkiEntities.GetContext().ProductSale.ToList();
            currentSales = currentSales.Where(p => p.AgentID == currentAgent.ID).ToList();
            AgentSaleListView.ItemsSource = currentSales;
            UpdateSales();
        }
        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddSalesPage(currentAgent as Agent));
        }

        private void UpdateSales()
        {
            var currentProduct = Gubaidullin_GlazkiEntities.GetContext().ProductSale.ToList();
            AgentSaleListView.ItemsSource = currentProduct.Where(p => p.AgentID == currentAgent.ID);
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateSales();
        }

        private void DeleteSales_Click(object sender, RoutedEventArgs e)
        {
            var currentSale = (sender as Button).DataContext as ProductSale;
            var currentSalesList = Gubaidullin_GlazkiEntities.GetContext().ProductSale.ToList();
            currentSalesList = currentSalesList.Where(p => p.ID == currentSale.ID).ToList();
            if(currentSalesList.Count != 0)
            {
                if (MessageBox.Show("Вы точно хотите выполнить удаление?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Gubaidullin_GlazkiEntities.GetContext().ProductSale.Remove(currentSale);
                        Gubaidullin_GlazkiEntities.GetContext().SaveChanges();
                        UpdateSales();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    }
}