﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using uow_roadside_assistance.Classes;

namespace uow_roadside_assistance.DBData
{
    public class ResponseDBData
    {
        public static Response getResponse(int requestID, int contractorID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["roadside-assistanceConnectionString"].ConnectionString);
            conn.Open();

            String getResponseQuery = "SELECT * FROM dbo.RESPONSES WHERE requestID = @requestID AND contractorID = @contractorID";
            SqlCommand cmd = new SqlCommand(getResponseQuery, conn);
            cmd.Parameters.AddWithValue("@requestID", requestID);
            cmd.Parameters.AddWithValue("@contractorID", contractorID);
            SqlDataReader reader = cmd.ExecuteReader();

            Response res = null;
            if (reader.Read())
            {
                int responseID = Convert.ToInt32(reader["responseID"]);
                String responseStatus = Convert.ToString(reader["responseStatus"]).TrimEnd();

                res = new Response(responseID, requestID, contractorID, responseStatus);
            }

            conn.Close();

            return res;

        }

        public static ArrayList getResponseList(int requestID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["roadside-assistanceConnectionString"].ConnectionString);
            conn.Open();

            String getResponseQuery = "SELECT * FROM dbo.RESPONSES WHERE requestID = @requestID";
            SqlCommand cmd = new SqlCommand(getResponseQuery, conn);
            cmd.Parameters.AddWithValue("@requestID", requestID);
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList res = new ArrayList();
            while (reader.Read())
            {
                int responseID = Convert.ToInt32(reader["responseID"]);
                int contractorID = Convert.ToInt32(reader["contractorID"]);
                String responseStatus = Convert.ToString(reader["responseStatus"]).TrimEnd();

                res.Add(new Response(responseID, requestID, contractorID, responseStatus));
            }

            conn.Close();

            return res;

        }

        public static void  insertNewResponse(int requestID, int contractorID, String responseStatus)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["roadside-assistanceConnectionString"].ConnectionString);
            conn.Open();

            String insertResponseQuery = "INSERT INTO dbo.RESPONSES(requestID, contractorID, responseStatus)" +
                                        "VALUES (@requestID, @contractorID, @responseStatus)";
            SqlCommand cmd = new SqlCommand(insertResponseQuery, conn);
            cmd.Parameters.AddWithValue("@requestID", requestID);
            cmd.Parameters.AddWithValue("@contractorID", contractorID);
            cmd.Parameters.AddWithValue("@responseStatus", "Waiting");
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static void deleteResponse(int requestID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["roadside-assistanceConnectionString"].ConnectionString);
            conn.Open();

            String deletetRequestQuery = "DELETE FROM dbo.RESPONSES WHERE requestID = @requestID";
            SqlCommand cmd = new SqlCommand(deletetRequestQuery, conn);
            cmd.Parameters.AddWithValue("@requestID", requestID);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}