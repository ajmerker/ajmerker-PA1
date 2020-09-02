using System; 
using System.Collections.Generic; 
using System.IO; 

namespace ajmerker_PA1
{
    public class PostFile
    {
        public static List<Post> GetPosts()
        {
            List<Post> alPosts = new List<Post>(); //Constructor 
           
           //Try catch - check for file existance 
            StreamReader inFile = null;  

            try
            {
                inFile = new StreamReader("posts.txt"); 
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Something went wrong... returning blank list {0}", e); 
                return alPosts; 

            }

            string line = inFile.ReadLine(); //priming read
            //Read in rest of the file 
            while(line != null)
            {
                string[] temp = new string[3]; 
                temp = line.Split("#"); 
                int id = int.Parse(temp[0]); 
                alPosts.Add(new Post(){Id = id, text = temp[1], timestamp = DateTime.Parse(temp[2])});  
                line = inFile.ReadLine(); //update read
            }

            //close file 
            inFile.Close(); 

            return alPosts;
        }
        

    }
}