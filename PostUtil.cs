using System; 
using System.Collections.Generic;
using System.IO;


namespace ajmerker_PA1
{
     public class PostUtil
    {
        //Print all posts
        public static void PrintAllPosts(List<Post> posts)
        { 
            foreach(Post post in posts)
            {
                Console.WriteLine(post.ToString()); 
            }
        }

        //Add a post
        public static void AddPost(List<Post> alPosts)
        {
            //List<Post> alPosts = PostFile.GetPosts();
            alPosts.Sort(); 
            Console.WriteLine("Here are the current Tweets:"); 
            PrintAllPosts(alPosts); 

            Console.WriteLine("Enter the text for your new Tweet:"); 
            string tempText = Console.ReadLine(); 

            DateTime tempDate = DateTime.Now; 
            alPosts.Add(new Post(){Id = alPosts.Count, text = tempText, timestamp = tempDate}); 
            
            
            StreamWriter OutFile = new StreamWriter("posts.txt", false); 
            foreach(Post post in alPosts)
            {
                OutFile.WriteLine(post.ToFile()); 
            }
           // OutFile.WriteLine(alPosts); 
            OutFile.Close();  

        }


        //Delete a Post
        public static void DeletePost(List<Post> alPosts)
        {
            alPosts.Sort(); //by id 
            Console.WriteLine("Here are the current Tweets:"); 
            PrintAllPosts(alPosts); 

            Console.WriteLine("Enter the Id of the Post you would like to delete"); 
            int tempDelete = int.Parse(Console.ReadLine()); 
            

            //check to see if ID exists
            int indexFound = alPosts.FindIndex(tempPost => tempPost.Id == tempDelete); 
            if (indexFound != -1)
            {
                alPosts.RemoveAt(indexFound); 

                StreamWriter OutFile = new StreamWriter("posts.txt", false); 
                foreach(Post post in alPosts)
                {
                    OutFile.WriteLine(post.ToFile()); 
                }
                 // OutFile.WriteLine(alPosts); 
                OutFile.Close(); 
            }
            else
            {
                Console.WriteLine("The Id was not found");
                Console.WriteLine("Please enter the Id you would like to delete: "); 
                tempDelete = int.Parse(Console.ReadLine()); 
            }

            int counter = 0; 
            foreach(Post post in alPosts)
            {   
                post.Id = counter; 
                counter ++; 
            }   
 
        }

    }
}