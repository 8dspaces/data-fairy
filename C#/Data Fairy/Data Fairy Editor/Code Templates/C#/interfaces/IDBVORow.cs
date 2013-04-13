using System;
using System.Data;
using System.Collections.Generic;

namespace PACKAGE_STRING.interfaces
{
	public interface IDBVORow
	{
		IDBVOsModel dbvos { get; set; }
		int id { get; set; }
	}
}