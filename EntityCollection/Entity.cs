namespace EntityCollection
{
    /// <summary>
    /// Abstract class represents any entity with a key
    /// </summary>
    /// <typeparam name="TKey">Parameter defined a type of entity's key</typeparam>
    public abstract class Entity<TKey> where TKey : notnull 
    {
        #region Static Members
        /// <summary>
        /// Property gets or sets data separator
        /// </summary>
        public static string DataSeparator { get; set; } = "/";
        
        /// <summary>
        /// Property gets or sets a sample of textual data
        /// </summary>
        public static string TextDataSample { get; set; } = "";
        
        #endregion

        #region Instance Members
        /// <summary>
        /// Event to be raised when data was modified
        /// </summary>
        public event EventHandler? DataModified;
        /// <summary>
        /// Overriable property returns textual type
        /// </summary>
        public virtual string Type => this.GetType().Name;
        /// <summary>
        /// Property gets or initializes entity's key
        /// </summary>
        public TKey Key { get; init; } = default!;
        /// <summary>
        /// Property gets or sets an object used in any purpose
        /// </summary>
        public object? Tag { get; set; }  //will be used for any purpose

        public Entity() { }

        /// <summary>
        /// Notify the event DataModified
        /// </summary>
        protected void Notify() { DataModified?.Invoke(this, EventArgs.Empty); }
 
        //abstract operations
        /// <summary>
        /// Method sets a textual data
        /// </summary>
        /// <param name="data">textual data to be set</param>
        /// <returns>returns true when succeded</returns>
        public abstract bool SetTextData(string data);
        /// <summary>
        /// Method gets a textual data
        /// </summary>
        /// <returns>entity's textual data</returns>
        public abstract string GetTextData();
        /// <summary>
        /// Property gets entity's information
        /// </summary>
        public abstract string Info { get; }
        #endregion
    }
}
