using System;
using System.Security;
using System.Collections.Generic;
using System.IO;

namespace VerificationTaskCSharp
{
    /// <summary>
    /// Класс <c>Writer</c> предназначен для подключения
    /// потока файлового вывода и записи текста в файл
    /// </summary>
    class Reader
    {
        /// <summary>
        /// Конструктор 
        /// принимает и устанавливает путь к файлу
        /// </summary>
        /// <param name="_path">Путь к файлу</param>
        public Reader(string _path)
        {
            element = new List<string>
            {
                null,
                null
            };

            fileSize = 0;
            path = _path;
        }

        /// <summary>
        /// Открывает файл по указанному пути
        /// выбрасывает исключения если путь выбран неправильно
        /// </summary>
        /// <exception cref="WrongPathToFileExeption">"No access to input file!"</exception>
        /// <exception cref="WrongPathToFileExeption">"Invalid path to input file!"</exception>
        public void open()
        {
            try
            {
                file = new FileInfo(path);
            }
            catch (SecurityException)
            {
                throw new WrongPathToFileExeption("No access to input file!");
            }
            catch (UnauthorizedAccessException)
            {
                throw new WrongPathToFileExeption("No access to input file!");
            }
            catch (Exception)
            {
                throw new WrongPathToFileExeption("Invalid path to input file!");
            }

            fileSize = file.Length;
            source = new StreamReader(path, Constants.encoding);
        }

        /// <summary>
        /// Закрывает файл
        /// </summary>
        public void close()
        {
            source.Close();
        }

        /// <summary>
        /// Читает из файла пару слово-разделитель
        /// </summary>
        /// <returns>Пара слово разделитель</returns>
        public List<string> getElement()
        {
            readElement();
            return element;
        }

        /// <summary>
        /// Возвращает размер файла
        /// </summary>
        /// <returns>Размер файла в байтах</returns>
        public Int64 getFileSize()
        {
            return fileSize;
        }

        /// <summary>
        /// Читает пару слово-разделитель из файла
        /// </summary>
        private void readElement()
        {
            element[(int)Constants.position.word] = null;                           //Установка слова по умолчанию
            element[(int)Constants.position.divide] = null;                         //Установка разделителя по умолчанию

            while ((source.Peek() > 0x20) && (source.Peek() != -1))                 //Пока не втретиться разделительный символ или конец файла считывать слово посимвольно
            {
                element[(int)Constants.position.word] += (char)source.Read();       
            }
            while((source.Peek() <= 0x20) && (source.Peek() != -1))                 //Пока символ разделительный и не встретился конец файла считывать разделитель посимвольно
            {
                if (source.Peek() == '\n')                                          //Если встретился перенос строки - закончить считывание разделителя
                {
                    element[(int)Constants.position.divide] += (char)source.Read();
                    return;
                }
                element[(int)Constants.position.divide] += (char)source.Read();
            }
        }
        
        private string path;            // Путь к файлу
        private Int64 fileSize;         // Размер файла
        private List<string> element;   // Пара слово-разделитель
        private FileInfo file;          // Информация о файле
        private StreamReader source;    // Файловый поток ввода
    }
}
