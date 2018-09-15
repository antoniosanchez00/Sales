using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.ViewModels
{
    public class MainViewModel
    {
        public ProductViewModel Products { get; set; }

        public MainViewModel()
        {
            this.Products = new ProductViewModel();
        }
    }
}
