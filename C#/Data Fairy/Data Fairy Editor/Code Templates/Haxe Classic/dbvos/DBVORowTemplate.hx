package {PACKAGE_STRING}.dbvos;

import {PACKAGE_STRING}.interfaces.*;

class {CLASS_NAME} implements IDBVORow
{
	public var dbvos(get,set):IDBVOsModel;
	var _dbvos:IDBVOsModel;
		
	{VARIABLE_LIST}
	public var id(get,set):Int;
	var _id:Int;
		
	public function new(dbvos:IDBVOsModel)
	{
		_dbvos = dbvos;
	}
		
	public function init({CLASS_PARAMS_STRING}):{CLASS_NAME}
	{
		{CLASS_PARAMS_LIST}
		
		return this;
	}
		
	public function get_dbvos():IDBVOsModel
	{
		return _dbvos;
	}
		
	public function set_dbvos(value:IDBVOsModel):IDBVOsModel
	{
		return _dbvos = value;
	}
		
	public function get_id():Int
	{
		return _id;
	}
		
	public function set_id(value:Int):Int
	{
		return _id = value;
	}

	{PROPERTY_LIST}
}
