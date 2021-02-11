using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EndSurvey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Answer> AnswerList = (List<Answer>)Session["AnswerList"];

            if (AnswerList != null)
            {
                DbLogic dbAccess = new DbLogic();
                for (int i = 0; i < AnswerList.Count; i++)
                {
                    dbAccess.InsertAnswer(AnswerList[i]);
                }
                dbAccess.AddRespondent((int)Session["rid"]);
            }

            gridAnswer.DataSource = AnswerList;
            gridAnswer.DataBind();

            ListItem item1 = new ListItem();
            item1.Value = "1";
            item1.Text = "Yes Please!";
            ListItem item2 = new ListItem();
            item2.Value = "2";
            item2.Text = "No, Thank you!";

            rbList.Items.Add(item1);
            rbList.Items.Add(item2);
        }
    }

    protected void rbList_SelectedIndexChnaged(object sender, System.EventArgs e)
    {
        if (int.Parse(rbList.SelectedValue) == 1)
        {
            //    Label flbl = new Label();
            //    flbl.Text = "First Name";
            //    TextBox fnameBox = new TextBox();
            //    fnameBox.ID = "fbox";
            //    inputHolder.Controls.Add(flbl);
            //    inputHolder.Controls.Add(fnameBox);

            //    Label llbl = new Label();
            //    llbl.Text = "Last Name";
            //    TextBox lnameBox = new TextBox();
            //    lnameBox.ID = "lbox";
            //    inputHolder.Controls.Add(llbl);
            //    inputHolder.Controls.Add(lnameBox);

            //    Label blbl = new Label();
            //    blbl.Text = "Birthday";
            //    TextBox bdBox = new TextBox();
            //    bdBox.ID = "bdbox";
            //    inputHolder.Controls.Add(blbl);
            //    inputHolder.Controls.Add(bdBox);

            //    Calendar cal = new Calendar();
            //    cal.ID = "bdCal";
            //    cal.SelectionChanged += Cal_SelectionChanged;
            //    inputHolder.Controls.Add(cal);



            //    Label plbl = new Label();
            //    plbl.Text = "Phone";
            //    TextBox pBox = new TextBox();
            //    pBox.ID = "pbox";
            //    inputHolder.Controls.Add(plbl);
            //    inputHolder.Controls.Add(pBox);

            btnRegister.Visible = true;
            btnExit.Visible = false;
        }
        else
        {
            btnRegister.Visible = false;
            btnExit.Visible = true;
        }
    }
}