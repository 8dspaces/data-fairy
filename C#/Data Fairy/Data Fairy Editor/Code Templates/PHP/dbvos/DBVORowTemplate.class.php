<?php
/** @package {PACKAGE_STRING}.dbvos; */

class {CLASS_NAME} extends PropertyObject implements IDBVORow
{
	/** IDBVOsModel */
	private $_dbvos; 
		
	{VARIABLE_LIST}
	/** Int */
	private $_id;
		
	/**
	 * @param IDBVOsModel $dbvos
	 */
	public function __construct($dbvos)
	{
		$this->_dbvos = $dbvos;
	}
	
	/** @return {CLASS_NAME} */
	public function init({CLASS_PARAMS_STRING})
	{
		{CLASS_PARAMS_LIST}
		
		return $this;
	}
	
	/** @return IDBVOsModel */
	public function get_dbvos()
	{
		return $this->_dbvos;
	}
	
	/** 
	 * @param IDBVOsModel $value
	 */
	public function set_dbvos($value)
	{
		$this->_dbvos = $value;
	}
	
	/** @return Int */
	public function get_id()
	{
		return $this->_id;
	}
	
	/** @param Int $value */
	public function set_id($value)
	{
		$this->_id = $value;
	}

	{PROPERTY_LIST}
}
