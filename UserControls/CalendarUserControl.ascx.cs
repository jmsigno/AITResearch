using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_CalendarUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Calendar1.Visible = false;
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Calendar1.Visible = !Calendar1.Visible;
    }

    protected void Selection_Change(Object sender, EventArgs e)
    {
        dateBox.Text = Calendar1.SelectedDate.ToShortDateString();
        Calendar1.Visible = false;
    }

    public TextBox selectedDate
    {
        get
        {
            return dateBox;
        }
    }

    public Calendar MyCalendar
    {
        get
        {
            return Calendar1;
        }
    }
}