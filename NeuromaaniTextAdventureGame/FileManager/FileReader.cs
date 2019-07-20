using System;
using System.IO;
using System.Linq;

namespace NeuromaaniTextAdventureGame.FileManager
{
    public class FileReader
    {
        public void DisplayTextFromFile(string fileName, int chapterIndex, int top, int left = 4)
        {
            var text = GetTextChapterFromFile(fileName, chapterIndex);

            ConvertTextToArray(text).ToList().ForEach(r =>
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine(r);
                top++;
            });

        }
        public void DisplayText(string text, int top, int left = 4)
        {
            ConvertTextToArray(text).ToList().ForEach(r =>
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine(r);
                top++;
            });
        }
        public string GetTextChapterFromFile(string fileName, int chapterIndex)
        {
            string AllTextFromFile = ReadToEndAndClose(fileName).Trim();
            return AllTextFromFile.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None)[chapterIndex];
        }
        public string ReadToEndAndClose(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader("D:\\Games\\NeuromaaniTextAdventureGame\\NeuromaaniTextAdventureGame\\Files/" + fileName.ToLower()))
                {
                    return sr.ReadToEnd();
                }
            }

            catch (Exception e)
            {
                throw new Exception("File doesn't exist, or is in wrong format | " + e);
            }

        }
        public string[] ConvertTextToArray(string text) => !string.IsNullOrEmpty(text) ? text.Split(new string[] { "\r\n" }, StringSplitOptions.None)
            : throw new Exception("Empty text file!");
    }
}
