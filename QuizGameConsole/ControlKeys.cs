using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameConsole
{
    public class ControlKeys
    {
        private ConsoleKey UpKey;

        private ConsoleKey DownKey;

        public ControlKeys() { }

        public ControlKeys(ConsoleKey upKey, ConsoleKey downKey)
        {
            UpKey = upKey;
            DownKey = downKey;
        }

        private bool isKeyCorrect(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter || key == ConsoleKey.Escape)
            {
                return false;
            }
            else return true;
        }

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
