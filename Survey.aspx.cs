using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Survey : System.Web.UI.Page
{
    //variable declarations
    DbLogic dbAccess = new DbLogic();
    Question question = new Question();
    Answer userAnswer = new Answer();
    RadioButtonList rBoxList = new RadioButtonList();
    CheckBoxList cBoxList = new CheckBoxList();
    TextBox tbox = new TextBox();

    /// <summary>
    /// Load the survey page
    /// </summary>
    /// <param name="sender">User http request
    /// <param name="e">Page Load event
    protected void Page_Load(object sender, EventArgs e)
    {
        Stack<int> nextQuestionID = (Stack<int>)(Session["nextq"]);
        int currentqid = 1;

        if(Session["rid"] == null)
        {
            //generate new respondent ID
            Session["rid"] = dbAccess.GetNewRespondentID();
        }

        //First page load
        if (nextQuestionID == null)
        {
            //Load 1st question
            nextQuestionID = new Stack<int>();
            nextQuestionID.Push(1);
            Session["nextq"] = nextQuestionID;
            
        }
        else
        {
            currentqid = nextQuestionID.Peek();
        }

        //access the question from db
        question = dbAccess.GetQuestion(currentqid);

        //render the question and option controls accoring to question type
        if (question != null)
        {
            questionLbl.Text = question.question.ToString();
            switch (question.q_type)
            {
                case "rbl":
                    rBoxList.ID = "RBL";
                    rBoxList.CssClass = "rblCss";

                    List<Option> rboxOptList = dbAccess.GetOptions(question.q_id);
                    if (rboxOptList != null)
                    {
                        for (int i = 0; i < rboxOptList.Count; i++)
                        {
                            ListItem item = new ListItem();
                            item.Value = rboxOptList[i].opt_id.ToString();
                            item.Text = rboxOptList[i].option.ToString();
                            if(rboxOptList[i].nq_id != null)
                            {
                                item.Attributes["nextQID"] = rboxOptList[i].nq_id.ToString();
                            }
                            rBoxList.Items.Add(item);
                        }
                    }
                    optHolder.Controls.Add(rBoxList);
                    Session["qtype"] = rBoxList.ID;
                    break;
                case "cbl":
                    cBoxList.ID = "CBL";
                    List<Option> cboxOptlist = dbAccess.GetOptions(question.q_id);
                    if (cboxOptlist != null)
                    {
                        for (int i = 0; i < cboxOptlist.Count; i++)
                        {
                            ListItem item = new ListItem();
                            item.Value = cboxOptlist[i].opt_id.ToString();
                            item.Text = cboxOptlist[i].option.ToString();
                            if(cboxOptlist[i].nq_id != null)
                            {
                                item.Attributes["nextQID"] = cboxOptlist[i].nq_id.ToString();
                            }
                            cBoxList.Items.Add(item);
                        }
                    }
                    optHolder.Controls.Add(cBoxList);
                    Session["qtype"] = rBoxList.ID;
                    break;

                case "tb":
                    tbox.ID = "TB";
                    optHolder.Controls.Add(tbox);
                    Session["qtype"] = rBoxList.ID;
                    break;
            }
        }
    }
    /// <summary>
    /// Get user answer and store to the answer list, render followup question.
    /// </summary>
    /// <param name="sender">
    /// <param name="e">on button click event
    protected void btnNext_Click(object sender, EventArgs e)
    {
        int _respondentID = (int)Session["rid"];

        //pop the current question id from the queue
        Stack<int> nextQuestionList = (Stack<int>)Session["nextq"];
        int currentQuestionId = nextQuestionList.Pop();
        question = dbAccess.GetQuestion(currentQuestionId);

        List<Answer> UserAnswerList = (List<Answer>)Session["AnswerList"];
        //initialize the answerList
        if (UserAnswerList == null)
        {
            UserAnswerList = new List<Answer>();
            Session["AnswerList"] = UserAnswerList;
        }
        //get the next question id and store in the Stack
        if(question.nq_id != null)
        {
            NextQuestion((int)question.nq_id, nextQuestionList);
        }

        //get the selected item from the control according to question type
        switch (question.q_type)
        {
            case "rbl":
                RadioButtonList rbl = (RadioButtonList)optHolder.FindControl("RBL");
                foreach (ListItem item in rbl.Items)
                {
                    if (item.Selected)
                    {
                        if (item.Attributes["nextQID"] != null)
                        {
                            NextQuestion(int.Parse(item.Attributes["nextQID"]), nextQuestionList);
                        }
                        UserAnswerList.Add(new Answer(int.Parse(item.Value), item.Text.ToString(), currentQuestionId, _respondentID));
                    }
                }
                break;

            case "cbl":
                CheckBoxList cbl = (CheckBoxList)optHolder.FindControl("CBL");
                string answer = "";
                foreach (ListItem item in cbl.Items)
                {
                    if (item.Selected)
                    {
                        answer += item.Text;
                        if(item.Attributes["nextQID"] != null)
                        {
                            NextQuestion(int.Parse(item.Attributes["nextQID"]), nextQuestionList);
                        }
                        UserAnswerList.Add(new Answer(int.Parse(item.Value), item.Text.ToString(), currentQuestionId, _respondentID));
                    }
                }
                Session["Answer"] = answer;
                break;

            case "tb":
                TextBox tb = (TextBox)optHolder.FindControl("TB");
                UserAnswerList.Add(new Answer(0, tb.Text.ToString(), currentQuestionId, _respondentID));
                Session["Answer"] = tb.Text.ToString();
                tb.Text = "";
                break;

            default:
                TextBox tb2 = (TextBox)optHolder.FindControl("TB");
                UserAnswerList.Add(new Answer(0, tb2.Text.ToString(), currentQuestionId, _respondentID));
                Session["Answer"] = tb2.Text.ToString();
                break;
        }
        
        //if next question stack is emptied, proceed to saving answers to database
        if (nextQuestionList.Count > 0) {
            Response.Redirect("Survey.aspx");
        }
        else
        {
            Response.Redirect("EndSurvey.aspx");
        }
    }

    /// <summary>
    /// Skip the current and proceed to the next id from the next question Stack without storing Answer.
    /// </summary>
    /// <param name="sender">Button
    /// <param name="e">on button click event
    protected void btnSkip_Click(object sender, EventArgs e)
    {
        Stack<int> nextQuestionList = (Stack<int>)Session["nextq"];
        int currentQuestionId = nextQuestionList.Pop();
        question = dbAccess.GetQuestion(currentQuestionId);

        if (question.nq_id != null)
        {
            NextQuestion((int)question.nq_id, nextQuestionList);
        }

        if (nextQuestionList.Count > 0)
        {
            Response.Redirect("Survey.aspx");
        }
        else
        {
            Response.Redirect("EndSurvey.aspx");
        }
    }

    /// <summary>
    /// Insert next question id in next question stack list
    /// </summary>
    /// <param name="nextqid">provided method caller
    /// <param name="nextQList">global Stack List 
    private void NextQuestion(int nextqid, Stack<int> nextQList)
    {
        if (!nextQList.Contains(nextqid))
        {
            nextQList.Push(nextqid);
        }
    }
}




