using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr5_WinForm
{
	public partial class Pr5 : Form
	{
		public Pr5()
		{
			InitializeComponent();
		}
		private double function(double x)
		{
			try
			{
				if (x >= 2 || x == 1.5) throw new Exception();
				else return (Math.Sqrt(x * x - 2 * x + 1)) / (Math.Log(4 - 2 * x));
			}
			catch
			{
				throw;
			}
		}
		private void calculate2_Click(object sender, EventArgs e)
		{
			double a = Convert.ToDouble(border1.Text);
			double b = Convert.ToDouble(border2.Text);
			double h = Convert.ToDouble(step.Text);
			try
			{
				if (h <= 0) throw new Exception("Некорректное значение шага");
				else
				{
					string str = "";
					for (double i = a; i <= b; i += h)
					{
						try
						{
							str += $"y({i})={function(i)}\n";
						}
						catch
						{
							str += $"y({i})=error\n";
						}
					}
					tabel.Text = str;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void border1_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 39 || e.KeyChar >= 46) && number != 47 && number != 61)
			{
				e.Handled = true;
			}
		}
	}
}
