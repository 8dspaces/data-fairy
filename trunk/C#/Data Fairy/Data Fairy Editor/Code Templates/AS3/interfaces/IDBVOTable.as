package PACKAGE_STRING.interfaces
{
	public interface IDBVOTable
	{
		function get dbvos():IDBVOsModel;
		function set dbvos(value:IDBVOsModel):void;
		
		function get tableName():String;
		function get rowList():Vector.<IDBVORow>;
		function get rowType():Class;
		function getRow(id:int):IDBVORow;
	}
}