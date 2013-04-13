using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using PACKAGE_STRING.interfaces;
using PACKAGE_STRING.tables;
	
namespace PACKAGE_STRING.dbvos
{
	public class DBVOsModel : IDBVOsModel
	{
		/** List of all tables */
		protected List<IDBVOTable> _tableList;
		
		/** Has the list of tables been loaded yet */
		protected bool _loaded;

		VARIABLE_LIST
	
		public DBVOsModel()
		{
			_tableList = new List<IDBVOTable>();

			init();
		}

		/** Initialise the list of tables */
		public void init()
		{
			IDBVOsModel dbvos = this;

			CLASS_LIST
			
			_loaded = true;
		}

		/** Indexes a table */
		protected IDBVOTable index(IDBVOTable table)
		{
			table.dbvos = this;
			_tableList.Add(table);
			return table;
		}
		
		/** List of all tables indexed by this model */
		public List<IDBVOTable> tableList
		{
			get { return _tableList; }
		}
		
		/** Have the tables for this model been initialised yet */
		public bool loaded
		{
			get { return _loaded; }
		}
		
		/** Retrieves a row from a table */
		public IDBVORow retrieve(int id, Type type)
		{
			var table = selectTable(type);
			return table.getRow(id);
		}
		
		/** Retrieves a table by type */
		public IDBVOTable selectTable(Type type)
		{
			foreach(var table in _tableList)
			{
				if(table.rowType == type)
					return table;
			}
			return null;
		}
	}
}