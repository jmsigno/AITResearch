using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DbLogic
/// </summary>
public class DbLogic
{
    public DbLogic()
    {
    }

    /// <summary>
    /// Get question from database using question id as parameters
    /// </summary>
    /// <param name="id">provided by method call</param>
    /// <returns> returns Question object </returns>
    public Question GetQuestion(int id)
    {
        Question question = null;
        try
        {
            using (SqlConnection conn = new SqlConnection(Const.DbConnStr))
            {
                conn.Open();
                SqlCommand getQuestion = conn.CreateCommand();
                getQuestion.CommandText = "Select * FROM dbo.Questions WHERE q_id='" + id + "'";
                SqlDataReader reader = getQuestion.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int qid = (int)reader["q_id"];
                        string q = (string)reader["question"];
                        string type = (string)reader["q_type"];
                        int? n = reader["nq_id"] as int?;
                        question = new Question(qid, q, type, n);

                        break;
                    }
                }
                reader.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
        return question;
    }

    /// <summary>
    /// Get the list of options from database using question id as parameters
    /// </summary>
    /// <param name="id">provided by method call</param>
    /// <returns> returns List of Option object </returns>
    public List<Option> GetOptions(int id)
    {
        List<Option> optionList = new List<Option>();
        try
        {
            using (SqlConnection conn = new SqlConnection(Const.DbConnStr))
            {
                conn.Open();
                SqlCommand getOptions = conn.CreateCommand();
                getOptions.CommandText = "Select * FROM dbo.Options WHERE q_id='" + id + "'";
                SqlDataReader reader = getOptions.ExecuteReader();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int oid = (int)reader["opt_id"];
                        string option = (string)reader["options"];
                        int qid = (int)reader["q_id"];
                        int? next = reader["nq_id"] as int?;
                        optionList.Add(new Option(oid, option, qid, next));
                    }
                }
                reader.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return optionList;
    }

    /// <summary>
    /// Insert Answer object variable data to the database
    /// </summary>
    /// <param name="answer">provided by method call</param>
    /// <returns> returns true if success; else false </returns>
    public bool InsertAnswer(Answer answer)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(Const.DbConnStr))
            {
                conn.Open();
                SqlCommand readAnswer = conn.CreateCommand();
                SqlCommand addMAnswer = conn.CreateCommand();
                readAnswer.CommandText = "SELECT COUNT(*) FROM dbo.Answers";
                int count = (int)readAnswer.ExecuteScalar();
                count++;

                if (answer.opt_id > 0)
                {
                    readAnswer.CommandText = "SELECT * FROM dbo.Answers WHERE opt_id='" + answer.opt_id + "' AND r_id='" + answer.r_id + "'";
                    SqlDataReader reader = readAnswer.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        addMAnswer.CommandText = "INSERT INTO dbo.Answers (ans_id,answer,q_id,r_id,opt_id) VALUES('"+count+"',@ANS,@QID,@RID,@OPID)";
                        addMAnswer.Parameters.AddWithValue("@ANS", answer.answer);
                        addMAnswer.Parameters.AddWithValue("@QID", answer.q_id);
                        addMAnswer.Parameters.AddWithValue("@RID", answer.r_id);
                        addMAnswer.Parameters.AddWithValue("@OPID", answer.opt_id);
                        addMAnswer.ExecuteNonQuery();
                        return true;
                    }
                }
                else
                {
                    addMAnswer.CommandText = "INSERT INTO dbo.Answers (ans_id,answer,q_id,r_id,opt_id) VALUES('" + count + "',@ANS,@QID,@RID,@OPID)";
                    addMAnswer.Parameters.AddWithValue("@ANS", answer.answer);
                    addMAnswer.Parameters.AddWithValue("@QID", answer.q_id);
                    addMAnswer.Parameters.AddWithValue("@RID", answer.r_id);
                    addMAnswer.Parameters.AddWithValue("@OPID", answer.opt_id);
                    addMAnswer.ExecuteNonQuery();
                    return true;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return false;
    }

    /// <summary>
    /// generate and inseret respondent data(ip, date) to the database using the respondent id
    /// </summary>
    /// <param name="r_id">provided by method call</param>
    /// <returns> returns true if success; else false </returns>
    public bool AddRespondent(int r_id)
    {
        DateTime today = DateTime.Today;
        Const cons = new Const();
        try
        {
            using (SqlConnection conn = new SqlConnection(Const.DbConnStr))
            {
                conn.Open();
                SqlCommand addRespondent = conn.CreateCommand();
                addRespondent.CommandText = "INSERT INTO dbo.Respondents(r_id,ip_ad,r_date) VALUES(@RID,@IP,@DATE)";
                addRespondent.Parameters.AddWithValue("@RID", r_id);
                addRespondent.Parameters.AddWithValue("@IP", cons.GetIPAddress());
                addRespondent.Parameters.AddWithValue("@DATE", today);
                addRespondent.ExecuteNonQuery();
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return false;
    }

    /// <summary>
    /// Count the respondent data table to generate new respondent it.
    /// </summary>
    /// <returns> returns int: total of respondent + 1, as new ID </returns>
    /// Note: This is  temporary respondent ID generator as no delete respondent method at the moment.
    public int GetNewRespondentID()
    {
        int count = 0;
        try
        {
            using (SqlConnection conn = new SqlConnection(Const.DbConnStr))
            {
                conn.Open();
                SqlCommand respList = conn.CreateCommand();
                respList.CommandText = "SELECT COUNT(*) FROM dbo.Respondents";
                count = (int)respList.ExecuteScalar();
                count++;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return count;
    }
}