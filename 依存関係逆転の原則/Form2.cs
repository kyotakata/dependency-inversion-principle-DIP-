using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 依存関係逆転の原則.Objects
{
    public partial class Form2 : Form
    {
        private Form2ViewModel _vm;

        public Form2(Form2ViewModel vm)
        {
            _vm = vm;

            InitializeComponent();
        }
    }

}
