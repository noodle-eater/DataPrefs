namespace DataPreferences {
    
        [System.Serializable]
		internal class Pair {
			public string key;
			public string value;
		}

		[System.Serializable]
		internal class PairWrapper {
			public System.Collections.Generic.IList<Pair> pairs = new System.Collections.Generic.List<Pair>();
		}
}