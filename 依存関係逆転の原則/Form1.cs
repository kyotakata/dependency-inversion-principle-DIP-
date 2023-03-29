using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 依存関係逆転の原則.Objects;
using static 依存関係逆転の原則.Program;

namespace 依存関係逆転の原則
{
    public partial class Form1 : Form
    {
        private Form1ViewModel _vm;

        public Form1(Form1ViewModel vm)
        {
            _vm = vm;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            button1.DataBindings.Add("Text", _vm, nameof(_vm.Button1Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _vm.Button1Click();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_product.Save("AAAA");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var f =new Form2(DI.Resolve<Form2ViewModel>()))
            {
                f.ShowDialog();
            }
        }
    }
}
