package PACKAGE_STRING.interfaces
{
	public interface IDBVOTable
	{
		function get tableName():String;
		function get rowType():Class;
		function getRow(id:int):IDBVORow;
	}
}