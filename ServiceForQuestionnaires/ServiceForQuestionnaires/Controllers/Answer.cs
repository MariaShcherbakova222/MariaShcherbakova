namespace ServiceForQuestionnaires.Controllers
{
    public class Answer
    {
        public int Id { get; set; }//id
        public int QuestionID { get; set; }//id ответа
        public int Texxt { get; set; }// текст ответа
        public bool Deleted { get; set; }//удален
        public int DeletedByUserID { get; set; }//удален юзером
    }
}