package {PACKAGE_STRING};

import {PACKAGE_STRING}.dbvos.DBVOsModel;
import {PACKAGE_STRING}.interfaces.IDBVOsModel;
import {PACKAGE_STRING}.interfaces.IDBVOTable;

class AutoTests
{
	public function new()
	{
		var model:IDBVOsModel = new DBVOsModel();
		for(table in model.tableList)
		{
			trace("Table: " + table.tableName + ", Rows: " + table.rowList.length);
		}
	}		
}
