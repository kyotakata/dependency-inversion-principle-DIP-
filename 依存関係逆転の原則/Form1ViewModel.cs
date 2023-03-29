using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 依存関係逆転の原則.Objects;

namespace 依存関係逆転の原則
{
    public class Form1ViewModel:INotifyPropertyChanged
    {
        private IProduct _product;
        private IStock _stock;

        //public Form1ViewModel():this(Factories.CreateProduct())
        //{
        //}

        public Form1ViewModel(IStock stock, IProduct product)
        {
            _product = product;
            _stock = stock;
        }

        public string Button1Text { get; set; } = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public void Button1Click()
        {
            Button1Text = ModuleB.GetValue(_product);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

    }
}
