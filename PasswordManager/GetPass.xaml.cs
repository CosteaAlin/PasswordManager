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
using System.Threading;

namespace PasswordManager
{
	/// <summary>
	/// Interaction logic for GetPass.xaml
	/// </summary>
	public partial class GetPass : Window
	{
		public GetPass()
		{
			InitializeComponent();
			fillCombo();
		}
		public void fillCombo()
		{
			string cn_String = Properties.Settings.Default.cn;
			SqlConnection sqlCon = new SqlConnection(cn_String);
			sqlCon.Open();
			string Query = "select * from data";
			SqlCommand createCommand = new SqlCommand(Query, sqlCon);
			SqlDataReader myreader;
			myreader = createCommand.ExecuteReader();
			while (myreader.Read())
			{
				string services = myreader.GetString(0);
				Services.Items.Add(services);
			}
			sqlCon.Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string cn_String = Properties.Settings.Default.cn;
			SqlConnection sqlCon = new SqlConnection(cn_String);
			sqlCon.Open();
			string sv = "'" + Services.Text + "'";
			string Query = "SELECT * FROM data WHERE Service=" + sv;
			SqlCommand createCommand = new SqlCommand(Query, sqlCon);
			SqlDataReader myreader;
			myreader = createCommand.ExecuteReader();
			if (myreader.Read())
			{
				Password.Text = (myreader["Password"].ToString());
			}
			else
			{
				MessageBox.Show("Please select a service.");
			}
			sqlCon.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}
	}
}
