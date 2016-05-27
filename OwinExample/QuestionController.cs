using System.Collections.Generic;
using System.Web.Http;

namespace OwinExample
{
    public class QuestionController : ApiController
    {
        public List<Question> Get()
        {
            QuestionLoader loader = new QuestionLoader();
            return loader.GetQuestions();
        }
    }
}
