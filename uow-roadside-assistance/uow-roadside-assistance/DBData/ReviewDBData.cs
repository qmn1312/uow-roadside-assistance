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
    public class ReviewDBData
    {
        //
        public static ArrayList getAllReviews()
        {

            SqlConnection conn = Helper.Connection.connectionString;
            conn.Open();

            String getUserNameQuery = "SELECT * FROM dbo.REVIEWS";
            SqlCommand cmd = new SqlCommand(getUserNameQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList reviews = new ArrayList();

            while (reader.Read())
            {
                int reviewID = Convert.ToInt32(reader["reviewID"]);
                String reviewDesc = Convert.ToString(reader["reviewDesc"]).TrimEnd();
                double rating = Convert.ToInt32(reader["rating"]);
                int transactionID = Convert.ToInt32(reader["transactionID"]);
                int customerID = Convert.ToInt32(reader["customerID"]);
                int contractorID = Convert.ToInt32(reader["contractorID"]);
                DateTime reviewDate = Convert.ToDateTime(reader["reviewDate"]);

                Boolean appeal = Convert.ToBoolean(reader["appeal"]);
                String reason = Convert.ToString(reader["reason"]).TrimEnd();

                Review review = new Review(reviewID, reviewDesc, rating, transactionID, customerID, contractorID, reviewDate, appeal, reason);

                reviews.Add(review);
            }

            conn.Close();

            return reviews;
        }

        // 
        public static int getTotalNumberOfReviews()
        {
            SqlConnection conn = Helper.Connection.connectionString;

            conn.Open();

            String getUserNameQuery = "SELECT COUNT(*) AS totalReviews FROM dbo.REVIEWS";
            SqlCommand cmd = new SqlCommand(getUserNameQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            int res = 0;

            if (reader.Read())
            {
                res = Convert.ToInt32(reader["totalReviews"]);
            }

            conn.Close();

            return res;
        }

        //
        public static int getNumberOfGoodRatings()
        {
            SqlConnection conn = Helper.Connection.connectionString;

            conn.Open();

            String getUserNameQuery = "SELECT COUNT(*) AS numOfGoodRatings FROM dbo.REVIEWS WHERE rating > 3";
            SqlCommand cmd = new SqlCommand(getUserNameQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            int res = 0;

            if (reader.Read())
            {
                res = Convert.ToInt32(reader["numOfGoodRatings"]);
            }

            conn.Close();

            return res;
        }

        // 
        public static double getAverageRatingByContractorID(int contractorID)
        {
            SqlConnection conn = Helper.Connection.connectionString;
            double averageRating = 0;

            try
            {
                conn.Open();

                String getUserNameQuery = "SELECT AVG(rating) AS averageRating FROM dbo.REVIEWS WHERE contractorID = @contractorID;";
                SqlCommand cmd = new SqlCommand(getUserNameQuery, conn);
                cmd.Parameters.AddWithValue("@contractorID", contractorID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    averageRating = Convert.ToDouble(reader["averageRating"]);
                }
            }
            catch(Exception e)
            {

            } 
            finally
            {
                conn.Close();
            }

            return averageRating;
        }

        // Appeal Review
        public static ArrayList getAppealedReviews()
        {
            Boolean appeal = true;

            SqlConnection conn = Helper.Connection.connectionString;
            conn.Open();

            String getUserNameQuery = "SELECT * FROM dbo.REVIEWS WHERE appeal = @appeal ORDER BY reviewDate DESC";
            SqlCommand cmd = new SqlCommand(getUserNameQuery, conn);
            cmd.Parameters.AddWithValue("@appeal", appeal);
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList appealedReviews = new ArrayList();

            while (reader.Read())
            {
                int reviewID = Convert.ToInt32(reader["reviewID"]);
                String reviewDesc = Convert.ToString(reader["reviewDesc"]).TrimEnd();
                double rating = Convert.ToInt32(reader["rating"]);
                int transactionID = Convert.ToInt32(reader["transactionID"]);
                int customerID = Convert.ToInt32(reader["customerID"]);
                int contractorID = Convert.ToInt32(reader["contractorID"]);
                DateTime reviewDate = Convert.ToDateTime(reader["reviewDate"]);

                // appeal
                String reason = Convert.ToString(reader["reason"]).TrimEnd();

                Review review = new Review(reviewID, reviewDesc, rating, transactionID, customerID, contractorID, reviewDate, appeal, reason);

                appealedReviews.Add(review);
            }

            conn.Close();

            return appealedReviews;
        }

        //
        public static Review getReviewsByTransactionID(int transactionID)
        {
            SqlConnection conn = Helper.Connection.connectionString;
            conn.Open();

            String getUserNameQuery = "SELECT * FROM dbo.REVIEWS WHERE transactionID = @transactionID ORDER BY reviewDate DESC";
            SqlCommand cmd = new SqlCommand(getUserNameQuery, conn);
            cmd.Parameters.AddWithValue("@transactionID", transactionID);
            SqlDataReader reader = cmd.ExecuteReader();

            Review review = null;
            if (reader.Read())
            {
                int reviewID = Convert.ToInt32(reader["reviewID"]);
                String reviewDesc = Convert.ToString(reader["reviewDesc"]).TrimEnd();
                double rating = Convert.ToInt32(reader["rating"]);
                // transactionID
                int customerID = Convert.ToInt32(reader["customerID"]);
                int contractorID = Convert.ToInt32(reader["contractorID"]);
                DateTime reviewDate = Convert.ToDateTime(reader["reviewDate"]);

                Boolean appeal = Convert.ToBoolean(reader["appeal"]);
                String reason = Convert.ToString(reader["reason"]).TrimEnd();

                review = new Review(reviewID, reviewDesc, rating, transactionID, customerID, contractorID, reviewDate, appeal, reason);
            }

            conn.Close();

            return review;
        }

        public static ArrayList getReviewsByContractorID(int contractorID)
        {
            SqlConnection conn = Helper.Connection.connectionString;
            conn.Open();

            String getUserNameQuery = "SELECT * FROM dbo.REVIEWS WHERE contractorID = @contractorID ORDER BY reviewDate DESC";
            SqlCommand cmd = new SqlCommand(getUserNameQuery, conn);
            cmd.Parameters.AddWithValue("@contractorID", contractorID);
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList res = new ArrayList();
            while (reader.Read())
            {
                int reviewID = Convert.ToInt32(reader["reviewID"]);
                String reviewDesc = Convert.ToString(reader["reviewDesc"]).TrimEnd();
                double rating = Convert.ToInt32(reader["rating"]);
                int transactionID = Convert.ToInt32(reader["transactionID"]);
                int customerID = Convert.ToInt32(reader["customerID"]);
                // contractorID
                DateTime reviewDate = Convert.ToDateTime(reader["reviewDate"]);

                Review review = new Review(reviewID, reviewDesc, rating, transactionID, customerID, contractorID, reviewDate);

                res.Add(review);
            }

            conn.Close();

            return res;
        }

        public static ArrayList getReviewsByCustomerID(int customerID)
        {
            SqlConnection conn = Helper.Connection.connectionString;
            conn.Open();

            String getUserNameQuery = "SELECT * FROM dbo.REVIEWS WHERE customerID = @customerID ORDER BY reviewDate DESC";
            SqlCommand cmd = new SqlCommand(getUserNameQuery, conn);
            cmd.Parameters.AddWithValue("@customerID", customerID);
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList res = new ArrayList();
            while (reader.Read())
            {
                int reviewID = Convert.ToInt32(reader["reviewID"]);
                String reviewDesc = Convert.ToString(reader["reviewDesc"]).TrimEnd();
                double rating = Convert.ToInt32(reader["rating"]);
                int transactionID = Convert.ToInt32(reader["transactionID"]);
                // customerID 
                int contractorID = Convert.ToInt32(reader["contractorID"]);
                DateTime reviewDate = Convert.ToDateTime(reader["reviewDate"]);

                Review review = new Review(reviewID, reviewDesc, rating, transactionID, customerID, contractorID, reviewDate);

                res.Add(review);
            }

            conn.Close();

            return res;
        }

        //
        public static void insertNewReview(String reviewDesc, double rating, int transactionID)
        {
            Transaction transaction = TransactionDBData.GetTransactionByID(transactionID);
            int customerID = transaction.CustomerID;
            int contractorID = transaction.ContractorID;

            DateTime currentDate = DateTime.Now;
            String reviewDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");

            Boolean appeal = false;
            String reason = "";

            SqlConnection conn = Helper.Connection.connectionString;
            conn.Open();
            String insertQuery = "INSERT INTO dbo.REVIEWS(reviewDesc, rating, transactionID, customerID, contractorID, reviewDate, appeal, reason) " +
                                    "VALUES (@reviewDesc, @rating, @transactionID, @customerID, @contractorID, @reviewDate, @appeal, @reason)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@reviewDesc", reviewDesc);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.Parameters.AddWithValue("@transactionID", transactionID);
            cmd.Parameters.AddWithValue("@customerID", customerID);
            cmd.Parameters.AddWithValue("@contractorID", contractorID);
            cmd.Parameters.AddWithValue("@reviewDate", reviewDate);
            cmd.Parameters.AddWithValue("@appeal", appeal);
            cmd.Parameters.AddWithValue("@reason", reason);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        // Update
        public static void updateReviewAndRating(int transactionID, String reviewDesc, double rating)
        {

            SqlConnection conn = Helper.Connection.connectionString;
            conn.Open();
            String insertQuery = "UPDATE dbo.REVIEWS SET reviewDesc = @reviewDesc, rating = @rating WHERE transactionID = @transactionID" ;
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@transactionID", transactionID);
            cmd.Parameters.AddWithValue("@reviewDesc", reviewDesc);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static void updateAppealAndReason(int transactionID, Boolean appeal, String reason)
        {

            SqlConnection conn = Helper.Connection.connectionString;
            conn.Open();
            String insertQuery = "UPDATE dbo.REVIEWS SET appeal = @appeal, reason = @reason WHERE transactionID = @transactionID";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@transactionID", transactionID);
            cmd.Parameters.AddWithValue("@appeal", appeal);
            cmd.Parameters.AddWithValue("@reason", reason);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        // DELETE
        public static void deleteReviewByTransactionID(int transactionID)
        {

            SqlConnection conn = Helper.Connection.connectionString;
            conn.Open();
            String insertQuery = "DELETE FROM dbo.REVIEWS WHERE transactionID = @transactionID";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@transactionID", transactionID);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}