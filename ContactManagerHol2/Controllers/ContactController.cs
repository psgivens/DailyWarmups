using ContactManagerHol2.Models;
using ContactManagerHol2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManagerHol2.Controllers
{
    public class ContactController : ApiController
    {
        private readonly ContactRepository _repository;
        public ContactController()
        {
            _repository = new ContactRepository();
        }

        public Contact[] Get()
        {
            return _repository.GetAllContacts();
        }

        public HttpResponseMessage Post(Contact contact)
        {
            this._repository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }
    }
}
