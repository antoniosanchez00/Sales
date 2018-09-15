
namespace Sales.ViewModels
{
    using System.Collections.ObjectModel;
    using Sales.Common.Models;
    

    public class ProductViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
    }
}
