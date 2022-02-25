using System;
using System.ComponentModel.DataAnnotations.Schema;
using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Framework.Domain;

namespace Onion.Cms.Domain.User.Entities
{
    public class UserInfo : BaseEntity<long>, IAggregateRoot
    {
        public int ApplicationUserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? Birthdate { get; set; }
        public bool? Gender { get; set; }

        #region Relations
        public virtual ApplicationUser ApplicationUser { get; set; }
        #endregion
    }
}