<?php
/* @package PACKAGE_STRING.interfaces; */

interface IDBVOsModel
{
	/** @return Array<IDBVOTable> */
	public function get_tableList();

	/** @return Boolean */
	public function get_loaded();

	/** 
	 * @param Int $id
	 * @param String $type
	 * @return IDBVORow
	 */
	public function retrieve($id, $type);
}