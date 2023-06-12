using Contacts.Data;
using Contacts.Data.Entities;
using Contacts.Services.Contracts;
using Contacts.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactsDbContext _data;

        public ContactService(ContactsDbContext context)
        {
            _data = context;
        }

        public async Task AddContactAsync(ContactFormModel model)
        {
            var contact = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.Phone,
                Address = model.Address,
                Website = model.Website,
            };

            await _data.Contacts.AddAsync(contact);
            await _data.SaveChangesAsync();
        }

        public async Task AddToTeamAsync(string userId, string contactId)
        {
            ApplicationUserContact auc = new ApplicationUserContact
            {
                ApplicationUserId = userId,
                ContactId = Guid.Parse(contactId)
            };

            if (!_data.ApplicationUsersContacts.Contains(auc) )
            {
                _data.ApplicationUsersContacts.Add(auc);
            }

            await _data.SaveChangesAsync();
        }

        public async Task EditContactAsync(string contactId, ContactFormModel model)
        {
            var contactToEdit = await _data.Contacts.FindAsync(Guid.Parse(contactId));

            if (contactToEdit != null)
            {
                contactToEdit.Id = model.Id;
                contactToEdit.FirstName = model.FirstName;
                contactToEdit.LastName = model.LastName;
                contactToEdit.Email = model.Email;
                contactToEdit.PhoneNumber = model.Phone;
                contactToEdit.Address = model.Address;
                contactToEdit.Website = model.Website;
            }
            await _data.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactViewModel>> GetAllAsync()
        {
            var all = await _data.Contacts
                .Select(c => new ContactViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Phone = c.PhoneNumber,
                    Address = c.Address,
                    Website = c.Website,
                })
                .ToListAsync();
            return all;
        }

        public async Task<ContactFormModel> GetContactByIdAsync(string contactId)
        {
            var contactToEdit = await _data.Contacts.FindAsync(Guid.Parse(contactId));

            if(contactToEdit != null )
            {
                ContactFormModel model = new ContactFormModel
                {
                    Id = contactToEdit.Id,
                    FirstName = contactToEdit.FirstName,
                    LastName = contactToEdit.LastName,
                    Email = contactToEdit.Email,
                    Phone = contactToEdit.PhoneNumber,
                    Address = contactToEdit.Address,
                    Website = contactToEdit.Website,
                };
                return model;
            }
            return null;
        }

        public async Task<IEnumerable<ContactViewModel>> GetMyTeamContactsAsync(string userId)
        {
            var currentUser = await _data.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            var myTeamContacts = await _data.Contacts
                .Where(c => c.ApplicationUsersContacts.Any(auc => auc.ApplicationUser == currentUser))
                .Select(c => new ContactViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Phone = c.PhoneNumber,
                    Address = c.Address,
                    Website = c.Website,
                })
                .ToListAsync();

            return myTeamContacts;
        }

        public async Task RemoveFromMyTeamAsync(string userId, string contactId)
        {
            ApplicationUserContact auc = new ApplicationUserContact
            {
                ApplicationUserId = userId,
                ContactId = Guid.Parse(contactId)
            };

            if (_data.ApplicationUsersContacts.Contains(auc))
            {
                _data.ApplicationUsersContacts.Remove(auc);
            }

            await _data.SaveChangesAsync();
        }
    }
}
