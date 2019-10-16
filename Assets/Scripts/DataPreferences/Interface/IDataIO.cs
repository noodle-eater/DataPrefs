namespace DataPreferences {
    
    internal interface IDataIO<T> {
        
        void Write(T data);
        T Read();
    }
}