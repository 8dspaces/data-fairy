<?php
/* @package PACKAGE_STRING.interfaces; */

interface IDBVORow
{
	/** @return IDBVOsModel */
	public function get_dbvos();
	public function set_dbvos($value);

	/** @return Int */
	public function get_id();
	public function set_id($value);
}
