using System;
using System.Collections.Generic;
using System.IO;

namespace VerificationTaskCSharp
{
    /// <summary>
    /// Класс <c>Writer</c> предназначен для подключения 
    /// потока файлового вывода и записи текста в файл
    /// </summary>
    public class Writer
    {
        /// <summary>
        /// Конструктор  принимает
        /// и устанавливает путь к файлу
        /// </summary>
        /// <param name="_path">Путь к файлу</param>
        public Writer(string _path)
        {
            path = _path;
        }

        /// <summary>
        /// Открывает файл по указанному пути
        /// или создаёт новый, выбрасывает исключения
        /// </summary>
        /// <exception cref="WrongPathToFileExeption">"No access to output file!"</exception>
        /// <exception cref="WrongPathToFileExeption">"Invalid path to output file!"</exception>
        public void open()
        {
            try
            {
                using (source = new StreamWriter(path));
            }
            catch (UnauthorizedAccessException)
            {
                throw new WrongPathToFileExeption("No access to output file!");
            }
            catch (Exception)
            {
                throw new WrongPathToFileExeption("Invalid path to output file!");
            }
        }

        /// <summary>
        /// Печатеат в файл пару слово-разделитель
        /// </summary>
        /// <param name="_element">Пара слово-разделитель</param>
        public void printCommon(List<string> _element)
        {
            using (source = new StreamWriter(path, true, Constants.encoding))
            {
                source.Write(_element[(int)Constants.position.word]);
                source.Write(_element[(int)Constants.position.divide]);
            }
        }

        /// <summary>
        /// Печатеат в файл пару слово-разделитель с тегами bold и italic
        /// </summary>
        /// <param name="_element">Пара слово-разделитель</param>
        public void printBold(List<string> _element)
        {
            using (source = new StreamWriter(path, true, Constants.encoding))
            {
                source.Write(openBTag);
                source.Write(openITag);
                source.Write(_element[(int)Constants.position.word]);
                source.Write(closeITag);
                source.Write(closeBTag);
                source.Write(_element[(int)Constants.position.divide]);
            }   
        }

        private string path;                        // Путь к файлу                       
        private StreamWriter source;                // Файловый поток вывода           
        private const string openBTag = "<b>";      // Тэг            
        private const string openITag = "<i>";      // Тэг
        private const string closeBTag = "</b>";    // Тэг
        private const string closeITag = "</i>";    // Тэг
    }
}
