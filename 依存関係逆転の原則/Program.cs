using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using 依存関係逆転の原則.Objects;

namespace 依存関係逆転の原則
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<IProduct, ProductFake>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる(IProductにはProductSqlServerの依存性を注入する)
            //container.RegisterType<IStock, StockFack>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
            //var vm = container.Resolve<Form1ViewModel>();　　　　// RegisterTypeで登録しているものをForm1ViewModelのコンストラクタに注入したものがvmに入ってくる

            var vm = DI.Resolve<Form1ViewModel>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(vm));
        }

        internal static class DI
        {
            private static ServiceCollection _container = new ServiceCollection();
            private static bool _isFake = false;
            private static ServiceProvider _serviceProvider;
            static DI()
            {

                _container.AddTransient<Form1ViewModel>();
                _container.AddTransient<Form2ViewModel>();

                if (_isFake)
                {
                    _container.AddTransient<IProduct, ProductFake>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
                    _container.AddTransient<IStock, StockFack>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
                }
                else
                {
                    _container.AddTransient<IProduct, ProductSqlServer>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
                    _container.AddTransient<IStock, StockFack>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
                }

                _serviceProvider = _container.BuildServiceProvider();
            }

            internal static T Resolve<T>()
            { 
              return _serviceProvider.GetRequiredService<T>();//Form1ViewModelのコンストラクタに上で登録しているProductSqlServerをはめてくれる
            }
        }

    }
}
