﻿using ConsultaAlumnos.Domain.Enums;
using ConsultaAlumnos.Domain.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaAlumnos.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(4000)")]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; private set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; private set; } = DateTime.Now;

        public ICollection<Response> Responses { get; set; } = new List<Response>();

        public QuestionState QuestionState { get; private set; } = QuestionState.WaitingProfessorAnwser;

        //[ForeignKey("ProfessorId")]
        public Professor AssignedProfessor { get; private set; }

        public Student Student { get; private set; }

        public Subject Subject { get; private set; }

        public Question()
        {
            
        }

        public Question(Student studentCreator, Subject subject, Professor professor)
        {
            Student = studentCreator;
            Subject = subject;
            AssignedProfessor = professor;
        }

        public void AddResponse(Response response)
        {
            //Validations
            if (response.Creator.Id != AssignedProfessor.Id && response.Creator.Id != Student.Id)
            {
                throw new NotAllowedException("Response creator is not allowed to add reponses to this question");
            }

            if (QuestionState == QuestionState.WaitingProfessorAnwser && response.Creator.Id != AssignedProfessor.Id)
            {
                throw new AppValidationException("Action not allowed becouse waiting for Professor answer");
            }

            if (QuestionState == QuestionState.WaitingStudentAnwser && response.Creator.Id != Student.Id)
            {
                throw new AppValidationException("Action not allowed becouse waiting for Student answer");
            }

            if (QuestionState == QuestionState.Canceled)
            {
                throw new AppValidationException("Action not allowed becouse the answer in Canceled");
            }

            if (QuestionState == QuestionState.Resolved)
            {
                throw new AppValidationException("Action not allowed becouse the answer in Resolved");
            }

            if (string.IsNullOrEmpty(response.Message))
            {
                throw new ApplicationException("Response message can not be empty");
            }


            QuestionState newQuestionState = response.Creator.Id == AssignedProfessor.Id ? QuestionState.WaitingStudentAnwser : QuestionState.WaitingProfessorAnwser;

            Responses.Add(response);
            QuestionState = newQuestionState;
            LastModificationDate = DateTime.Now;
        }

        public void ChangeQuestionStatus(QuestionState questionState, int userId)
        {
            //Validations
            if (AssignedProfessor.Id != userId && Student.Id != userId)
            {
                throw new Exception("User not allowed to modify this question");
            }

            if (QuestionState == questionState)
            {
                throw new Exception("The question has it State already");
            }

            QuestionState = questionState;
            LastModificationDate = DateTime.Now;

        }

    }

}
