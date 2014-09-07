	public var {NAME}(get,set):{TYPE}; // property declaration
	var _{NAME}:{TYPE}; // cached lookup value
	function get_{NAME}():{TYPE}
	{
		if(_{NAME} == null)
			_{NAME} = cast dbvos.retrieve({NAME}Id, "{TYPE}");
		return _{NAME};
	}
		
	function set_{NAME}(value:{TYPE}):{TYPE}
	{
		// overrides cached value
		return _{NAME} = value;
	}
		