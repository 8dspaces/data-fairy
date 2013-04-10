package PACKAGE_STRING.dbvos
{
	import PACKAGE_STRING.interfaces.*;

	public class CLASS_NAME implements IDBVORow
	{
		public var dbvos:IDBVOsModel;
		
		VARIABLE_LIST
		protected var _id:int;
		
		public function CLASS_NAME():void
		{
			
		}
		
		public static function create(CLASS_PARAMS_STRING):CLASS_NAME
		{
			var instance:ClassName = new ClassName();
		
			CLASS_PARAMS_LIST
		
			return instance;
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