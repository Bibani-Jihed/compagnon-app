using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
[CLSCompliant(false)]
public class User
{
    public string _id { get; set; }
    public string username { get; set; }
    public string avatar { get; set; }
    public bool username_changed { get; set; }
    public string lastname { get; set; }
    public string firstname { get; set; }
    public float money_credit { get; set; }
    public float bubble_credit { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string personal_id_number { get; set; }
    public string phone { get; set; }
    public int amateur_bubble { get; set; }
    public int novice_bubble { get; set; }
    public int legend_bubble { get; set; }
    public int confident_bubble { get; set; }
    public int confirmed_bubble { get; set; }
    public int champion_bubble { get; set; }
    public int amateur_money { get; set; }
    public int novice_money { get; set; }
    public int legend_money { get; set; }
    public int confident_money { get; set; }
    public int confirmed_money { get; set; }
    public int champion_money { get; set; }
    public int losses_streak { get; set; }
    public int current_victories_count { get; set; }
    public string long_lat { get; set; }
    public string last_bubble_click { get; set; }
    public bool email_verified { get; set; }
    public bool iban_uploaded { get; set; }
    public int level { get; set; }
    public string connect_account_id { get; set; }
    public bool id_proof_1_uploaded { get; set; }
    public bool id_proof_2_uploaded { get; set; }
    public string city { get; set; }
    public string country_code { get; set; }
    public string state { get; set; }
    public float max_withdraw { get; set; }
    public string zipcode { get; set; }
    public bool passport_uploaded { get; set; }
    public string last_result { get; set; }
    public string birthdate { get; set; }
    public string address { get; set; }
    public string country { get; set; }
    public bool residency_proof_uploaded { get; set; }
    public int victories_count { get; set; }
    public int victories_streak { get; set; }
    public string token { get; set; }
    public string flag { get; set; }
    public string payment_account_id { get; set; }
    public bool proLabel { get; set; }
    public string[]games { get; set; }

    public static User CurrentUser { get; set; }



    public User() { }

}

