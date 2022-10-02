using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HomeworkAssigment5.Models;
namespace HomeworkAssigment5.Data
{
    public class LibraryService
    {

        private static LibraryService instance;
        // Connection string 
        public String connectionString = "Data Source=DESKTOP-5VH12MV\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True";

        public static LibraryService getInstance()
        {
            if (instance == null)
            {
                instance = new LibraryService();
            }
            return instance;
        }

        public List<Book> Books()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from books", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book
                            {
                                Id = Convert.ToInt32(reader["bookId"]),
                                Name = Convert.ToString(reader["name"]),
                                PageCount = Convert.ToInt32(reader["pagecount"]),
                                Points = Convert.ToInt32(reader["point"]),
                                Author = AuthorById(Convert.ToInt32(reader["authorId"]))

                            };
                            books.Add(book);
                        }
                    }
                }
                con.Close();
            }
            return books;
        }

        public List<Author> Author()
        {
            List<Author> authors = new List<Author>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from authors", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Author author = new Author
                            {
                                Id = Convert.ToInt32(reader["authorId"]),
                                Name = Convert.ToString(reader["name"]),
                                Surname = Convert.ToString(reader["surname"]),                             
                            };
                            authors.Add(author);
                        }
                    }
                }
                con.Close();
            }
            return authors;
        }

        public Author AuthorById(int Id)
        {
            Author author = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from authors where authorId = " + Id, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            author = new Author
                            {
                                Id = Convert.ToInt32(reader["authorId"]),
                                Name = Convert.ToString(reader["name"]),
                                Surname = Convert.ToString(reader["surname"]),
                            };
                            
                        }
                    }
                }
                con.Close();
            }
            return author;
        }


    }
}