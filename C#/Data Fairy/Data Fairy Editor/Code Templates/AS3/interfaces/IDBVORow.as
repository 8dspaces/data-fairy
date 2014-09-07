package {PACKAGE_STRING}.interfaces
{
	public interface IDBVORow
	{
		function get dbvos():IDBVOsModel;
		function set dbvos(value:IDBVOsModel):void;
		
		function get id():int;
		function set id(value:int):void;
	}
}