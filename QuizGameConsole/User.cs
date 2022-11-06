using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameConsole
{
    public class User
    {
        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Najlepszy wynik użytkownika
        /// </summary>
        public int maxScore { get; set; }

        /// <summary>
        /// Czas w którym osiągnięto najlepszy wynik
        /// </summary>
        public string bestTime { get; set; }

        /// <summary>
        /// Kolor wybrany przez użytkownika
        /// </summary>
        public ConsoleColor userColor { get; set; }

        /// <summary>
        /// Klawisze wybrane przez użytkownika
        /// </summary>
        public ControlKeys userKeys { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="name">Nazwa użytkownika</param>
        /// <param name="maxScore">Najwyższy wynika użytkownika domyślnie 0</param> 
        public User(string name,string bestTime = "" , int maxScore = 0)
        {
            this.Name = name;
            this.maxScore = maxScore;
            this.bestTime = bestTime;

            //domyślne
            userColor = ConsoleColor.White;
            userKeys = new ControlKeys();
        }
    }
}
