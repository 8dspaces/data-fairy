		protected TYPE _NAME; // cached lookup value
		public TYPE NAME
		{
			get {
				if(_NAME == null)
					_NAME = dbvos.retrieve(NAMEId, typeof(TYPE)) as TYPE;
				return _NAME;
			}
			set 
			{
				// overrides cached value
				_NAME = value;
			}
		}
		