using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Questions
/// </summary>
public class Question
{
    public Question() { }

    public Question(int id, string q, string type, int? nextq)
    {
        this.q_id = id;
        this.question = q;
        this.q_type = type;
        this.nq_id = nextq;
    }

    public int q_id { get; set; }
    public string question { get; set; }
    public string q_type { get; set; }
    public int? nq_id { get; set; }
}