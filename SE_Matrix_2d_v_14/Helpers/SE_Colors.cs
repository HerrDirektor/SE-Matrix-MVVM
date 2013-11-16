using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SE_Matrix_2d_v_14.Helpers
{
    public class SE_Colors
    {
        /// <summary>
        /// Конвертирует цвет из строки "#FF112233" в SolidColorBrush,
        /// поддерживается как с заданием компоненты А (8-9 знаков) так и без (6-7 знаков)
        /// </summary>
        /// <param name="color">Цвет заданный как строка ("#FF112233")</param>
        /// <returns>Возвращает цвет как объект SolidColorBrush</returns>
        public SolidColorBrush StringToBrush(string color)
        {
            color = color.Replace("#", "");
            
            switch(color.Length)
            {
               case 8 :  
                    return new SolidColorBrush(Color.FromArgb(
                        byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(color.Substring(6, 2), System.Globalization.NumberStyles.HexNumber) ));
               case 6: 
                  return new SolidColorBrush(Color.FromArgb(
                      255,
                      byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                      byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                      byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) ));
              default: return null;
            }
        }

        /// <summary>
        /// Конвертирует цвет из объекта SolidColorBrush в ARGB и записывает это в Dictionary
        /// с соответствующими ключами
        /// </summary>
        /// <param name="color">Цвет, заданный как объект SolidColorBrush</param>
        /// <returns>Возвращает цвет, записанный в Dictionary</returns>
        public Dictionary<string, int> BrushToDictionary(SolidColorBrush color)
        {
            Dictionary<string, int> colorArgb = new Dictionary<string, int>();

            colorArgb["A"] = color.Color.A;
            colorArgb["R"] = color.Color.R;
            colorArgb["G"] = color.Color.G;
            colorArgb["B"] = color.Color.B;

            return colorArgb;
        }

        /// <summary>
        /// Формирует цвет из Dictionary в объект SolidColorBrush
        /// </summary>
        /// <param name="toBrush">Цвет, находящийся в Dictionary с соответствующими ключами ARGB</param>
        /// <returns>Возвращает цвет как объект SolidColorBrush</returns>
        public SolidColorBrush DictionaryToBrush(Dictionary<string, int> toBrush)
        {
            return new SolidColorBrush(new Color()
            {
                A = (byte)toBrush["A"],
                R = (byte)toBrush["R"],
                G = (byte)toBrush["G"],
                B = (byte)toBrush["B"]
            });
        }

        /// <summary>
        /// Конвертирует цвет, заданный строкой "#FF112233" в Dictionary с соответствующими ключами ARGB
        /// поддерживается как с заданием компоненты А (8-9 знаков) так и без (6-7 знаков)
        /// </summary>
        /// <param name="toDictionary">Цвет как строка "#FF112233"</param>
        /// <returns>Возвращает Dictionary с ключами ARGB</returns>
        public Dictionary<string, int> StringToDictionary(string toDictionary)
        {
            toDictionary = toDictionary.Replace("#", "");
            Dictionary<string, int> colorArgb = new Dictionary<string, int>();

            switch (toDictionary.Length)
            {
                case 8:
                    colorArgb["A"] = byte.Parse(toDictionary.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    colorArgb["R"] = byte.Parse(toDictionary.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    colorArgb["G"] = byte.Parse(toDictionary.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                    colorArgb["B"] = byte.Parse(toDictionary.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                    break;
                case 6:
                    colorArgb["A"] = 255;
                    colorArgb["R"] = byte.Parse(toDictionary.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    colorArgb["G"] = byte.Parse(toDictionary.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    colorArgb["B"] = byte.Parse(toDictionary.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                    break;
                default:
                    colorArgb["A"] = 255;
                    colorArgb["R"] = 255;
                    colorArgb["G"] = 255;
                    colorArgb["B"] = 255;
                    break;
            }

            return colorArgb;
        }

        /// <summary>
        /// Функция формирует коэффициент, который будет в последствии использоваться для создания градиента из
        /// падающих символов в матрице
        /// </summary>
        /// <param name="gradientFrom">Dictionary с ключами ARGB. Цвет для начала градиента, второй символ</param>
        /// <param name="gradientTo">Dictionary с ключами ARGB. Цвет для конца градиента, последний симол</param>
        /// <param name="count"></param>
        /// <returns>Dictionary с ключами ARGB и значениями коэффициента для каждого цвета</returns>
        public Dictionary<string, int> GetСoefficientFromGradient(Dictionary<string, int> gradientFrom, Dictionary<string, int> gradientTo, int count)
        {
            Dictionary<string, int> coefficientArgb = new Dictionary<string, int>();

            coefficientArgb["A"] = (int)Math.Round((gradientFrom["A"] - 10) / (double)(count + 1)) - 1;
            coefficientArgb["R"] = (int)Math.Round((gradientFrom["R"] - gradientTo["R"]) / (double)(count + 1)) - 1;
            coefficientArgb["G"] = (int)Math.Round((gradientFrom["G"] - gradientTo["G"]) / (double)(count + 1)) - 1;
            coefficientArgb["B"] = (int)Math.Round((gradientFrom["B"] - gradientTo["B"]) / (double)(count + 1)) - 1; 

            return coefficientArgb;
        }

        /// <summary>
        /// Формирует цвет каждого сивпола в змейке матрицы для создания градиента
        /// </summary>
        /// <param name="gradientFrom">Dictionary с ключами ARGB. Цвет для начала градиента, второй символ</param>
        /// <param name="coefficientFromGradient">Dictionary с ключами ARGB. Коэффициент для каждой компоненты цвета</param>
        /// <param name="coefficient">Коэффициент, расчитанный на основе порядкового номера симвоа в змейке матрицы</param>
        /// <returns>Цвет, как объект SolidColorBrush</returns>
        public SolidColorBrush GetSymbolColorForGradient(Dictionary<string, int> gradientFrom, Dictionary<string, int> coefficientFromGradient, int coefficient)
        {
            Dictionary<string, int> symbolColorForGradient = new Dictionary<string, int>();

            symbolColorForGradient["A"] = (gradientFrom["A"] - (coefficient * coefficientFromGradient["A"]));
            symbolColorForGradient["R"] = (gradientFrom["R"] - (coefficient * coefficientFromGradient["R"]));
            symbolColorForGradient["G"] = (gradientFrom["G"] - (coefficient * coefficientFromGradient["G"]));
            symbolColorForGradient["B"] = (gradientFrom["B"] - (coefficient * coefficientFromGradient["B"]));

            return DictionaryToBrush(symbolColorForGradient);
        }
    }
}
