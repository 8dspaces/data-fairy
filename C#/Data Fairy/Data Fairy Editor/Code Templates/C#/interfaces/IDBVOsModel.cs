using System;
using System.Data;
using System.Collections.Generic;

{NAME}space {PACKAGE_STRING}.interfaces
{
	public interface IDBVOsModel
	{
		List<IDBVOTable> tableList { get; }
		bool loaded { get; }
		IDBVORow retrieve(int id, Type type);
	}
}