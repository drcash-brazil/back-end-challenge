using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Models;
using DrCashChallenge.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCashChallenge.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool Validate<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validationResult = validation.Validate(entity);

            if (validationResult.IsValid) return true;

            Notificate(validationResult.Errors);

            return false;
        }

        protected void Notificate(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                _notificator.Handle(new Notification(error.ErrorMessage));
            }
        }

        protected void Notificate(string message)
        {

            _notificator.Handle(new Notification(message));
        }

    }
}
