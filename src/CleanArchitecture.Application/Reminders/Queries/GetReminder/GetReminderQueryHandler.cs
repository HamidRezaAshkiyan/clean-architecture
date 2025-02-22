using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Reminders;

using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Reminders.Queries.GetReminder;

public class GetReminderQueryHandler(IRemindersRepository _remindersRepository)
        : IRequestHandler<GetReminderQuery, ErrorOr<Reminder>>
{
    public async Task<ErrorOr<Reminder>> Handle(GetReminderQuery query, CancellationToken cancellationToken)
    {
        return await _remindersRepository.GetByIdAsync(query.ReminderId, cancellationToken) is Reminder reminder
            ? reminder
            : Error.NotFound(description: "Reminder not found");
    }
}