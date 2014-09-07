using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using {PACKAGE_STRING}.interfaces;
using {PACKAGE_STRING}.dbvos;

{NAME}space {PACKAGE_STRING}.tables
{
	public class {CLASS_NAME} : IDBVOTable
	{
		protected IDBVOsModel _dbvos;
		protected List<{ROW_CLASS_NAME}> _rowList;
	
		public {CLASS_NAME}(IDBVOsModel dbvos)
		{
			_dbvos = dbvos;
		}

		public {CLASS_NAME} init()
		{
			_rowList = new List<{ROW_CLASS_NAME}>();

			{ROW_LIST}
			
			return this;
		}

		public IDBVORow index(IDBVORow row)
		{
			row.dbvos = dbvos;
			_rowList.Add(({ROW_CLASS_NAME})(row));
			return row;
		}
		
		public IDBVOsModel dbvos
		{
			get { return _dbvos; }
			set { _dbvos = value; }
		}
		
		public string tableName
		{
			get { return "{TABLE_NAME}"; }
		}
		
		public List<IDBVORow> rowList
		{
			get { return new List<IDBVORow>(_rowList.Cast<IDBVORow>()); }
		}

		public {TYPE} rowType
		{
			get { return {TYPE}of({ROW_CLASS_NAME}); }
		}
		
		public IDBVORow getRow(int id)
		{
			foreach(IDBVORow row in rowList)
			{
				if(row.id == id)
					return row;
			}
			return null;
		}
		
		public {ROW_CLASS_NAME} getRowCast(int id)
		{
			return ({ROW_CLASS_NAME})(getRow(id));
		}
	}
}