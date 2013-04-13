		protected var _NAME:TYPE; // cached lookup value
		public function get NAME():TYPE
		{
			if(!_NAME)
				_NAME = dbvos.retrieve(NAMEId, TYPE) as TYPE;
			return _NAME;
		}
		
		public function set NAME(value:TYPE):void
		{
			// overrides cached value
			_NAME = value;
		}
		