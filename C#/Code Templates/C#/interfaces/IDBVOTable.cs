using System;
using System.Data;
using System.Collections.Generic;

namespace PACKAGE_STRING.interfaces
{
	public interface IDBVOTable
	{
		IDBVOsModel dbvos { get; set; }
		
		string tableName { get; }
		List<IDBVORow> rowList { get; }
		Type rowType { get; }
		IDBVORow getRow(int id);
	}
}