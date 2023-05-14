using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Unity;
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
            ////このcontainerにこのインターフェースはこの依存性が入るように登録しておく
            //container.RegisterType<IProduct, ProductFake>();//IProductを引数としているコンストラクタには自動的にProductSqlServer/ProductFakeがはまる(IProductにはProductSqlServer/ProductFakeの依存性を注入する。)ここでProductSqlServer/ProductFakeを切り替える、
            //container.RegisterType<IStock, StockFack>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
            //var vm = container.Resolve<Form1ViewModel>();　　　　// 上のRegisterTypeで登録しているものがForm1ViewModelのコンストラクタに注入されるようになる。その注入したものがvmに入ってくる。
            //↓書き換え
            var vm = DI.Resolve<Form1ViewModel>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(vm));
        }

        internal static class DI
        {
            private static IUnityContainer _container = new UnityContainer();
            private static bool _isFake = false;

            /// <summary>
            /// コンストラクタ
            /// staticのコンストラクタはstaticなメンバに触れた瞬間に動作する。一番最初にガチャンと決まる。ガチャンと設定しておけば、Resolveメソッドでとってくる値がどっちか決まる。
            /// </summary>
            static DI()
            {
                if (_isFake)
                {
                    _container.RegisterType<IProduct, ProductFake>();//IProductを引数としているコンストラクタには自動的にProductFakeがはまる(IProductにはProductFakeの依存性を注入する)
                    _container.RegisterType<IStock, StockFack>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
                }
                else
                {
                    _container.RegisterType<IProduct, ProductSqlServer>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる(IProductにはProductSqlServerの依存性を注入する)
                    _container.RegisterType<IStock, StockFack>();//IProductを引数としているコンストラクタには自動的にProductSqlServerがはまる
                }
            }

            /// <summary>
            /// 共通的に使用できるResolveメソッド
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            internal static T Resolve<T>()
            { 
              return _container.Resolve<T>();
            }
        }

    }
}
