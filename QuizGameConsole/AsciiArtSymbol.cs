﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameConsole
{
    public class AsciiArtSymbol
    {
        public string zero { get; set; } = @"

 ██████╗     ██╗ ██╗ ██████╗ 
██╔═████╗   ██╔╝███║██╔═████╗
██║██╔██║  ██╔╝ ╚██║██║██╔██║
████╔╝██║ ██╔╝   ██║████╔╝██║
╚██████╔╝██╔╝    ██║╚██████╔╝
 ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ 
                             
";
        public string one { get; set; } = @"

 ██╗    ██╗ ██╗ ██████╗ 
███║   ██╔╝███║██╔═████╗
╚██║  ██╔╝ ╚██║██║██╔██║
 ██║ ██╔╝   ██║████╔╝██║
 ██║██╔╝    ██║╚██████╔╝
 ╚═╝╚═╝     ╚═╝ ╚═════╝ 
";
        public string two { get; set; } = @"

██████╗     ██╗ ██╗ ██████╗ 
╚════██╗   ██╔╝███║██╔═████╗
 █████╔╝  ██╔╝ ╚██║██║██╔██║
██╔═══╝  ██╔╝   ██║████╔╝██║
███████╗██╔╝    ██║╚██████╔╝
╚══════╝╚═╝     ╚═╝ ╚═════╝ 
                            

";
        public string three { get; set; } = @"

██████╗     ██╗ ██╗ ██████╗ 
╚════██╗   ██╔╝███║██╔═████╗
 █████╔╝  ██╔╝ ╚██║██║██╔██║
 ╚═══██╗ ██╔╝   ██║████╔╝██║
██████╔╝██╔╝    ██║╚██████╔╝
╚═════╝ ╚═╝     ╚═╝ ╚═════╝ 
                               
";
        public string four { get; set; } = @"

██╗  ██╗    ██╗ ██╗ ██████╗ 
██║  ██║   ██╔╝███║██╔═████╗
███████║  ██╔╝ ╚██║██║██╔██║
╚════██║ ██╔╝   ██║████╔╝██║
     ██║██╔╝    ██║╚██████╔╝
     ╚═╝╚═╝     ╚═╝ ╚═════╝ 
                                  
";
        public string five { get; set; } = @"

███████╗    ██╗ ██╗ ██████╗ 
██╔════╝   ██╔╝███║██╔═████╗
███████╗  ██╔╝ ╚██║██║██╔██║
╚════██║ ██╔╝   ██║████╔╝██║
███████║██╔╝    ██║╚██████╔╝
╚══════╝╚═╝     ╚═╝ ╚═════╝ 
                                  
";
        public string six { get; set; } = @"

 ██████╗     ██╗ ██╗ ██████╗ 
██╔════╝    ██╔╝███║██╔═████╗
███████╗   ██╔╝ ╚██║██║██╔██║
██╔═══██╗ ██╔╝   ██║████╔╝██║
╚██████╔╝██╔╝    ██║╚██████╔╝
 ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ 
                                     
";
        public string seven { get; set; } = @"

███████╗  ██╗ ██╗ ██████╗ 
╚════██║ ██╔╝███║██╔═████╗
    ██╔╝██╔╝ ╚██║██║██╔██║
   ██╔╝██╔╝   ██║████╔╝██║
   ██║██╔╝    ██║╚██████╔╝
   ╚═╝╚═╝     ╚═╝ ╚═════╝ 
                          
       
";
        public string eight { get; set; } = @"

 █████╗     ██╗ ██╗ ██████╗ 
██╔══██╗   ██╔╝███║██╔═████╗
╚█████╔╝  ██╔╝ ╚██║██║██╔██║
██╔══██╗ ██╔╝   ██║████╔╝██║
╚█████╔╝██╔╝    ██║╚██████╔╝
 ╚════╝ ╚═╝     ╚═╝ ╚═════╝ 
                                 
";
        public string nine { get; set; } = @"

 █████╗     ██╗ ██╗ ██████╗ 
██╔══██╗   ██╔╝███║██╔═████╗
╚██████║  ██╔╝ ╚██║██║██╔██║
 ╚═══██║ ██╔╝   ██║████╔╝██║
 █████╔╝██╔╝    ██║╚██████╔╝
 ╚════╝ ╚═╝     ╚═╝ ╚═════╝ 
                                   
";
        public string ten { get; set; } = @"

 ██╗ ██████╗     ██╗ ██╗ ██████╗ 
███║██╔═████╗   ██╔╝███║██╔═████╗
╚██║██║██╔██║  ██╔╝ ╚██║██║██╔██║
 ██║████╔╝██║ ██╔╝   ██║████╔╝██║
 ██║╚██████╔╝██╔╝    ██║╚██████╔╝
 ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ 
                                 
            
";
        public string slash { get; set; } = @"
    ██╗
   ██╔╝
  ██╔╝ 
 ██╔╝  
██╔╝   
╚═╝    
       
";
        public string win { get; set; } = @"
██████╗ ██████╗  █████╗ ██╗    ██╗ ██████╗ ██╗
██╔══██╗██╔══██╗██╔══██╗██║    ██║██╔═══██╗██║
██████╔╝██████╔╝███████║██║ █╗ ██║██║   ██║██║
██╔══██╗██╔══██╗██╔══██║██║███╗██║██║   ██║╚═╝
██████╔╝██║  ██║██║  ██║╚███╔███╔╝╚██████╔╝██╗
╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚══╝╚══╝  ╚═════╝ ╚═╝
                                              
     ██╗ ██████╗     ██╗ ██╗ ██████╗          
    ███║██╔═████╗   ██╔╝███║██╔═████╗         
    ╚██║██║██╔██║  ██╔╝ ╚██║██║██╔██║         
     ██║████╔╝██║ ██╔╝   ██║████╔╝██║         
     ██║╚██████╔╝██╔╝    ██║╚██████╔╝         
     ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝          
                                              
";

        public string score { get; set; } = @"
██╗   ██╗ ██████╗ ██╗   ██╗██████╗ ██████╗     ███████╗ ██████╗ ██████╗ ██████╗ ███████╗    ██╗███████╗   
╚██╗ ██╔╝██╔═══██╗██║   ██║██╔══██╗██╔══██╗    ██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝    ██║██╔════╝██╗
 ╚████╔╝ ██║   ██║██║   ██║██████╔╝██████╔╝    ███████╗██║     ██║   ██║██████╔╝█████╗      ██║███████╗╚═╝
  ╚██╔╝  ██║   ██║██║   ██║██╔══██╗██╔══██╗    ╚════██║██║     ██║   ██║██╔══██╗██╔══╝      ██║╚════██║██╗
   ██║   ╚██████╔╝╚██████╔╝██║  ██║██║  ██║    ███████║╚██████╗╚██████╔╝██║  ██║███████╗    ██║███████║╚═╝
   ╚═╝    ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝    ╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝    ╚═╝╚══════╝   
                                                                                                          
";
       // public string userName { get; set; } = "NullValue";

        

        public string getUserNameFrameString(string userName)
        {
            return 
                @$"------------------------------------------------------------------
                   |                                                                |
                   |                        {userName}                              |       
                   |                                                                |
                   ------------------------------------------------------------------
                ";
        }

        /// <summary>
        /// Zwraca obrazek unktów na podstawie liczby
        /// </summary>
        /// <param name="points">Liczba punktów do wyświetlenia</param>
        /// <returns>Obrazek -> points/10</returns>
        public string getPointsString(int points)
        {
            if (points == 0) return zero;
            if (points == 1) return one;
            if (points == 2) return two;
            if (points == 3) return three;
            if (points == 4) return four;
            if (points == 5) return five;
            if (points == 6) return six;
            if (points == 7) return seven;
            if (points == 8) return eight;
            if (points == 9) return nine;
            if (points == 10) return ten;
            return "";
        }
    }
}
