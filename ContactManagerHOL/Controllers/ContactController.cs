using ContactManagerHOL.Models;
using ContactManagerHOL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManagerHOL.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository _contactRepository;

        public ContactController()
        {
            this._contactRepository = new ContactRepository();
        } 

        public Contact[] Get()
        {
            return _contactRepository.GetAllContacts();
        }
    }
}
