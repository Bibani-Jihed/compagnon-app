using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
[CLSCompliant(false)]
public class Challenge
{
    //public string objectId;
    public string _id { get; set; }
    public string status { get; set; }
    public string challenge_type { get; set; }
    public string gain { get; set; }
    public User matched_user_1 { get; set; }
    public User matched_user_2 { get; set; }
    public float? user_1_score { get; set; }
    public float? user_2_score { get; set; }
    public Game game { get; set; }
    public string gain_type { get; set; }
    public int level { get; set; }
    public string winner_user { get; set; }
    public string CreatedAt { get; set; }
    public int? game_level { get; set; }
    public Challenge()
    {

    }
}

