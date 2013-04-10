package PACKAGE_STRING.tables
{
	import PACKAGE_STRING.interfaces.*;
	import PACKAGE_STRING.dbvos.ROW_CLASS_NAME;

	public class CLASS_NAME implements IDBVOTable
	{
		protected var _dbvos:IDBVOsModel;
		protected var _rowList:Vector.<ROW_CLASS_NAME>;
	
		public function CLASS_NAME():void
		{
		
		}

		public function init():CLASS_NAME
		{
			_rowList = new Vector.<ROW_CLASS_NAME>();

			ROW_LIST
			
			return this;
		}

		public function index(row:IDBVORow):IDBVORow
		{
			row.dbvos = dbvos;
			_rowList.push(row);
			return row;
		}
		
		public function get dbvos():IDBVOsModel
		{
			return _dbvos;
		}
		
		public function set dbvos(value:IDBVOsModel):void
		{
			_dbvos = value;
		}
		
		public function get tableName():String
		{
			return "TABLE_NAME";
		}
		
		public function get rowList():Vector.<IDBVORow>
		{
			return Vector.<IDBVORow>(_rowList);
		}

		public function get rowType():Class
		{
			return ROW_CLASS_NAME;
		}
		
		public function getRow(id:int):IDBVORow
		{
			for each(var row:IDBVORow in rowList)
			{
				if(row.id == id)
					return row;
			}
			return null;
		}
		
		public function getRowCast(id:int):ROW_CLASS_NAME
		{
			return getRow(id) as ROW_CLASS_NAME;
		}
	}
}