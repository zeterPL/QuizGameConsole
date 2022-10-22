using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameConsole
{
    public class Question
    {
        /// <summary>
        /// Treść pytania
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Możłiwe warianty odpowiedzi
        /// </summary>
        public string[] answerOptions { get; set; }
        
        /// <summary>
        /// Numer poprawnej odpowiedzi
        /// </summary>
        public int correctAnswer { get; set; }

        public Question(string content, string[] answerOptions, int correctAnswer)
        {
            this.content = content;
            this.answerOptions = answerOptions;
            this.correctAnswer = correctAnswer;
        }
    }
}
