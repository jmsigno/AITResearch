using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Option
/// </summary>
public class Option
{
    public Option() { }

    public Option(int id, string opt, int qid, int? next)
    {
        this.opt_id = id;
        this.option = opt;
        this.q_id = qid;
        this.nq_id = next;
    }

    public int opt_id { get; set; }
    public string option { get; set; }
    public int q_id { get; set; }
    public int? nq_id { get; set; }
}