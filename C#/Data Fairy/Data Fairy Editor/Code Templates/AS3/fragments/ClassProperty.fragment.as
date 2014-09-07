		protected var _{NAME}:{TYPE}; // cached lookup value
		public function get {NAME}():{TYPE}
		{
			if(!_{NAME})
				_{NAME} = dbvos.retrieve({NAME}Id, {TYPE}) as {TYPE};
			return _{NAME};
		}
		
		public function set {NAME}(value:{TYPE}):void
		{
			// overrides cached value
			_{NAME} = value;
		}
		