using PACKAGE_STRING.dbvos;
using PACKAGE_STRING.interfaces;

namespace PACKAGE_STRING
{
	public class AutoTests
	{
		public static void Main(string[] args)
		{
			IDBVOsModel model = new DBVOsModel();
			foreach(IDBVOTable table in model.tableList)
			{
				System.Console.WriteLine("Table: " + table.tableName + ", Rows: " + table.rowList.Count);
			}
		}
	}
}