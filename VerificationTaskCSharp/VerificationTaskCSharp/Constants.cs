
using System;
using System.Text;

namespace VerificationTaskCSharp
{
    ///<summary>
    ///Класс <c>Constants</c>
    ///содержит глобальные константы
    ///</summary>
    class Constants
    {
        /// <summary>
        /// Максимальное колличество слов в словаре
        /// </summary>
        public static readonly Int32 MAX_COUNT_OF_DEFINITION = 100000;
        /// <summary>
        ///  Максимально допустимый размер файла
        /// </summary>
        public static readonly Int32 MAX_SIZE_OF_FILE = 2000000;
        /// <summary>
        /// Кодировка, используемая в файловых потоках
        /// </summary>
        public static readonly Encoding encoding = Encoding.GetEncoding(1251);
        /// <summary>
        /// Перечисление, служит для удобства обозначения
        /// позиции слова и разделителя
        /// </summary>
        public enum position { word, divide };
    }
}
