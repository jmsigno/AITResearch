using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Answer
/// </summary>
public class Answer
{
    public Answer(){}

    public Answer(int? oid, string ans, int qid, int rid)
    {
        this.answer = ans;
        this.opt_id = oid;
        this.q_id = qid;
        this.r_id = rid;
    }

    public Answer(string ans, int qid, int rid)
    {
        this.answer = ans;
        this.q_id = qid;
        this.r_id = rid;
    }

    public string answer { get; set; }
    public int? opt_id { get; set; }
    public int q_id { get; set; }
    public int r_id { get; set; }
}