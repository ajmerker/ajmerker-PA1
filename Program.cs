using System;
using System.Collections.Generic; 

namespace ajmerker_PA1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Post> alPosts = PostFile.GetPosts(); //Constructor 
            
            //Welcome message 
            Console.WriteLine("Welcome to Big Al's Tweeting Service!");
          
          //Menu
            int menuInput = 0; 
            while (menuInput != 4) 
            {
                Console.WriteLine("Press 1 to view all tweets,\nPress 2 to write a new tweet, \nPress 3 to delete a tweet, \nPress 4 to exit."); 
                try
                {
                    menuInput = int.Parse(Console.ReadLine());
                    if (menuInput < 1 || menuInput > 4)
                    {
                        throw new Exception("Not a valid menu choice"); 
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);      
                }
                finally
                {
                    if(menuInput == 1)
                    { 
                        alPosts.Sort(Post.CompareByTime); 
                        PostUtil.PrintAllPosts(alPosts); 
                        menuInput = 0; 
                    }
                    else if (menuInput ==2)
                    {
                        PostUtil.AddPost(alPosts); // calls sortbyId in method 
                        menuInput = 0; 
                    }
                    else if (menuInput ==3)
                    {
                        PostUtil.DeletePost(alPosts); 
                        menuInput = 0; 
                    }
                }

            }


        }
    
        
    }

}
