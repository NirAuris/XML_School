namespace LibCS
{
    internal class XML
    {
        #region Initialise
        public XML(string path = "data.xml")
        {
            Path = path;

            if (!File.Exists(Path)) File.Create(Path).Close();
        }
        #endregion //Initialise

        #region Properties
        public string Path { get; set; }
        public List<Object> Xml { get; set; }
        public FileStream FS { get; private set; }
        public StreamReader SR { get; private set; }
        public XmlSerializer Seria { get; private set; }
        #endregion //Properties

        public void Read()
        {
            SR = new StreamReader(Path, encoding: System.Text.Encoding.UTF8);

            Xml = ((List<Object>)Seria.Deserialize(SR));
            SR.Close();
        }
        public void Save()
        {
            FS = new FileStream(Path, FileMode.Append);

            Seria.Serialize(FS, Xml);
            FS.Close();
        }
        public void Add(Object[] arg)
        {
            foreach (var item in arg)
            {
                Xml.Add(item);
            }
        }
    }
}
