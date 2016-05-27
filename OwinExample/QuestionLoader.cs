using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OwinExample
{
    public class QuestionLoader
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\John\Documents\AcademyPGH\Code\OwinExample\OwinExample\buzzfeed.mdf;Integrated Security=True");
        SqlCommand command;
        SqlDataReader reader;

        public List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();
            command = new SqlCommand("SELECT * FROM Questions", connection);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Question question = new Question();
                    question.id = Convert.ToInt32(reader["Id"]);
                    question.text = reader["text"].ToString();
                    questions.Add(question);
                }
            }
            reader.Close();
            foreach (Question q in questions)
            {
                command = new SqlCommand($"SELECT * FROM Answers WHERE QuestionID={q.id}", connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Answer answer = new Answer();
                        answer.id = Convert.ToInt32(reader["id"]);
                        answer.text = reader["text"].ToString();
                        answer.value = Convert.ToInt32(reader["value"]);
                        answer.questionid = Convert.ToInt32(reader["QuestionId"]);
                        q.answers.Add(answer);
                    }
                }
                reader.Close();
            }
            connection.Close();
            return questions;
        }
    }
}
