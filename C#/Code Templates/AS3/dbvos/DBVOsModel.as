package PACKAGE_STRING.dbvos
{
	import PACKAGE_STRING.interfaces.*;
	import PACKAGE_STRING.tables.*;

	public class DBVOsModel implements IDBVOsModel
	{
		/** List of all tables */
		protected var _tableList:Vector.<IDBVOTable>;
		
		/** Has the list of tables been loaded yet */
		protected var _loaded:Boolean;

		VARIABLE_LIST
	
		public function DBVOsModel():void
		{
			_tableList = new Vector.<IDBVOTable>();

			init();
		}

		/** Initialise the list of tables */
		public function init():void
		{
			CLASS_LIST
			
			_loaded = true;
		}

		/** Indexes a table */
		protected function index(table:IDBVOTable):IDBVOTable
		{
			_tableList.push(table);
			return table;
		}
		
		/** List of all tables indexed by this model */
		public function get tableList():Vector.<IDBVOTable>
		{
			return _tableList;
		}
		
		/** Have the tables for this model been initialised yet */
		public function get loaded():Boolean
		{
			return _loaded;
		}
	}
}