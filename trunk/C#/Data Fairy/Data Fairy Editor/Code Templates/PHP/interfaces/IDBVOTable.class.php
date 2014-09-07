<?php 
/* @package {PACKAGE_STRING}.interfaces; */

interface IDBVOTable
{
	/** @return IDBVOsModel */
	public function get_dbvos();
	public function set_dbvos($value);

	/** @return String */
	function get_tableName();

	/** @return Array<IDBVORow> */
	function get_rowList();

	/** @return String */
	function get_rowType();

	/** 
	 * @param Int $id
	 * @return IDBVORow
	 */
	function getRow($id);
}