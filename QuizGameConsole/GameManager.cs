using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// Główny kolor menu
        /// </summary>
        public ConsoleColor mainColor { get; set; }

        /// <summary>
        /// Klawisze do sterownia w menu
        /// </summary>
        public ControlKeys controlKeys { get; set; }

        /// <summary>
        /// Uzyskana punty
        /// </summary>
        public int points { get; set; } = 8;

        /// <summary>
        /// Inicjalizuje gre
        /// </summary>
        public void startGame()
        {
            //Niewidoczy kursor
            Console.CursorVisible = false;

            //Domyślny kolor menu
            mainColor = ConsoleColor.White;

            //Domyślne klawisze strzałki góra-dół
            controlKeys = new ControlKeys();

            runMainMenu();
        }

        /// <summary>
        /// Uruchamia menu główne
        /// </summary>
        private void runMainMenu()
        {
            string[] options = { "Start", "Opcje" ,"Gracz" ,"Wyjście" };
            if(currentUser == null) this.mainMenu = new Menu(controlKeys, options, title, "Witaj w grze! Wybierz Start aby rozpocząć.", mainColor);
            else this.mainMenu = new Menu(controlKeys, options, currentUser, title, "Wybierz Start aby rozpocząć.", mainColor);

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
                "Wstecz",
            };

            Menu optionsMenu = new Menu(controlKeys, options, title, "Wybierz opcje z listy poniżej: ", mainColor);
            int selectedOption = optionsMenu.Run();

            switch(selectedOption)
            {
                case 0:
                    runColorMenu();
                    break;
                case 1:
                    runControlMenu();
                    break;
                case 2:
                    runMainMenu();
                    break;
            }

        }

        public void runControlMenu()
        {
            Console.Clear();

            Console.ForegroundColor = mainColor;
            Console.WriteLine(title);
            Console.ResetColor();

            controlKeys.bindUpKey();
            Console.WriteLine("Wciśnij dowolny przycik aby kontynuować...");
            Console.ReadKey(true);

            Console.WriteLine(new String('-', Console.WindowWidth - 10));

            controlKeys.bindDownKey();
            Console.WriteLine("Wciśnij dowolny przycik aby kontynuować...");
            Console.ReadKey(true);

            if(currentUser != null)
            {

                Console.Clear();
                Console.ForegroundColor = mainColor;
                Console.WriteLine(title);
                Console.ResetColor();

                string[] options2 = { "Tak", "Nie" };

                Menu menu = new Menu(controlKeys, options2, title, "Czy chcesz zapisać swoje ustawienia sterowania?", mainColor);
                int selectedItem = menu.Run();

                if (selectedItem == 0)
                {
                    currentUser.userKeys = controlKeys;
                    saveUsers();
                    runMainMenu();
                }
                else if (selectedItem == 1)
                {
                    runMainMenu();
                }


            }
            else runMainMenu();

        }

        public void runColorMenu()
        {
            string[] options =
            {
                "Czerwony",
                "Biały",
                "Zielony",
                "Niebieski",
                "Żółty",
                "Wstecz"
            };
            Menu colorMenu = new Menu(controlKeys, options, title, "Wybierz główny kolor z listy poniżej.", mainColor);
            int selectedOption = colorMenu.Run();

            switch (selectedOption) 
            {
                case 0:
                    mainColor = ConsoleColor.Red;
                    
                    break;
                case 1:
                    mainColor = ConsoleColor.White;
                    
                    break;
                case 2:
                    mainColor = ConsoleColor.Green;
                    
                    break;
                case 3:
                    mainColor = ConsoleColor.Blue;
                   
                    break;
                case 4:
                    mainColor = ConsoleColor.Yellow;
                    
                    break;
                case 5:
                    runMainMenu();
                    break;
            }
            Console.Clear();    

            if(currentUser != null)
            {
                Console.ForegroundColor = mainColor;
                Console.WriteLine(title);
                Console.ResetColor();

                string[] options2 = { "Tak", "Nie" };

                Menu menu = new Menu(controlKeys, options2, title, "Czy chcesz zapisać swoje ustawienia koloru?", mainColor);
                int selectedItem = menu.Run();

                if(selectedItem == 0)
                {
                    currentUser.userColor = mainColor;
                    saveUsers();
                    runMainMenu();
                }
                else if(selectedItem == 1)
                {
                    runMainMenu();
                }

            } else runMainMenu();
        }

        /// <summary>
        /// Uruchamia menu użytkownika
        /// </summary>
        public void runUserMenu()
        {
            Menu userMenu;
            if(currentUser != null)
            {
                string[] options = {currentUser.Name ,"Wczytaj użytkownika", "Stwórz użytkownika", "Wstecz" };
                userMenu = new Menu(controlKeys, options, currentUser, title, "Wybierz opcje: ", mainColor);
                int selectedOption = userMenu.Run(true);

                switch(selectedOption)
                {
                    case 0:
                        showCurrentUserPanel();
                        break;
                    case 1:
                        string[] usersNames = loadUsers();
                        showUsers(usersNames);
                        break;
                    case 2:
                        addUser();
                        break;
                    case 3:
                        runMainMenu();
                        break;
                }
            }
            else
            {
                string[] options = { "Wczytaj użytkownika", "Stwórz użytkownika", "Wstecz" };
                userMenu = new Menu(controlKeys, options, title, "Wybierz opcje: ", mainColor);
                int selectedOption = userMenu.Run();

                switch (selectedOption)
                {                  
                    case 0:
                        string[] usersNames = loadUsers();
                        showUsers(usersNames);
                        break;
                    case 1:
                        addUser();
                        break;
                    case 2:
                        runMainMenu();
                        break;
                }
            }
                      
        }

        public void showCurrentUserPanel()
        {
            string caption = 
            @$"
               Nazwa użytkownika - {currentUser.Name}
               Najlepszy wynik - {currentUser.maxScore}/10 punktów w czasie {currentUser.bestTime}
               Kolor główny - {currentUser.userColor.ToString()}
               Ustawienia sterowania:
                     Górny przycisk - {currentUser.userKeys.getUpKey().ToString()}
                     Dolny przycisk - {currentUser.userKeys.getDownKey().ToString()}
            ";

            string[] options = { "Wstecz" };

            Menu menu = new Menu(controlKeys, options, currentUser, title, caption, mainColor);
            int selectedOption = menu.Run();

            if (selectedOption == 0) runUserMenu();

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
            Menu usersMenu = new Menu(controlKeys, usersNames, title, "Wybierz użytkownika z listy", mainColor);
            int selectedItem = usersMenu.Run();

            //ostatni element tablicy nazw to 'wstecz'
            if (selectedItem == usersNames.Length - 1)
                runUserMenu();

            this.currentUser = users[selectedItem];
            mainColor = currentUser.userColor;
            controlKeys = currentUser.userKeys;

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

                usersNames = new string[numberOfUsers+1];

                int index = 0;
                int indexNames = 0;
                while (!usersFile.EndOfStream)
                {
                    string name = usersFile.ReadLine();
                    int maxScore = int.Parse(usersFile.ReadLine());
                    string bestTime = usersFile.ReadLine();
                    ConsoleColor userColor = getColorFromString(usersFile.ReadLine());
                    ConsoleKey upKey = getKeyFromString(usersFile.ReadLine());
                    ConsoleKey downKey = getKeyFromString(usersFile.ReadLine());

                    usersNames[indexNames++] = name;

                    ControlKeys controlKeys = new ControlKeys(upKey, downKey);

                    User u = new User(name ,bestTime ,maxScore);
                    u.userKeys = controlKeys;
                    u.userColor = userColor;

                    users[index++] = u;
                }
                usersNames[indexNames] = "Wstecz";
            }
            return usersNames;
        }

        public ConsoleKey getKeyFromString(string keyName)
        {
            ConsoleKey key;
            key = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), keyName, true);
            return key;
        }

        public ConsoleColor getColorFromString(string colorName)
        {
            ConsoleColor color;

            try
            {
                color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName, true);
                return color;
            }
            catch(Exception ex)
            {
                //zły kolor
                return ConsoleColor.White;
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
                    Console.WriteLine("Twój czas to: " + seconds + " sec.");
                    Console.ResetColor();
                    return seconds + " sec.";
                }
                else
                {
                    Console.WriteLine("Twój czas to: " + minutes + " min. " + seconds + " sec.");
                    Console.ResetColor();
                    return minutes + " min. " + seconds + " sec.";
                }

            }
            else 
            {
                Console.WriteLine("Twój czas to: " + hours + " hour " + minutes + " min." + seconds + " sec.");
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
                    Console.ForegroundColor = mainColor;
                    Console.WriteLine(asciiSymbol.win);
                    Console.ResetColor();
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

                Menu questionMenu = new Menu(controlKeys, q.answerOptions ,points, title, q.content, mainColor);

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
            Console.ForegroundColor = mainColor;
            Console.WriteLine(asciiSymbol.score);
            string p = asciiSymbol.getPointsString(points);
            Console.WriteLine(p);
            Console.ResetColor();
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
            lines = new string[users.Length * 6 + 1];
            lines[0] = users.Length.ToString();
            int index = 0;
            for(int i=1; i < lines.Length; i+=6)
            {
                lines[i] = users[index].Name;
                lines[i + 1] = users[index].maxScore.ToString();
                lines[i + 2] = users[index].bestTime.ToString();
                lines[i + 3] = users[index].userColor.ToString();
                lines[i + 4] = users[index].userKeys.getUpKey().ToString();
                lines[i + 5] = users[index].userKeys.getDownKey().ToString();
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
