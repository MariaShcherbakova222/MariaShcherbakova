using Microsoft.AspNetCore.Mvc;
using ServiceForQuestionnaires.Controllers;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceForQuestionnairesController : ControllerBase
{

    private static List<Question> Questions = new List<Question>();
    private static List<Answer> Answers = new List<Answer>();
    private static List<Interview> Interviews = new List<Interview>();

 
    private readonly ILogger<ServiceForQuestionnairesController> _logger;


    public ServiceForQuestionnairesController(ILogger<ServiceForQuestionnairesController> logger)
    {
        _logger = logger;
    }

    
    //�����
    [HttpGet("searchInterview")]
    public IActionResult SearchByInterview([FromQuery] string interviewName)
    {
        var Interview = Interviews.Where(i => i.InterviewName == interviewName).ToList();
        return Ok(interviewName);
    }


    // �������� �������
    [HttpPost("Question")]
    public IActionResult CreateQuestion([FromBody] Question newQuestion)
    {
        newQuestion.InterviewId = 1;//������ ������������� � 1 Id
            Questions.Add(newQuestion);
        return Ok(newQuestion);
    }
    //�������� ������
    [HttpPost("Answer")]
    public IActionResult CreateAnswer([FromBody] Answer newAnswer)
    {
        newAnswer.QuestionID = 1; //������ ������������� � 1 Id
        Answers.Add(newAnswer);
        return Ok(newAnswer);
    }

    // ����� ������ �������� �� ������������ �����

    [HttpGet("Interview/checkInterviewName")]
    public IActionResult CheckInterviewName([FromQuery] string interviewName)
    {
        var hasInterview = Interviews.Any(i => i.InterviewName == interviewName);

        if (hasInterview)
        {
            return Ok("������ � ��������� ������ �������� ������� � ����� ������");
        }
        else
        {
            return Ok("������ � ��������� ������ �������� �� ����������");
        }
    }

    // ������ �������� ��������

    [HttpDelete("Interview/delete")]
    public IActionResult SoftDeleteInterview(int InterviewId)
    {
        var interview = Interviews.FirstOrDefault(i => i.Id == InterviewId);
        if (interview == null)
        {
            return NotFound("Interview not found");
        }

        interview.Deleted = true;
        interview.DeletedByUserID = 1;//������ ������������� � 1 Id

            return Ok("Interview soft deleted");
    }

    // ������ �������� �������

    [HttpDelete("Question/delete")]
    public IActionResult SoftDeleteQuestion(int QuestionId)
    {
        var question = Questions.FirstOrDefault(q => q.ID == QuestionId);
        if (question == null)
        {
            return NotFound("Question not found");
        }

        question.Deleted = true;
        question.DeletedByUserID = 1;//������ ������������� � 1 Id

            return Ok("Question soft deleted");
    }


    // ������ �������� ������
    [HttpDelete("Answer/delete")]
    public IActionResult SoftDeleteAnswer(int AnswerId)
    {
        var answer = Answers.FirstOrDefault(a => a.Id == AnswerId);
        if (answer == null)
        {
            return NotFound("Answer not found");
        }

        answer.Deleted = true;
        answer.DeletedByUserID = 1;//������ ������������� � 1 Id


            return Ok("Answer soft deleted");
    }



}


}