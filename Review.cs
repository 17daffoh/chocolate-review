using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chocolate_review
{
    class Review
    {
        public int ReviewID;
        public int ChocolateBarID;
        public int UserID;
        public int Score;
        public string Comment;

        public Review(int ReviewID, int ChocolateBarID, int UserID, int Score, string Comment)
        {
            this.ReviewID = ReviewID;
            this.ChocolateBarID = ChocolateBarID;
            this.UserID = UserID;
            this.Score = Score;
            this.Comment = Comment;
        }

        public Review(SqlDataReader r)
        {
            ReviewID = (int)r["ReviewID"];
            ChocolateBarID = (int)r["ChocolateBarID"];
            UserID = (int)r["UserID"];
            Score = (int)r["Score"];
            Comment = (string)r["Comment"];
        }
    }
}
