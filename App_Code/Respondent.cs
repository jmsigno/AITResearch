using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Respondent
/// </summary>
public class Respondent
{
    public Respondent()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Respondent(int rid, string ip, DateTime date)
    {
        this.r_id = rid;
        this.ip_ad = ip;
        this.r_date = date;
    }

    public int r_id { get; set; }
    public string ip_ad { get; set; }
    public DateTime r_date { get; set; }
}