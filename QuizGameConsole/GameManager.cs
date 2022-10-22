using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameConsole
{
    public class GameManager
    {
        /// <summary>
        /// Menu głóne gry
        /// </summary>
        public Menu mainMenu { get; set; }

        /// <summary>
        /// Znaki do wyświetlania punktacji
        /// </summary>
        public AsciiArtSymbol asciiSymbol { get; set; } = new AsciiArtSymbol();

        /// <summary>
        /// Tytuł gry
        /// </summary>
        public string title { get; set; } = @"
 ██████╗ ██╗   ██╗██╗███████╗     ██████╗  █████╗ ███╗   ███╗███████╗
██╔═══██╗██║   ██║██║╚══███╔╝    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
██║   ██║██║   ██║██║  ███╔╝     ██║  ███╗███████║██╔████╔██║█████╗  
██║▄▄ ██║██║   ██║██║ ███╔╝      ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
╚██████╔╝╚██████╔╝██║███████╗    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
 ╚══▀▀═╝  ╚═════╝ ╚═╝╚══════╝     ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝
                                                                     
";
        /// <summary>
        /// Lista pytań
        /// </summary>
        public Question[] questions { get; set; }

        public int points { get; set; } = 8;

        /// <summary>
        /// Inicjalizuje gre
        /// </summary>
        public void startGame()
        {
            Console.CursorVisible = false;
            //Console.WriteLine(title);
            runMainMenu();
        }

        /// <summary>
        /// Uruchamia menu główne
        /// </summary>
        private void runMainMenu()
        {
            string[] options = { "Start", "Opcje" ,"Gracz" ,"Wyjście" };
            this.mainMenu = new Menu(options, title, "Witaj w grze! Wybierz Start aby rozpocząć.");

            int selectedIndex = mainMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    runFirstChoice();
                    break;
                case 1:
                    //displayoptions
                    break;
                case 2:
                    //displayUser
                    break;
                case 3:
                    exitGame();
                    break;


            }
                  
        }

        /// <summary>
        /// Wychodzi z gry
        /// </summary>
        public void exitGame()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        /// <summary>
        /// Uruchamia gre
        /// </summary>
        public void runFirstChoice()
        {
            Console.Clear();
            /* TEST 
            string[] options =
            {
                "A: Odpowiedź 1",
                "B: Odpowiedź 2",
                "C: Odpowiedź 3",
                "D: Odpowiedź 4",
            };
            Menu questionsMenu = new Menu(options, title, "Pytanie 1");
            questionsMenu.Run();
            */
            loadQuestions();
            showQuestions();

        }

        /// <summary>
        /// Koloruje wybraną odpowiedź na podstawie jej poprawności
        /// </summary>
        /// <param name="isCorrect">Czy poprawna</param>
        /// <param name="selectedAnswer">Wybrana odpowiedź</param>
        /// <param name="q">Obiekt pytania</param>
        private void colorAnswer(bool isCorrect, int selectedAnswer, Question q)
        {
            (int l, int t) = Console.GetCursorPosition();
            // int pos = t - (selectedAnswer % 4);
            Console.SetCursorPosition(0, t - (4 - selectedAnswer));
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, t - (4 - selectedAnswer));
            Console.ForegroundColor = ConsoleColor.Black;
            if(isCorrect) Console.BackgroundColor = ConsoleColor.Green;
            else Console.BackgroundColor = ConsoleColor.Red;
            Console.Write($" * << {q.answerOptions[selectedAnswer]} >>");
            Console.ResetColor();
            Console.SetCursorPosition(l, t);

            
        }

        /// <summary>
        /// Wyświetla pytania na ekran
        /// </summary>
        public void showQuestions()
        {
            foreach(Question q in questions )
            {
                if(points == 10)
                {
                    Console.Clear();
                    Console.WriteLine(asciiSymbol.win);
                    
                    points = 0;
                    Console.WriteLine("Wciśnij dowony przycisk aby kontunuować ...");
                    Console.ReadKey(true);
                    Console.Clear();
                    runMainMenu();
                    
                }

                Menu questionMenu = new Menu(q.answerOptions ,points, title, q.content);

                int selectedAnswer = questionMenu.Run();
                if(selectedAnswer == q.correctAnswer)
                {                   
                    colorAnswer(true, selectedAnswer, q);
                    Console.WriteLine("Poprawna Odpowiedź");
                    points++;
                }
                else
                {
                    colorAnswer(false, selectedAnswer, q);
                    Console.WriteLine("Błędna odwowiedź");
                }
                Console.WriteLine("Wciśnij dowony przycisk aby kontunuować ...");
                Console.ReadKey(true);
                //Console.Clear(); ///
                clearConsoleLines(0, 8);
            }
            
            Console.Clear();
            Console.WriteLine(asciiSymbol.score);
            string p = asciiSymbol.getPointsString(points);
            Console.WriteLine(p);
            points = 0;
            Console.WriteLine("Wciśnij dowony przycisk aby kontunuować ...");
            Console.ReadKey(true);
            runMainMenu();

        }

        /// <summary>
        /// Czyści konsole od punktu top,left
        /// </summary>
        /// <param name="top">Odległośc od góry konsoli</param>
        /// <param name="left">Odległość od lewej krawędzi konsoli</param>
        public void clearConsoleLines(int top, int left)
        {
            Console.SetCursorPosition(top, left);
            for(int i =0; i<Console.WindowHeight; i++)
                Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(left, top);
        }

        /// <summary>
        /// Wczytuje pytania z pliku txt
        /// </summary>
        public void loadQuestions()
        {
            string workingDirectory = Environment.CurrentDirectory;
            using(StreamReader questionsFile = new StreamReader(Directory.GetParent(workingDirectory).Parent.Parent.FullName+"\\questions.txt"))
            {
                int numberOfQuestions = int.Parse(questionsFile.ReadLine());

                questions = new Question[numberOfQuestions];
                

                int index = 0;
                while(!questionsFile.EndOfStream)
                {
                    string[] questionAnswers = new string[4];
                    string content = questionsFile.ReadLine();
                    for(int i = 0; i < 4; i++)
                    {
                        questionAnswers[i] = questionsFile.ReadLine();
                    }
                    int correctAnswer = int.Parse(questionsFile.ReadLine());

                    Question q = new Question(content, questionAnswers, correctAnswer);
                    questions[index++] = q;
                }
            }
        }
    }
}
