using System; 

namespace ajmerker_PA1 
{
    public class Post : IComparable<Post>
    {
        //Auto Implimated Properties 
        public int Id {get; set;}
        public string text {get; set;}

        public DateTime timestamp {get; set;} 


        //Sort Methods
        public int CompareTo(Post temp) 
        {
            return this.Id.CompareTo(temp.Id); 
        }

        public static int CompareByText(Post x, Post y)
        {
            return x.text.CompareTo(y.text); 
        }

        public static int CompareByTime(Post x, Post y)
        {
            return x.timestamp.CompareTo(y.timestamp); 
        }


        //ToStrings
        public override string ToString() 
        {
            return this.Id + " "  + this.text + " " +  this.timestamp;  
        }

        public string ToFile()
        {
            return this.Id + "#" + this.text + "#" + this.timestamp; 
        }



    }
}