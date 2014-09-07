using System;
using System.Data;
using System.Collections.Generic;

{NAME}space {PACKAGE_STRING}.interfaces
{
	public interface IDBVOTable
	{
		IDBVOsModel dbvos { get; set; }
		
		string tableName { get; }
		List<IDBVORow> rowList { get; }
		{TYPE} rowType { get; }
		IDBVORow getRow(int id);
	}
}