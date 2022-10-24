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

        /// <summary>
        /// Lista użytkowników
        /// </summary>
        public User[] users { get; set; }

        /// <summary>
        /// Obecnie grający użytkownik
        /// </summary>
        public User currentUser { get; set; }

        /// <summary>
        /// Uzyskana punty
        /// </summary>
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
            if(currentUser == null) this.mainMenu = new Menu(options, title, "Witaj w grze! Wybierz Start aby rozpocząć.");
            else this.mainMenu = new Menu(options, currentUser, title, "Wybierz Start aby rozpocząć.");

            int selectedIndex = mainMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    runFirstChoice();
                    break;
                case 1:
                    runOptionsMenu();
                    break;
                case 2:
                    runUserMenu();
                    break;
                case 3:
                    exitGame();
                    break;


            }
                  
        }

        /// <summary>
        /// Uruchamia menu opcji
        /// </summary>
        public void runOptionsMenu()
        {
            string[] options = 
            {
                "Kolory",
                "Sterowanie",
                "Muzyka",
                "Wstecz",
            };

            Menu optionsMenu = new Menu(options, title, "Wybierz opcje z listy poniżej: ");
            int selectedOption = optionsMenu.Run();

        }

        /// <summary>
        /// Uruchamia menu użytkownika
        /// </summary>
        public void runUserMenu()
        {
            string[] options = { "Wczytaj użytkownika", "Stwórz użytkownika", "Wstecz" };
            Menu userMenu = new Menu(options, title, "Wybierz opcje: ");
            Console.Clear();
            int selectedOption = userMenu.Run();

            if(selectedOption == 0)
            {
                string[] usersNames = loadUsers();
                showUsers(usersNames);
            }
            else if(selectedOption == 1)
            {
                addUser();
            }
            else if(selectedOption == 2)
            {
                runMainMenu();
            }

        }

        public void addUser()
        {
            loadUsers(true);
            string name;
            Console.Clear();
            Console.WriteLine(title); ;
            Console.WriteLine("Podaj nazwę użytkownika: ");
            Console.CursorVisible = true;
            name = Console.ReadLine();
            Console.CursorVisible = false;  
            users[users.Length - 1] = new User(name);
            currentUser = users[users.Length - 1];
            saveUsers();
            runMainMenu();
        }

        public void showUsers(string[] usersNames)
        {
            Menu usersMenu = new Menu(usersNames, title, "Wybierz użytkownika z listy");
            int selectedItem = usersMenu.Run();

            this.currentUser = users[selectedItem];

            runMainMenu();

        }

        /// <summary>
        /// Wczytanie użytkowników z pliku txt
        /// </summary>
        public string[] loadUsers(bool isNew = false)
        {
            string[] usersNames;
            string workingDirectory = Environment.CurrentDirectory;
            using (StreamReader usersFile = new StreamReader(Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\users.txt"))
            {
                int numberOfUsers = int.Parse(usersFile.ReadLine());

                if(!isNew) users = new User[numberOfUsers];
                else users = new User[numberOfUsers + 1];

                usersNames = new string[numberOfUsers];

                int index = 0;
                int indexNames = 0;
                while (!usersFile.EndOfStream)
                {
                    string name = usersFile.ReadLine();
                    int maxScore = int.Parse(usersFile.ReadLine());
                    string bestTime = usersFile.ReadLine();

                    usersNames[indexNames++] = name;
                    User u = new User(name ,bestTime ,maxScore);
                    users[index++] = u;
                }
            }
            return usersNames;
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
            DateTime dateTime = DateTime.Now;
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
            showQuestions(dateTime);

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
        /// Wypisuje czas
        /// </summary>
        /// <param name="hours">godziny</param>
        /// <param name="minutes">minuty</param>
        /// <param name="seconds">sekndy</param>
        /// <returns></returns>
        private string printTime(int hours, int minutes, int seconds)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            if (hours == 0)
            {
                if (minutes == 0)
                {
                    Console.WriteLine(seconds + " sec.");
                    Console.ResetColor();
                    return seconds + " sec.";
                }
                else
                {
                    Console.WriteLine(minutes + " min. " + seconds + " sec.");
                    Console.ResetColor();
                    return minutes + " min. " + seconds + " sec.";
                }

            }
            else 
            {
                Console.WriteLine(hours + " hour " + minutes + " min." + seconds + " sec.");
                Console.ResetColor();
                return hours + " hour " + minutes + " min." + seconds + " sec.";
            }
        }

        /// <summary>
        /// Wyświetla pytania na ekran
        /// </summary>
        public void showQuestions(DateTime startTime)
        {
            //DateTime startTime = DateTime.Now;
            DateTime endTime;

            bool[] flags = new bool[questions.Length];
            Question q;
            //dziesięć losowych pytań z bazy
            for(int i=0; i< 10; i++)
            {
                Random random = new Random();
                int index = random.Next(questions.Length);
                if (!flags[index])
                {
                    flags[index] = true;
                    q = questions[index];
                }
                else
                {
                    i--;
                    continue;
                }
                
                //Question q = questions[index];
                if(points == 10)
                {
                    endTime = DateTime.Now;
                    Console.Clear();
                    Console.WriteLine(asciiSymbol.win);
                    TimeSpan dt = endTime - startTime;
                    int seconds = dt.Seconds;
                    int minutes = dt.Minutes;
                    int hours = dt.Hours;
                    string bestT = printTime(hours, minutes, seconds);
                   // Console.WriteLine(minutes + "min. " + seconds + "sec.");
                    if(currentUser != null && currentUser.maxScore < points)
                    {
                        currentUser.maxScore = points;
                        currentUser.bestTime = bestT;
                        saveUsers();
                    }
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

            endTime = DateTime.Now;
            Console.Clear();
            Console.WriteLine(asciiSymbol.score);
            string p = asciiSymbol.getPointsString(points);
            Console.WriteLine(p);
            TimeSpan deltaTime = endTime - startTime;
            int sec = deltaTime.Seconds;
            int min = deltaTime.Minutes;
            int h = deltaTime.Hours;
            string bestTime = printTime(h, min, sec);
            //Console.WriteLine(sec + "sec.");
            //Console.WriteLine(endTime - startTime);
            if (currentUser != null && currentUser.maxScore < points)
            {
                currentUser.maxScore = points;
                currentUser.bestTime = bestTime;
                saveUsers();
            }
            points = 0;
            Console.WriteLine("Wciśnij dowony przycisk aby kontunuować ...");
            Console.ReadKey(true);
            Console.Clear();
            runMainMenu();

        }

        /// <summary>
        /// Zapisuje użytkowników do pliku txt
        /// </summary>
        public void saveUsers()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string[] lines;
            lines = new string[users.Length * 3 + 1];
            lines[0] = users.Length.ToString();
            int index = 0;
            for(int i=1; i < lines.Length; i+=3)
            {
                lines[i] = users[index].Name;
                lines[i+1] = users[index].maxScore.ToString();
                lines[i+2] = users[index].bestTime.ToString();
                index++;
            }
            File.WriteAllLines(Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\users.txt", lines);
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
