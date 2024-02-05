namespace ServiceForQuestionnaires.Controllers
{
   
        internal class Interview
        {
            public int Id { get; set; }//id
            public string InterviewName { get; set; }//название интервью
            public int MaxAnswers { get; set; }// максимальное кол-во ответов
            public int UserID { get; set; }//id юзера
            public int AnswerID { get; set; }//id ответа
            public int QuestionID { get; set; }//id вопроса
            public bool Deleted { get; set; }//удален
            public int DeletedByUserID { get; set; }//удален юзером
        }
    
}