﻿

using AutoMapper;
using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Enums;
using ConsultaAlumnosClean.Domain.Interfaces;
using System.Security.Claims;

namespace Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMailService _mailService;
        private readonly IUserRepository _userRepository;
        

        public QuestionService(IMapper mapper,
            IQuestionRepository questionRepository,
            IMailService mailService,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _mailService = mailService;
            _userRepository = userRepository;
        }

        public QuestionDto CreateQuestion(QuestionCreateRequest newQuestionDto, int userId)
        {
            var newQuestion = _mapper.Map<Question>(newQuestionDto);

            newQuestion.CreatorStudentId = userId;

            var student = _userRepository.GetUserById(userId);
            var professor = _userRepository.GetUserById(newQuestionDto.ProfessorId);

            _questionRepository.AddQuestion(newQuestion);
            if (_questionRepository.SaveChanges())
                _mailService.Send("Se creó una nueva consulta",
                    $"Usted tiene una nueva consulta asignada por parte del alumno: {student.Name} {student.LastName} ",
                    professor.Email);

            return _mapper.Map<QuestionDto>(newQuestion);
        }

        public QuestionDto? GetQuestion(int questionId)
        {
            var consulta = _questionRepository.GetQuestion(questionId);
            return _mapper.Map<QuestionDto?>(consulta);
        }

        public bool IsQuestionIdValid(int questionId)
        {
            return _questionRepository.IsQuestionIdValid(questionId);
        }

        public void ChangeQuestionStatus(int questionId, QuestionState newStatus)
        {
            var question = _questionRepository.GetQuestion(questionId);
            question.LastModificationDate = DateTime.Now;
            question.QuestionState = newStatus;
            if (_questionRepository.SaveChanges())
                NotifyStatusChange(question);
        }

        public void ChangeQuestionStatus(int questionId,string userType)
        {
           
            var question = _questionRepository.GetQuestion(questionId);
            question.QuestionState = userType == "Alumno" ? QuestionState.WaitingProfessorAnwser : QuestionState.WaitingStudentAnwser;
            question.LastModificationDate = DateTime.Now;
            if (_questionRepository.SaveChanges())
                NotifyStatusChange(question);
        }

        private void NotifyStatusChange(Question question)
        {
            _mailService.Send("Se modificó el estado de una consulta",
                $"Usted tiene una notificación de su consulta: {question.Title}",
                question.Student.Email);

            _mailService.Send("Se modificó el estado de una consulta",
                $"La siguiente pregunta '{question.Title}' pasó a estado: {question.QuestionState.ToString()}",
                question.AssignedProfessor.Email);
        }

    }
}