		protected var _NAMEValue:TYPE; // cached lookup value
		public function get NAME():TYPE
		{
			if(!_NAMEValue)
				_NAMEValue = dbvos.retreive(_NAME, TYPE) as TYPE;
			return _NAMEValue;
		}
		
		public function set NAME(value:TYPE):void
		{
			// overrides cached value
			_NAMEValue = value;
		}