using System;
using System.Data;
using System.Data.SqlClient;
using ProGlassAutomation.Models;

namespace ProGlassAutomation.Services
{
    public class Database
    {
        private string connString = "Server=YOUR_SERVER;Database=GlassAutomationDB;Trusted_Connection=True;";

        // 1. पूरी PI और सभी स्पेसिफिकेशन सेक्शन्स को ट्रांजेक्शन के साथ सेव करना
        public bool SaveFullInvoice(ProformaInvoice inv)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Header Insert
                    string hSql = @"INSERT INTO PI_Headers (PINumber, PIDate, CustomerName, CustomerTRN_VAT, PI_Status, TotalSqm, TotalGrossAmountAED) 
                                   VALUES (@pi, @dt, @cust, @trn, @st, @sqm, @gross); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(hSql, conn, trans);
                    cmd.Parameters.AddWithValue("@pi", inv.PINumber);
                    cmd.Parameters.AddWithValue("@dt", inv.PIDate);
                    cmd.Parameters.AddWithValue("@cust", inv.CustomerName);
                    cmd.Parameters.AddWithValue("@trn", inv.CustomerTRN_VAT);
                    cmd.Parameters.AddWithValue("@st", inv.Status);
                    cmd.Parameters.AddWithValue("@sqm", inv.TotalSqm);
                    cmd.Parameters.AddWithValue("@gross", inv.TotalGross);
                    int piId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Rows Insert
                    foreach (var sec in inv.Sections)
                    {
                        foreach (var row in sec.Rows)
                        {
                            string sSql = @"INSERT INTO PI_Specifications (PI_ID, SectionName, W1, H1, W2, H2, Qty, Sqm, SqmPrice, TotalPrice) 
                                           VALUES (@pid, @sn, @w1, @h1, @w2, @h2, @qty, @sqm, @pr, @tot)";
                            SqlCommand sCmd = new SqlCommand(sSql, conn, trans);
                            sCmd.Parameters.AddWithValue("@pid", piId);
                            sCmd.Parameters.AddWithValue("@sn", sec.FullSpecHeader);
                            sCmd.Parameters.AddWithValue("@w1", row.Width1);
                            sCmd.Parameters.AddWithValue("@h1", row.Height1);
                            sCmd.Parameters.AddWithValue("@w2", row.Width2);
                            sCmd.Parameters.AddWithValue("@h2", row.Height2);
                            sCmd.Parameters.AddWithValue("@qty", row.Qty);
                            sCmd.Parameters.AddWithValue("@sqm", row.Sqm);
                            sCmd.Parameters.AddWithValue("@pr", row.SqmPrice);
                            sCmd.Parameters.AddWithValue("@tot", row.TotalPrice);
                            sCmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    return true;
                }
                catch { trans.Rollback(); return false; }
            }
        }
    }
}
