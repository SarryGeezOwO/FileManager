using System;
using System.Globalization;
using System.IO;

namespace FileShenanigans
{
    class Organize
    {
        static void Main(string[] args)
        {
            // Console Font Color ------------------------------------------------------------------------
            // open this block of code to see all the available colors
            
            
            /*
                ConsoleColor[] consoleColors =(ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor)); 
                Console.WriteLine("List of available "+ "Console Colors:"); 
                
                foreach(var color in consoleColors) {
                    Console.ForegroundColor = color;
                    Console.WriteLine(color);
                }
            */
            
            
            
            //--------------------------------------------------------------------------------------------


            Organize org = new Organize();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("type the path that you want to ORGANIZE");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(">> ");
            string inputPath = Console.ReadLine().ToString();
            bool dirExistance = Directory.Exists(inputPath);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Does this directory exists? : ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(dirExistance);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
        
        // OPTIONS -----------------------------------------------------------------------------------------

            if(dirExistance)
            {
                org.OrganizeFiles(inputPath);   
            }
            

            Console.ReadKey();
        }

        private void OrganizeFiles(string path)
        {
            Console.WriteLine("// The Files inside this Path //");
            Console.WriteLine("----------------------------------------------------------");
            string[] files = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly); // we do not want to enter the folders inside our given path, just leave them be smh
            foreach(string file in files)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(Path.GetFileName(file));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine("----------------------------------------------------------");
            Console.Write("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do you wish to organize these files to their respective extensions? : [y / n]");
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(">> ");
            string response = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            if(response != "")   // not empty
            { 
                response = response.Substring(0, 1).ToLower();

                if(response == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Organizing Files...");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    
                    #region Folder Creator 9000000!!!=========================================================================
                        foreach(string file in files) // create The Folders needed for organizing and Individually Move File on desired folder
                        {
                            List<string> folders = new List<string> {
                                "Videos", "Applications", "Documents", "Sai Files", "Images"
                            };

                            string folderName = Path.GetExtension(file).ToUpper().Substring(1);
                            string wantedPath = path + "\\" + ChangeFolderName(folderName);
                            if(!Directory.Exists(wantedPath)) 
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("< ");
                                Console.Write("Created " + ChangeFolderName(folderName) + " Folder"); 
                                Console.WriteLine(" >");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }    
                            Directory.CreateDirectory(wantedPath);
                    #endregion
                            string filePath = Path.GetFullPath(file);
                            MoveFile(file, wantedPath, filePath);
                        }
                        Console.WriteLine("Task Finished!");
                }
                else  {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine("Ok Bozo");
                }
            }else { // empty
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("Ok Bozo");
            }
        }

        private void MoveFile(string file, string wantedPath, string filePath)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            File.Move(filePath, wantedPath + "\\" + Path.GetFileName(file));
            Console.Write("File Name : ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Path.GetFileNameWithoutExtension(file)); 

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Finish Organizing? : "); // yeah fuck this shit
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("true");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("================================================================="); 
            Console.WriteLine("");
        }

        // change Folder Name ( Customizaion )
        private string ChangeFolderName(string name)
        {
            string newName = name;
            if(name == "JPG" || name == "JPEG") { // trick the code to put the jpeg to the png folder lmao
                name = "PNG";
            }

                // Folder Name Customization
            switch(name) 
            {
                case "EXE":
                    newName = "APPLICATIONS";
                    break;
                case "TXT":
                    newName = "DOCUMENTS";
                    break;
                case "SAI2":
                    newName = "PAINT TOOL SAI";
                    break;
                case "MP4":
                    newName = "VIDEOS";
                    break;
                case "PNG":
                    newName = "IMAGES";
                    break;
                default:
                    break;
            }
            return newName;
        }
    }
}
