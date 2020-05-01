using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

namespace PasswordManager
{
	/// <summary>
	/// Interaction logic for AddPass.xaml
	/// </summary>
	public partial class AddPass : Window
	{
		public int[] passwordLength { get; set; }
		public AddPass()
		{
			InitializeComponent();
			passwordLength = new int[15];
			for (int i = 0; i < 15; i++)
			{
				passwordLength[i] = i + 6;
			}
			DataContext = this;

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string l = this.Length.Text;
			int length = Convert.ToInt32(l);
			bool symbols = false, numbers = false, lowercase = false, uppercase = false, similar = false, ambiguous = false;
			if (this.Symbols.IsChecked == true)
				symbols = true;
			if (this.Numbers.IsChecked == true)
				numbers = true;
			if (this.Lowercase.IsChecked == true)
				lowercase = true;
			if (this.Uppercase.IsChecked == true)
				uppercase = true;
			if (this.Similar.IsChecked == true)
				similar = true;
			if (this.Ambiguous.IsChecked == true)
				ambiguous = true;
			GeneratePass gp = new GeneratePass();
			string password = gp.generate(length, symbols, numbers, lowercase, uppercase, similar, ambiguous);
			Password.Text = password;
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			string cn_String = Properties.Settings.Default.cn;
			SqlConnection sqlCon = new SqlConnection(cn_String);
			sqlCon.Open();
				string Query = "insert into data(Service,Password) values('" + this.Service.Text + "','" + this.Password.Text + "')";
				SqlCommand createCommand = new SqlCommand(Query, sqlCon);
				createCommand.ExecuteNonQuery();
				MessageBox.Show("Saved");			
			    sqlCon.Close();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}
	}
}
