	public var NAME(get,set):TYPE; // property declaration
	var _NAME:TYPE; // cached lookup value
	function get_NAME():TYPE
	{
		if(_NAME == null)
			_NAME = cast dbvos.retrieve(NAMEId, "TYPE");
		return _NAME;
	}
		
	function set_NAME(value:TYPE):TYPE
	{
		// overrides cached value
		return _NAME = value;
	}
		