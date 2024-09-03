using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace InventoryDarunpob.Pages.Siam
{
	public class IndexSiamModel : PageModel
	{
		public List<StockInfo> listStock = new List<StockInfo>();

		public void OnGet()
		{
			try
			{
				String connectionString = "Server=tcp:artart.database.windows.net,1433;Initial Catalog=artinventory;Persist Security Info=False;User ID=darunpob.naja;Password=Artart7807;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string sql = "SELECT * FROM stocks WHERE storeid=2 ";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								StockInfo stockinfo = new StockInfo();
								stockinfo.itemid = "" + reader.GetInt32(0);
								stockinfo.item = reader.GetString(1);
								stockinfo.storeid = reader.GetString(2);
								stockinfo.supplier = reader.GetString(3);
								stockinfo.amount = reader.GetString(4);
								stockinfo.create_at = reader.GetDateTime(5).ToString();

								listStock.Add(stockinfo);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: " + ex.ToString());
			}
		}
	}


	public class StockInfo
	{
		public String itemid;
		public String item;
		public String storeid;
		public String supplier;
		public String amount;
		public String create_at;
	}
}