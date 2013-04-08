package PACKAGE_STRING.interfaces
{
	public interface IDBVOsModel
	{
		function get tableList():Vector.<IDBVOTable>;
		function get loaded():Boolean;
	}
}