using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using static System.Reflection.Metadata.BlobBuilder;

namespace VeloGamesInternshipTask1
{
    public class SanalDataBase
    {
        private static List<Book> books;

        static SanalDataBase()
        {
            books = new List<Book>();
        }

        public List<Book> GetAllBooks()
        {
            if (books == null || books.Count == 0)
            {
                LoadFromJsonFile(GetJsonFilePath());
            }
            return books;
        }

        public void UpdateData(List<Book> update)
        {
            books = update;
            SaveToJsonFile();
        }

        public void SaveToJsonFile()
        {
            string jsonContent = JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(GetJsonFilePath(), jsonContent);
        }

        private void LoadFromJsonFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(filePath);
                    books = JsonConvert.DeserializeObject<List<Book>>(jsonContent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }
        }

        private string GetJsonFilePath()
        {
            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string booksFolderPath = Path.Combine(documentsPath, "Books");

                if (!Directory.Exists(booksFolderPath))
                {
                    Directory.CreateDirectory(booksFolderPath);
                }
                return Path.Combine(booksFolderPath, "books.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return null;
            }
        }
    }
}
