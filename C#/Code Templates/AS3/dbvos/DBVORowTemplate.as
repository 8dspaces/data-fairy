package PACKAGE_STRING.dbvos
{
	import PACKAGE_STRING.interfaces.*;

	public class CLASS_NAME implements IDBVORow
	{
		protected var _dbvos:IDBVOsModel;
		
		VARIABLE_LIST
		protected var _id:int;
		
		public function CLASS_NAME(dbvos:IDBVOsModel):void
		{
			_dbvos = dbvos;
		}
		
		public function init(CLASS_PARAMS_STRING):CLASS_NAME
		{
			CLASS_PARAMS_LIST
		
			return this;
		}
		
		public function get dbvos():IDBVOsModel
		{
			return _dbvos;
		}
		
		public function set dbvos(value:IDBVOsModel):void
		{
			_dbvos = value;
		}
		
		public function get id():int
		{
			return _id;
		}
		
		public function set id(value:int):void
		{
			_id = value;
		}

		PROPERTY_LIST
	}
}