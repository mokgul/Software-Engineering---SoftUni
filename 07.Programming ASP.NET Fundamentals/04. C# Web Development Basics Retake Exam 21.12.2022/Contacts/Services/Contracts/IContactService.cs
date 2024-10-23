using Contacts.ViewModels;

namespace Contacts.Services.Contracts;

public interface IContactService
{
    Task<IEnumerable<ContactViewModel>> GetAllAsync();

    Task<IEnumerable<ContactViewModel>> GetMyTeamContactsAsync(string userId);

    Task AddContactAsync(ContactFormModel model);

    Task AddToTeamAsync(string userId, string contactId);

    Task RemoveFromMyTeamAsync(string userId, string contactId);

    Task<ContactFormModel> GetContactByIdAsync(string contactId);

    Task EditContactAsync (string contactId, ContactFormModel model);
}

