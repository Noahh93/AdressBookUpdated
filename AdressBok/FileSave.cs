namespace Adressbok { 
public class FileSave
{
    public bool Save(string filePath, string ContactContent)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(ContactContent);
            return true;
        }
        catch 
        { 
            return false; 
        }
    }


    public string Read(string filepath)
    {
        try
        {
            using var sr = new StreamReader(filepath);
            string result = sr.ReadToEnd();
            return result;
        }
        catch 
        { 
            return null!; 
        }
    }
}

}