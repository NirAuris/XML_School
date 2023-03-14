namespace LibCS
{
    //File.Replace();

    internal class Files
    {
        #region Initialise
        public Files(string path = "data.md")
        {
            Path = path;

            Exists();
        }
        #endregion //Initialise

        #region Properties
        public string Path { get; set; }
        #endregion //Properties

        #region Save
        public void Save(string[] lines)
        {
            Exists();

            File.WriteAllLines(Path, lines);
        }
        public void Save(List<string> lines)
        {
            Exists();

            File.WriteAllLines(Path, lines);
        }
        public void Save(string txt)
        {
            Exists();

            File.WriteAllText(Path, txt);
        }
        #endregion //Save

        #region Append
        public void Append(string[] lines)
        {
            Exists();

            File.AppendAllLines(Path, lines);
        }
        public void Append(List<string> lines)
        {
            Exists();

            File.AppendAllLines(Path, lines);
        }
        public void Append(string txt)
        {
            Exists();

            File.AppendAllText(Path, txt);
        }
        #endregion //Append

        #region Read
        public string[] Read(out string[] lines)
        {
            Exists();

            return lines = File.ReadAllLines(Path);
        }
        public List<string> Read(out List<string> lines)
        {
            Exists();

            return lines = File.ReadAllLines(Path).ToList();
        }
        public string Read(out string txt)
        {
            Exists();

            return txt = File.ReadAllText(Path);
        }
        #endregion //Read

        public void Exists()
        {
            if (!File.Exists(Path)) File.Create(Path).Close();
        }
        public void Delete()
        {
            Exists();

            File.Delete(Path);
        }
        public void Move(string destination)
        {
            Exists();

            File.Move(Path, destination);

            Path = destination;
        }
        public void Copy(string destination)
        {
            Exists();

            File.Copy(Path, destination);
        }
        private DateOnly LastUsed()
        {
            Exists();

            return DateOnly.FromDateTime(File.GetLastWriteTime(Path));
        }
    }
}
