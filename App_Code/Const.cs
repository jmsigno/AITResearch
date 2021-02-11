using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Const
/// </summary>
public class Const
{
    public Const(){}

    //Databse connection string 
    public const string DbConnStr = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19DDA7213;User ID=DB_9AB8B7_D19DDA7213_admin;Password=H2QPLdSm";

    /// <summary>
    /// Get the current IP address of the user
    /// </summary>
    /// <returns> returns string: IP address converted to string </returns>
    public string GetIPAddress()
    {
        //get IP through PROXY
        //====================
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //should break ipAddress down, but here is what it looks like:
        // return ipAddress;
        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] address = ipAddress.Split(',');
            if (address.Length != 0)
            {
                return address[0];
            }
        }
        //if not proxy, get nice ip, give that back :(
        //ACROSS WEB HTTP REQUEST
        //=======================
        ipAddress = context.Request.UserHostAddress;//ServerVariables["REMOTE_ADDR"];

        if (ipAddress.Trim() == "::1")//ITS LOCAL(either lan or on same machine), CHECK LAN IP INSTEAD
        {
            //This is for Local(LAN) Connected ID Address
            string stringHostName = System.Net.Dns.GetHostName();
            //Get Ip Host Entry
            System.Net.IPHostEntry ipHostEntries = System.Net.Dns.GetHostEntry(stringHostName);
            //Get Ip Address From The Ip Host Entry Address List
            System.Net.IPAddress[] arrIpAddress = ipHostEntries.AddressList;

            try
            {
                ipAddress = arrIpAddress[1].ToString();
            }
            catch
            {
                try
                {
                    ipAddress = arrIpAddress[0].ToString();
                }
                catch
                {
                    try
                    {
                        arrIpAddress = System.Net.Dns.GetHostAddresses(stringHostName);
                        ipAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        ipAddress = "127.0.0.1";
                    }
                }
            }
        }
        return ipAddress;
    }
}