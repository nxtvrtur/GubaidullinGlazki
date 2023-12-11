//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GubaidullinGlazki
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;

    public partial class Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            this.AgentPriorityHistory = new HashSet<AgentPriorityHistory>();
            this.ProductSale = new HashSet<ProductSale>();
            this.Shop = new HashSet<Shop>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public int AgentTypeID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public int Priority { get; set; }
        public string DirectorName { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string AgentTypeString => AgentType.Title;
        public int ProductCount => GetAllProducts();
        public int Sale => SaleCalculator(SalesCount);
        public decimal SalesCount => SalesCalculator();
        public SolidColorBrush BackgroundStyle
        {
            get
            {
                if (Sale >= 25)
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFromString("LightGreen");
                }
                else
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                }
            }
        }
        public int GetAllProducts()
        {
            var count = 0;
            var context = Gubaidullin_GlazkiEntities.GetContext().ProductSale.Where(p => p.AgentID == ID).ToList();
            foreach (var productSale in context)
            {
                count += productSale.ProductCount;
            }

            return count;
        }
        public decimal SalesCalculator()
        {
            var productSale = Gubaidullin_GlazkiEntities.GetContext().ProductSale.Where(p => p.AgentID == ID).ToList();
            var products = Gubaidullin_GlazkiEntities.GetContext().Product.ToList();
            decimal sale = 0;
            foreach (var product in products)
            {
                foreach (var item2 in productSale)
                {
                    if (product.ID == item2.ProductID)
                    {
                        sale += product.MinCostForAgent * item2.ProductCount;
                    }
                }
            }

            return sale;
                   
        }
        public int SaleCalculator(decimal sale)
        {
            var percents = 0;
            if (sale >= 0 && sale < 10000)
            {
                percents = 0;
            }
            if (sale >= 10000 && sale < 50000)
            {
                percents = 5;
            }
            if (sale >= 50000 && sale < 150000)
            {
                percents = 10;
            }
            if (sale >= 150000 && sale < 500000)
            {
                percents = 20;
            }
            if (sale >= 500000)
            {
                percents = 25;
            }
            return percents;
        }

        public virtual AgentType AgentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentPriorityHistory> AgentPriorityHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSale> ProductSale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop> Shop { get; set; }
    }
}
