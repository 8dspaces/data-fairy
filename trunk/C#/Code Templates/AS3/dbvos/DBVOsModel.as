PACKAGE_STRING.dbvos
{
	import PACKAGE_STRING.interfaces;

	public var tableList:Vector.<IDBVOTable>;

	VARIABLE_LIST

	public class DBVOsModel implements IDBVOsModel
	{
		public function DBVOsModel():void
		{
			INDEX = new Vector.<IDBVOTable>();

			init();
		}

		public function init():void
		{
			CLASS_LIST
		}

		protected function index(table:IDBVOTable):IDBVOTable
		{
			tableList.push(table);
			return table;
		}
	}
}