	private $_NAME; // cached lookup value
	public function get_NAME()
	{
		if($this->_NAME == null)
			$this->_NAME = $this->dbvos->retrieve($this->NAMEId, "TYPE");
		return $this->_NAME;
	}
		
	function set_NAME($value)
	{
		// overrides cached value
		$this->_NAME = value;
	}
		