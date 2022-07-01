using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._1._Simple_Calculations___GUI_Converter_BGN_to_EUR
{
    public partial class FormConverter : Form
    {
        public FormConverter()
        {
            InitializeComponent();
        }

        private void FormConverter_Load(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void numericUpDownAmount_KeyUp(object sender, KeyEventArgs e)
        {
            ConvertCurrency();
        }

        private void ConvertCurrency()
        {
            var amountBGN = this.numericUpDownAmount.Value;
            var amountEUR = amountBGN * 1.95583m;
            this.labelResult.Text =
                amountBGN + " BGN = " +
                Math.Round((amountEUR), 2) + " EUR";
        }
    }
}
