package {PACKAGE_STRING}
{
	import flash.display.Sprite;
	import {PACKAGE_STRING}.dbvos.DBVOsModel;
	import {PACKAGE_STRING}.interfaces.IDBVOsModel;
	import {PACKAGE_STRING}.interfaces.IDBVOTable;
	
	public class AutoTests extends Sprite
	{
		public function AutoTests() 
		{
			var model:IDBVOsModel = new DBVOsModel();
			for each(var table:IDBVOTable in model.tableList)
			{
				trace("Table: " + table.tableName + ", Rows: " + table.rowList.length);
			}
		}
		
	}
}