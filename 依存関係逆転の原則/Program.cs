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

            /// <summary>
            /// コンストラクタ
            /// staticのコンストラクタはstaticなメンバに触れた瞬間に動作する。一番最初にガチャンと決まる。ガチャンと設定しておけば、Resolveメソッドでとってくる値がどっちか決まる。
            /// </summary>
            static DI()
            {
                // Microsoft Extensions DependencyInjectionの場合、Unityとは違い、事前にResolveする前にAddTransientしておかないといけない。シングルトンの場合はAddSingleton。今回は使い捨てなのでAddTransient。
                _container.AddTransient<Form1ViewModel>();
                _container.AddTransient<Form2ViewModel>();

                if (_isFake)
                {
                    _container.AddTransient<IProduct, ProductFake>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
                    _container.AddTransient<IStock, StockFack>();//IProductを引数としているコンストラクタには自動的にStockFackがはまる
                }
                else
                {
                    _container.AddTransient<IProduct, ProductSqlServer>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
                    _container.AddTransient<IStock, StockFack>();//IProductを引数としているコンストラクタには自動的にStockFackがはまる
                }

                _serviceProvider = _container.BuildServiceProvider();// ServiceCollectionクラスで出来上がった_containerを元に_serviceProviderを作る。
            }

            /// <summary>
            /// 共通的に使用できるResolveメソッド
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            internal static T Resolve<T>()
            {
                return _serviceProvider.GetRequiredService<T>();
                // GetServiceとGetRequiredServiceがある。
                // GetServiceだと依存性注入する対象がない場合nullが返る。
                // GetRequiredServiceだと依存性注入する対象がない場合例外が返る。
            }
        }

    }
}

