using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameConsole
{
    public class Menu
    {   
        /// <summary>
        /// Opcje dostępne w menu
        /// </summary>
        public string[] options { get; set; }

        /// <summary>
        /// Numer opcji wybranej przez użytkownika
        /// </summary>
        public int selectedOption { get; set; }

        /// <summary>
        /// Tytuł - logo gry
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Opis pojawiający się przed opcjami
        /// </summary>
        public string caption { get;set; }

        /// <summary>
        /// Liczba punktów
        /// </summary>
        public int? points { get;set; }

        /// <summary>
        /// Liczba punktów
        /// </summary>
        public int numberOfOptions { get; set; }

        /// <summary>
        /// Obecnie grający użytkownik
        /// </summary>
        User currentUser { get; set; }

        /// <summary>
        /// Główny kolor menu
        /// </summary>
        ConsoleColor mainColor { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="options">Opcje</param>
        /// <param name="title">Opcjonalny tytuł</param>
        /// <param name="caption">Opcjonalny opis</param>
        public Menu(string[] options, string title = "", string caption = "", ConsoleColor consoleColor = ConsoleColor.White)
        {
            this.options = options;
            this.caption = caption;
            this.selectedOption = 0;
            this.title = title;
            this.numberOfOptions = options.Length;
            this.mainColor = consoleColor;
        }

        /// <summary>
        /// Konstruktor z punktami
        /// </summary>
        /// <param name="options">Opcje</param>
        /// <param name="points">Punkty</param>
        /// <param name="title">pocjonalny tytuł</param>
        /// <param name="caption">Opcjonalny opis</param>
        public Menu(string[] options, int points, string title = "", string caption = "", ConsoleColor consoleColor = ConsoleColor.White)
        {
            this.options = options;
            this.caption = caption;
            this.selectedOption = 0;
            this.title = title;
            this.points = points;
            this.numberOfOptions = options.Length;
            this.mainColor = consoleColor;
        }

        /// <summary>
        /// Konstruktor z obecnym użytkownikiem
        /// </summary>
        /// <param name="options">Opcje</param>
        /// <param name="currentUser">Obecnie grający user</param>
        /// <param name="title">Opcjonalny tytuł</param>
        /// <param name="caption">Opcjonalny opis</param>
        public Menu(string[] options,User currentUser, string title = "", string caption = "", ConsoleColor consoleColor = ConsoleColor.White)
        {
            this.options = options;
            this.caption = caption;
            this.selectedOption = 0;
            this.title = title;
            //this.points = points;
            this.numberOfOptions = options.Length;
            this.currentUser = currentUser;
            this.mainColor = consoleColor;
        }

        /// <summary>
        /// Włącza menu
        /// </summary>
        /// <returns>Zwraca indeks wybranej opcji</returns>
        public int Run()
        {
            ConsoleKey keyPressed;

            //int change = 0;

            Console.Clear();
            AsciiArtSymbol asciiSymbol = new AsciiArtSymbol();

            Console.ForegroundColor = mainColor;
            Console.Write(title);
            Console.ResetColor();

            if(currentUser != null)
            {
                string frame = asciiSymbol.getUserNameFrameString("Witaj " + currentUser.Name + "! " + "Twój najlepszy wynik to: " + currentUser.maxScore + " Czas: " + currentUser.bestTime);
                // Console.WriteLine("Witaj " + currentUser.Name + "! " + "Twój najlepszy wynik to: " + currentUser.maxScore + " Czas: " + currentUser.bestTime);
               Console.WriteLine(frame);
            }
           // (int l, int r) = Console.GetCursorPosition();
            //Console.WriteLine(l + " " + r); //0 8 pozycja do czyszczenia

            if(points != null)
            {
                string p = asciiSymbol.getPointsString((int)points);

                Console.ForegroundColor = mainColor;
                Console.WriteLine(p);
                Console.ResetColor();
                /*
                if(points == 0 ) Console.WriteLine(asciiSymbol.zero);
                if (points == 1 ) Console.WriteLine(asciiSymbol.one);
                if (points == 2 ) Console.WriteLine(asciiSymbol.two);
                if (points == 3 ) Console.WriteLine(asciiSymbol.three);
                if (points == 4 ) Console.WriteLine(asciiSymbol.four);
                if (points == 5 ) Console.WriteLine(asciiSymbol.five);
                if (points == 6 ) Console.WriteLine(asciiSymbol.six);
                if (points == 7 ) Console.WriteLine(asciiSymbol.seven);
                if (points == 8 ) Console.WriteLine(asciiSymbol.eight);
                if (points == 9 ) Console.WriteLine(asciiSymbol.nine);
                if (points == 10 ) Console.WriteLine(asciiSymbol.ten);
                */
            }
            //Console.WriteLine(asciiSymbol.zero);
            //(int l, int r) = Console.GetCursorPosition();
            //Console.WriteLine("l: " + l +" r: " + r);
           // Console.SetCursorPosition(80, 0);
           // Console.Write(@"TEST");
           // Console.SetCursorPosition(l, r);
           // Console.Write(asciiSymbol.zero);
           // Console.Write(string.Concat(asciiSymbol.zero, asciiSymbol.slash, asciiSymbol.ten));
            Console.WriteLine(caption);
            for(int i =0; i<numberOfOptions; i++) Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("");

            do
            {
               // Console.Clear();
               // Console.WriteLine(title);
                //Console.WriteLine(caption);
                

                ConsoleClearOptions();
                showScreen();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption == -1) selectedOption = options.Length - 1;
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption == options.Length) selectedOption = 0;
                }


            } while (keyPressed != ConsoleKey.Enter);

            return selectedOption;
        }

        /// <summary>
        /// Czyści opcje w konsoli - zapobiega 'mruganiu'
        /// </summary>
        public void ConsoleClearOptions()
        {
            (int l, int t) = Console.GetCursorPosition();
            int index = 0;
            for(int i = 1; i <= numberOfOptions; i++)
            {
                Console.SetCursorPosition(0, t - i);
                Console.Write(new string(' ', Console.WindowWidth));
                index = i;
            }

            
            Console.SetCursorPosition(0, t-index);
        }

        /// <summary>
        /// Wyświetla opcje i im nadaje odpowiednie kolory 
        /// </summary>
        public void showScreen()
        {
            for(int i = 0; i < options.Length; i++)
            {
                string currentOption = options[i];
                string prefix = " ";

                if(i == selectedOption)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($" {prefix} << {currentOption} >>");
            }
            Console.ResetColor();
        }
    }
}
