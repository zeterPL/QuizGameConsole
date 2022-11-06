using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameConsole
{
    public class ControlKeys
    {
        /// <summary>
        /// Przycisk górny
        /// </summary>
        private ConsoleKey UpKey;

        /// <summary>
        /// Przycisk dolny
        /// </summary>
        private ConsoleKey DownKey;

        /// <summary>
        /// Domyślny konstruktor
        /// </summary>
        public ControlKeys() 
        {
            UpKey = ConsoleKey.UpArrow;
            DownKey = ConsoleKey.DownArrow;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="upKey">górny przycisk</param>
        /// <param name="downKey">dolny przycisk</param>
        public ControlKeys(ConsoleKey upKey, ConsoleKey downKey)
        {
            UpKey = upKey;
            DownKey = downKey;
        }

        /// <summary>
        /// Sprawdza czy można przypisać dany klawisz
        /// </summary>
        /// <param name="key">Klawisz do sprawdzenia</param>
        /// <returns>Czy można przypisać klawisz</returns>
        private bool isKeyCorrect(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter || key == ConsoleKey.Escape)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Przypisanie górnego przycisku
        /// </summary>
        public void bindUpKey()
        {
            ConsoleKey key;
            do
            {
                Console.WriteLine("Wciśnij górny przycisk");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;                             
                if(!isKeyCorrect(key))
                {
                    Console.WriteLine("Wybierz inny przycisk niż " + key.ToString());
                    Console.WriteLine("Wciśnij dowony przycisk aby kontunuować ...");
                    Console.ReadKey(true);

                    (int x, int y) = Console.GetCursorPosition();
                    Console.SetCursorPosition(x, y - 1);
                    Console.WriteLine(new String(' ', Console.WindowWidth));
                    Console.SetCursorPosition(x, y - 2);
                    Console.WriteLine(new String(' ', Console.WindowWidth));
                    Console.SetCursorPosition(x, y - 3);
                    Console.WriteLine(new String(' ', Console.WindowWidth));
                    Console.SetCursorPosition(x, y - 3);
                }
            } while (!isKeyCorrect(key));

            this.UpKey = key;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Przypisano przycisk - " + key.ToString());
            Console.ResetColor();

        }

        /// <summary>
        /// Przypisanie dolnego przycisku
        /// </summary>
        public void bindDownKey()
        {
            ConsoleKey key;
            do
            {
                Console.WriteLine("Wciśnij dolny przycisk");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
                if (!isKeyCorrect(key))
                {
                    Console.WriteLine("Wybierz inny przycisk niż " + key.ToString());
                    Console.WriteLine("Wciśnij dowony przycisk aby kontunuować ...");
                    Console.ReadKey(true);

                    (int x, int y) = Console.GetCursorPosition();
                    Console.SetCursorPosition(x, y - 1);
                    Console.WriteLine(new String(' ', Console.WindowWidth));
                    Console.SetCursorPosition(x, y - 2);
                    Console.WriteLine(new String(' ', Console.WindowWidth));
                    Console.SetCursorPosition(x, y - 3);
                    Console.WriteLine(new String(' ', Console.WindowWidth));
                    Console.SetCursorPosition(x, y - 3);
                }
            } while (!isKeyCorrect(key));

            this.DownKey = key;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Przypisano przycisk - " + key.ToString());
            Console.ResetColor();
        }


        public ConsoleKey getUpKey()
        {
            return UpKey;
        }

        public ConsoleKey getDownKey()
        {
            return DownKey;
        }
    }
}
