using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using ModelsContinued.Models;
using MySql.Data.MySqlClient;

namespace ModelsContinued
{
    public class UserFactory
    {
        static string server = "localhost";
        static string db = "wall"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }
        public List<User> AllUsers()
        {
            using(IDbConnection dbConnection = Connection)
            {
                List<User> user = dbConnection.Query<User>("SELECT * FROM users").ToList();
                return user;
            }
        }

        public User GetUserById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string SQL = 
                $@"
                    SELECT * FROM users WHERE user_id == @UserId
                ";
                object param = new {UserId = id};

                User user = dbConnection.Query<User>(SQL, param).First();
                return user;
            }
        }

        public bool UserExists(string email)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string SQL = 
                $@"
                    SELECT user_ID FROM users WHERE email == @Email
                ";
                object param = new {Email = email};

                User user = dbConnection.Query<User>(SQL, param).FirstOrDefault();
                return user != null;
            }
        }

        // CREATE
        public void CreateUser(User user)
        {
            using(IDbConnection dbConnection = Connection)
            {
               string SQL = 
                $@"
                    INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                    VALUES (@first_name, @last_name, @email, @password, NOW(), NOW())
                ";
                dbConnection.Execute(SQL, user);
            }
        }
        public void CreateMessage(Message message)
        {
            using(IDbConnection dbConnection = Connection)
            {
              string SQL = 
            $@"
                INSERT INTO messages (content, created_at, updated_at, user_id)
                VALUES (@content, NOW(), NOW(), @user_id)
            ";
                dbConnection.Execute(SQL, message);
            }
        }

        public List<Message> MessagesWithUser()
        {
            using(IDbConnection dbConnection = Connection)
            {
               string SQL = 
                $@"
                    SELECT m.message_id, m.content, m.created_at, m.updated_at, m.user_id,
                    u.user_id, u.first_name, u.last_name, u.email, u.created_at, u.updated_at
                    FROM messages AS m JOIN users AS u ON m.user_id = u.user_id
                ";

                return dbConnection.Query<Message, User, Message>(SQL, (message, user) => {
                    message.Author = user;
                    return message;
                }, splitOn: "user_id").ToList();
                
            }
        }

        
    }
}