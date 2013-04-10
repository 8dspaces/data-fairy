package PACKAGE_STRING.tables
{
	import PACKAGE_STRING.interfaces.*;
	import PACKAGE_STRING.dbvos.ROW_CLASS_NAME;

	public class CLASS_NAME implements IDBVOTable
	{
		public var rowList:Vector.<ROW_CLASS_NAME>;
	
		public function CLASS_NAME():void
		{
		
		}
		
		public static function create(CLASS_PARAMS):CLASS_NAME
		{
			var instance:ClassName = new ClassName();
		
			CLASS_PARAMS_LIST
			instance.init();
		
			return instance;
		}

		public function init():void
		{
			rowList = new Vector.<ROW_CLASS_NAME>();

			ROW_LIST
		}

		public function index(row:IDBVORow):IDBVORow
		{
			rowList.push(row);
			return row;
		}
		
		public function get tableName():String
		{
			return "CLASS_NAME";
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
	}
}