using System;
using System.Collections.Generic;

namespace VerificationTaskCSharp
{
    /// <summary>
    /// Класс обработчика
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Конструктор, инициализирует значения по умолчанию
        /// </summary>
        public Actor()
        {
            pathToDictionary = null;
            pathToInputFile = null;
            pathToOutputFile = null;
            element = new List<string>
            {
                null,
                null
            };
            scounter = 0;
            fcounter = 0;
            maxcount = 10000;
        }

        /// <summary>
        /// Устанавливает путь ко входному файлу
        /// </summary>
        /// <param name="_path">Путь ко входному файлу</param>
        public void setPathToInputFile(string _path)
        {
            pathToInputFile = _path;
        }

        /// <summary>
        /// Устанавливает путь к выходному файлу
        /// </summary>
        /// <param name="_path">Путь к выходному файлу</param>
        public void setPathToOutputFile(string _path)
        {
            pathToOutputFile = _path;
        }

        /// <summary>
        /// Устанавливает путь к файлу словаря
        /// </summary>
        /// <param name="_path">Путь к файлу словаря</param>
        public void setPathToDictionary(string _path)
        {
            pathToDictionary = _path;
        }

        /// <summary>
        /// Устанавливает максимальное колличество строк в выходном файле
        /// </summary>
        /// <param name="_maxcount">Колличество строк в выходном файле</param>
        public void setMaxCountOfStrings(int _maxcount)
        {
            if (_maxcount > 10000)
            {
                maxcount = 10000;
            }
            if ((_maxcount >= 10) && (_maxcount <= 10000))
            {
                maxcount = _maxcount;
            }
            if (_maxcount < 10)
            {
                maxcount = 10;
            }
        }

        /// <summary>
        /// Старт обработчика
        /// </summary>
        public void start()
        {
            connectResourses();             //Подключение файлов, если путь указан не верно выбрасывается исключение
            //validateFiles();                //Прверка файлов на соответствие, если размер превышен то выбрасывает исключение                                   

            do
            {
                read();                     //Чтение слова и разделителя из входного файла
                write();                    //Запись слова и разделителя в выходной файл

                if (scounter >= maxcount)   //Проверка колличества записанных строк
                {
                    remakeOutputFile();     //Если количество строк превышает допустимое, создать новый выходной файл
                    scounter = 0;
                }

            } while ((element[(int)Constants.position.word] != null) || (element[(int)Constants.position.divide] != null));
            textReader.close();
        }

        /// <summary>
        /// Подключение файловых ресурсов
        /// </summary>
        private void connectResourses()
        {
            textReader = new Reader(pathToInputFile);
            textWriter = new Writer(pathToOutputFile);
            dictionary = new Dictionary(pathToDictionary);

            textReader.open();
            textWriter.open();
            dictionary.start();
        }

        /// <summary>
        /// Проверка файлов на соответствие
        /// выбрасывает исключения
        /// </summary>
        /// <exception cref="WrongSizeOfFileExeption">"Invalid size of input file!"</exception>
        /// <exception cref="WrongSizeOfFileExeption">"Invalid size of dictionary file!"</exception>
        private void validateFiles()
        {
            if (textReader.getFileSize() > Constants.MAX_SIZE_OF_FILE)
            {
                throw new WrongSizeOfFileExeption("Invalid size of input file!");
            }
            
            if (dictionary.getFileSize() > Constants.MAX_SIZE_OF_FILE)
            {
                throw new WrongSizeOfFileExeption("Invalid size of dictionary file!");
            }
        }

        /// <summary>
        /// Прочитать из файла пару слово-разделитель
        /// </summary>
        private void read()
        {
            element = textReader.getElement();                      //Чтение слова и разделителя в буфер
            string divide = element[(int)Constants.position.divide];
            char divSimbol = ' ';

            if (divide != null)
            {
                divSimbol = divide[divide.Length - 1];              //Получение последнего символа разделителя
            }                    

            if (divSimbol == '\n')                                  //Если последний символ разделителя - перенос стороки, прибавить счётчик строк
            {
                scounter++;
            }
        }

        /// <summary>
        /// Записать в файл пару слово-разделитель
        /// </summary>
        private void write()
        {
            if (dictionary.compare(element[(int)Constants.position.word])) //Запись слова и разделителя в выходной файл с выделением, если слово есть в словаре
            {
                textWriter.printBold(element);
            }
            else
            {
                textWriter.printCommon(element);                            //Запись слова и разделителя в выходной файл без выделения, если слова нет в словаре
            }
        }

        /// <summary>
        /// Пересоздать выходной файл
        /// </summary>
        void remakeOutputFile()
        {
            fcounter++;
            string newPathToOutputFile = null;
            newPathToOutputFile = pathToOutputFile.Substring(0, pathToOutputFile.Length - 5);
            newPathToOutputFile += "(";  
            newPathToOutputFile += fcounter.ToString();
            newPathToOutputFile += ")";
            newPathToOutputFile += ".html";
            textWriter = new Writer(newPathToOutputFile);
        }

        private string pathToInputFile;     //Путь ко входному файлу
        private string pathToOutputFile;    //Путь к выходному файлу
        private string pathToDictionary;    //Путь к файлу словаря
        private Reader textReader;          //Экземпляр объекта для чтения файла
        private Writer textWriter;          //Экземпляр объекта для записи в файл
        private Dictionary dictionary;      //Экземпляр объекта для создания словаря
        private List<string> element;       //Буфер для пары слово-разделитель
        private Int32 scounter;             //Счётчик строк во входном файле
        private Int32 fcounter;             //Счётчик созданных выходных файлов
        private Int32 maxcount;             //Максимальное колличество строк в выходном файле

    }
}
