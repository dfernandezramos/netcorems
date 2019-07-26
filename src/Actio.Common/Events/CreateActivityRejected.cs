using System;

namespace Actio.Common.Events
{
    public class CreateActivityRejected : IRejectedEvent
    {

        public Guid UserId { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public string Reason { get; }  

        public string Code { get; }

        protected CreateActivityRejected ()
        {

        }

        public CreateActivityRejected (Guid userId, string category, string name, string description, string reason, string code)
        {
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            Reason = reason;
            Code = code;
        }
    }
}