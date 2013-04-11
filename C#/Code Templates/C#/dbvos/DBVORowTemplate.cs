using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using PACKAGE_STRING.interfaces;

namespace PACKAGE_STRING.dbvos;
{
	public class CLASS_NAME : IDBVORow
	{
		protected IDBVOsModel _dbvos;
		
		VARIABLE_LIST
		protected int _id;
		
		public CLASS_NAME(IDBVOsModel dbvos)
		{
			_dbvos = dbvos;
		}
		
		public CLASS_NAME init(CLASS_PARAMS_STRING)
		{
			CLASS_PARAMS_LIST
		
			return this;
		}
		
		public IDBVOsModel dbvos()
		{
			get { return _dbvos; }
			set { _dbvos = value; }
		}
		
		public int get id()
		{
			get { return _id; }
			set { _id = value; }
		}

		PROPERTY_LIST
	}
}