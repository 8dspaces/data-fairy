<?php
/** @package {PACKAGE_STRING}.dbvos; */

class DBVOsModel extends PropertyObject implements IDBVOsModel
{
	/** List of all tables */
	private $_tableList;
		
	/** Has the list of tables been loaded yet */
	private $_loaded;

	{VARIABLE_LIST}
	
	public function __construct()
	{
		$this->_tableList = array();

		$this->init();
	}

	/** Initialise the list of tables */
	public function init()
	{
		$dbvos = $this;

		{CLASS_LIST}
			
		$this->_loaded = true;
	}

	/** Indexes a table 
	 * @param IDBVOTable $table
	 * @return IDBVOTable
	 */
	function index($table)
	{
		$table->dbvos = $this;
		$this->_tableList[] = $table;
		return $table;
	}
		
	/** List of all tables indexed by this model
	 * @return Array<IDBVOTable>
	 */
	public function get_tableList()
	{
		return $this->_tableList;
	}
		
	/** Have the tables for this model been initialised yet
	 * @return Bool
 	 */
	public function get_loaded()
	{
		return $this->_loaded;
	}
		
	/** Retrieves a row from a table
	 * @param Int $id
	 * @param String $type
	 * @return IDBVORow
	 */
	public function retrieve($id, $type)
	{
		$table = $this->selectTable($type);
		return $table->getRow($id);
	}
		
	/** Retrieves a table by type
	 * @param String $type
	 * @return IDBVOTable
	 */
	public function selectTable($type)
	{
		foreach($this->_tableList as $table)
		{
			if($table->rowType == $type)
				return $table;
		}
		return false;
	}
}
