		protected {TYPE} _{NAME}; // cached lookup value
		public {TYPE} {NAME}
		{
			get {
				if(_{NAME} == null)
					_{NAME} = dbvos.retrieve({NAME}Id, typeof({TYPE})) as {TYPE};
				return _{NAME};
			}
			set 
			{
				// overrides cached value
				_{NAME} = value;
			}
		}
		