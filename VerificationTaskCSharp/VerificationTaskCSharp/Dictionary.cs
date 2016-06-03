using System;
using System.Collections.Generic;

namespace VerificationTaskCSharp
{
    /// <summary>
    /// Класс <c>Dictionary</c> считывает из файла и хранит словарь
    /// </summary>
    class Dictionary
    {
        /// <summary>
        /// Конструктор, устанавливает путь к файлу
        /// </summary>
        /// <param name="_path">Путь к файлу</param>
        public Dictionary(string _path)
        {
            counter = 0;
            data = new string [1];
            reader = new Reader(_path);

            element = new List<string>
            {
                null,
                null
            };
        }

        /// <summary>
        /// Открывает файл и считывает из него словарь,
        /// Выбрасывает исключение есль путь указан неверно
        /// </summary>
        /// <exception cref="WrongPathToFileExeption"></exception>
        public void start()
        {
            try
            {
                reader.open();
            }
            catch (WrongPathToFileExeption)
            {
                throw new WrongPathToFileExeption("Invalid path to dictionary file!");
            }

            createDictionary();
            reader.close();
        }

        /// <summary>
        /// Ищет, содержется ли слово в словаре
        /// </summary>
        /// <param name="_word">Искомое слово</param>
        /// <returns>Если слово найдено возвращает <c>true</c></returns>
        public bool compare(string _word)
        {
            if (counter == 0)
            {
                return false;
            }
            for (Int32 i = 0; i <= data.Length - 1; i++)
            {
                if (data[i] == _word)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает размер файла
        /// </summary>
        /// <returns>Размер файла в байтах</returns>
        public Int64 getFileSize()
        {
            return reader.getFileSize();
        }

        /// <summary>
        /// Вставляет слово в словарь
        /// </summary>
        /// <param name="_word">Слово</param>
        private void putWord(string _word)
        {
            data[data.Length - 1] = _word;
            Array.Resize<string>(ref data, data.Length + 1);
        }

        /// <summary>
        /// Считывает словарь из файла, выбрасывает исключение
        /// если колличество слов превышает максимальное
        /// </summary>
        private void createDictionary()
        {
            element = reader.getElement();                                              //Считываем первую пару слово разделитель

            while (definitionValidate())                                                //Пока слово корректно заполнять словарь
            {
                counter++;                                                              //Прибавить счётчик слов
                if (counter > Constants.MAX_COUNT_OF_DEFINITION)                        //Если колличество слов превышает допустимое, выбросить исключение
                {
                    throw new WrongSizeOfFileExeption("Invalid number of definitions!");
                }
                putWord(element[(int)Constants.position.word]);                         //Поместить слово в словарь
                element = reader.getElement();                                          //Получить следующее слово и разделитель из файла
            } 
        }
        
        /// <summary>
        /// Проверяет соответстуе ли пара 
        /// слово-разделитель структуре словаря
        /// </summary>
        /// <returns></returns>                                      
        bool definitionValidate()
        {
            string divide = element[(int)Constants.position.divide];                //Разделитель        
            string word = element[(int)Constants.position.word];                    //Слово
            char divSimbol = ' ';                                                   //Последний символ разделителя

            if (divide != null)
            {
                divSimbol = divide[divide.Length - 1];
            }
            if (((divSimbol == '\n') || (divide == null)) && (word != null))        //Если слово не пустое, а разделитель пустой или содержит перенос строки, то вернуть true (слово корректно)
            {
                return true;
            }
            else
            {
                return false;
            }    
        }

        private Int32 counter;          //Счётчик слов
        private Reader reader;          //Экземпляр объекта для чтения файла
        string [] data;                 //Словарь
        private List<string> element;   //Пара слово-разделитель
    }
}
