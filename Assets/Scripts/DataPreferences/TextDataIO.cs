namespace DataPreferences {

    internal class TextDataIO : IDataIO<PairWrapper> {

        private string _fileName;

        internal TextDataIO(string filename) {
            _fileName = filename;
        }

        public PairWrapper Read() {
            string json = System.IO.File.ReadAllText(UnityEngine.Application.persistentDataPath + "/" + _fileName);
            return UnityEngine.JsonUtility.FromJson<PairWrapper>(json);
        }

        public void Write(PairWrapper data) {
            string json = UnityEngine.JsonUtility.ToJson(data, true);
            UnityEngine.Debug.Log(json);
            System.IO.File.WriteAllText(UnityEngine.Application.persistentDataPath + "/" + _fileName, json);
        }
    }
}