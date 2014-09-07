<?php 
/** @package {PACKAGE_STRING}.tables; */

class {CLASS_NAME} extends PropertyObject implements IDBVOTable
{
	/** IDBVOsModel */
	private $_dbvos;

	/** Array<IDBVORow>, Array<{ROW_CLASS_NAME}> */
	private $_rowList;

	/** @param IDBVOsModel $dbvos */
	public function __construct($dbvos)
	{
		$this->_dbvos = $dbvos;
	}

	/** @return {CLASS_NAME} */
	public function init()
	{
		$this->_rowList = array(); // Array<{ROW_CLASS_NAME}>();

		{ROW_LIST}
			
		return $this;
	}

	/**
	 * @param IDBVORow $row;
	 * @return IDBVORow;
	 */
	public function index($row)
	{
		$row->dbvos = $this->dbvos;
		$this->_rowList[] = $row;
		return $row;
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
	
	/** @return String */	
	public function get_tableName()
	{
		return "{TABLE_NAME}";
	}
	
	/** @return Array<IDBVORow> */
	public function get_rowList()
	{
		return $this->_rowList;
	}

	/** @return String */
	public function get_rowType()
	{
		return "{ROW_CLASS_NAME}";
	}
		
	/**
	 * @param Int $id
	 * @return IDBVORow
	 */
	public function getRow($id)
	{
		foreach($this->_rowList as $row)
		{
			if($row->id == $id)
				return $row;
		}
		return false;
	}
		
	/**
	 * @param Int $id
	 * @return {ROW_CLASS_NAME}
	 */
	public function getRowCast($id)
	{
		return $this->getRow($id);
	}
}
