	private $_{NAME}; // cached lookup value
	public function get_{NAME}()
	{
		if($this->_{NAME} == null)
			$this->_{NAME} = $this->dbvos->retrieve($this->{NAME}Id, "{TYPE}");
		return $this->_{NAME};
	}
		
	function set_{NAME}($value)
	{
		// overrides cached value
		$this->_{NAME} = $value;
	}
		