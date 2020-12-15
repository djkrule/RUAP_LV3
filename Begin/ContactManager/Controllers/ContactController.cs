using ContactManager.Models;
using System.Web.Http;
using ContactManager.Services;
using System.Net.Http;

namespace ContactManager
{
    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;
        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }
        // GET api/<controller>
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }
        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }
    }
}