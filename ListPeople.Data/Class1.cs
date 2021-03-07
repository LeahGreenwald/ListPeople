using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ListPeople.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class PeopleDb
    {
        private readonly string _connectionString;
        public PeopleDb(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "select * from people";
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        FirstName = (string)reader["firstName"],
                        LastName = (string)reader["lastName"],
                        Age = (int)reader["age"],
                        Id = (int)reader["id"]
                    });
                }

                return people;
            }

        }
        public void AddPeople(List<Person> people)
        {
            foreach (Person person in people)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = "insert into people values (@firstName, @lastName, @age)";
                    cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", person.LastName);
                    cmd.Parameters.AddWithValue("@age", person.Age);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
